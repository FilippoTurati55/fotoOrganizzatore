using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;

namespace FotoOrganizzatore
{
    class UnitaEsterna
    {
        Backup backup;
        Discobackup interfaccia;
        public string idUnivoco;
        public string format;
        public string label;           // id costruttore o simile es. Lexar
        public string name;     // percorso. es. f://
        public string drive;           // unità disco es. F
        public string numeroDiSerie;   // numero di serie
        public string pathFoto;        // per esempio foto
        public string pathFotoDoppie;
        public long spazioLibero, spazioDisponibile, spazioTotale;
        public string identificatore = "";     // identificatore utente es. copia sicurezza
        DriveType tipo;
        public UnitaEsterna(Backup riferimento)
        {

        }
        public bool esaminaDisco(DriveInfo driveInfo)
        {
            bool res = false;
            name = driveInfo.Name;
            tipo = driveInfo.DriveType;
            if (driveInfo.IsReady)
            {
                interfaccia = new Discobackup(backup);
                label = driveInfo.VolumeLabel;
                format = driveInfo.DriveFormat;
                spazioDisponibile = driveInfo.AvailableFreeSpace;
                spazioLibero = driveInfo.TotalFreeSpace;
                spazioTotale = driveInfo.TotalSize;
                drive = name.Substring(0, 1);
                string messaggio = "Win32_LogicalDisk.DeviceID=\"" + drive + ":\"";
                ManagementObject obj = new ManagementObject(messaggio);
                obj.Get();
                numeroDiSerie = obj["VolumeSerialNumber"].ToString();
                interfaccia.setNumeroDiSerie(numeroDiSerie);
                //Variabili.cruscotto.RegistraDiscoBackup(interfaccia);
                res = true;
            }
            return res;
        }
        public bool accredita()
        {
            bool result = false;
            idUnivoco = label + "_" + numeroDiSerie;
            if (Variabili.UnitaEsterneAccreditate.ContainsKey(idUnivoco))
            {
                // unità esterna già registrata
                string s = Variabili.UnitaEsterneAccreditate[idUnivoco];
                string[] ssplit = s.Split(';');
                identificatore = ssplit[0];
                pathFoto = name + ssplit[1];
                // verificare che pathFotoDoppie sia corretto
                pathFotoDoppie = name + "doppie";  
                Variabili.UnitaEsterne.Add(this);
                result = true;
            }
            else
            {
                if (!Variabili.UnitaEsterneRifiutate.ContainsKey(idUnivoco))
                {
                    // unità esterna nuova
                    AccreditamentoUnitaBackup aub = new AccreditamentoUnitaBackup();
                    aub.inizializza(drive, label, numeroDiSerie);
                    DialogResult dr;
                    aub.Size = new System.Drawing.Size(480, 370);
                    dr = aub.ShowDialog();
                    if ((dr == DialogResult.OK) || (dr == DialogResult.Yes))
                    {
                        identificatore = aub.getIdentificatore();
                        Variabili.UnitaEsterne.Add(this);
                        Variabili.UnitaEsterneAccreditate.Add(idUnivoco, identificatore);
                        result = true;
                    }
                    else
                    {
                        Variabili.UnitaEsterneRifiutate.Add(idUnivoco, identificatore);
                    }
                    Preferenze.ScriviPreferenze();
                }
            }
            return result;
        }
    }
    public class Backup
    {
        UnitaEsterna disco;
        public DataBaseFoto dataBaseFotoSuDiscoBackup;
        public Calendario calendarioBackup = new Calendario();
        Form1 form1Ref;
        AndamentoAttivita andamento = new AndamentoAttivita();
        public void CercaUnitaEsterne(Form1 form1)
        {
            form1Ref = form1;
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                switch (d.DriveType)
                {
                    case DriveType.Removable:
                        Variabili.tracciaMessaggi("trovato disco removibile");
                        disco = new UnitaEsterna(this);
                        if (disco.esaminaDisco(d))
                        {
                            Variabili.tracciaMessaggi("trovato disco removibile unità " + disco.name + " id: " + disco.label + " num serie: " + disco.numeroDiSerie);
                            Variabili.tracciaMessaggi("disco removibile spazio libero " + disco.spazioLibero + " Bytes di " + disco.spazioTotale + "Bytes totali");
                            form1.AggiungiDiscoBackup(this);
                            Variabili.UnitaEsterne.Add(disco);
                            andamento.memoriaNomeAttivita = disco.identificatore;
                            if (disco.accredita())
                            {
                                //Variabili.UnitaEsterneAccreditate.Add(disco.idUnivoco, disco.identificatore);
                                Variabili.tracciaMessaggi("identificatore disco removibile " + disco.identificatore + " accreditato");
                                Variabili.tracciaMessaggi(andamento, "avvio backup", true);
                                var t = Task.Run(() => taskBackup());
                            }    
                        }
                        break;
                }
            }
        }
        void taskBackup()
        {
            dataBaseFotoSuDiscoBackup = new DataBaseFoto(disco.pathFoto, disco.pathFotoDoppie);
            dataBaseFotoSuDiscoBackup.creaDataBase(calendarioBackup);
            // anni = Variabili.operazioniSuPc.elencaAnni(name);
            //Variabili.elencaDateFotoInCartellaClasse.ElencaImmediatamente(elencoDateFoti, anni, false, elencoDateDateDoppie, true);
            aggiungiModificaDateSuBackup();
            //copiaFotoNuove();
            
        }
        void aggiungiModificaDateSuBackup()
        {
            foreach (var dt in Variabili.Calendario.elencoDateFotiAsync)
            {
                DateTime inizio = dt.Value.DateTimeInizio;
                DateTime fine = dt.Value.GetDateTimeFine();
                if (calendarioBackup.elencoDateFotiAsync.ContainsKey(dt.Key))
                {
                    // data già presente nel backup
                    ;
                }
                else
                {
                    // data non presente nel backup
                    string nomeCartellaOriginale = dt.Value.nomeCompletoCartella;
                    string inizioNomeCartellaOriginale = Preferenze.NomeCartellaFotoOrganizzate;

                    ; // va creata la cartella 
                    string nomeCartella = nomeCartellaOriginale.Substring(inizioNomeCartellaOriginale.Length);
                    string nomeCompletoNuovaCartella = disco.pathFoto + nomeCartella;
                    Directory.CreateDirectory(nomeCompletoNuovaCartella);
                    string[] scomposto = nomeCompletoNuovaCartella.Split('\\');
                    string ncartella = scomposto[0];
                    for (int n = 1; n < scomposto.Length - 1; n++)
                        ncartella += @"\" + scomposto[n];
                    calendarioBackup.AggiungiData(nomeCompletoNuovaCartella + @"\nomeFileFinto.fnt", ncartella);
                    Utility.CopiaCartella(nomeCartellaOriginale, nomeCompletoNuovaCartella);
                }
                /*
                DateTime confronto = new DateTime(2020, 11, 11);
                if (inizio == confronto)
                    inizio = inizio;
                string commento = dt.Value.GetCommento();
                if (!elencoDateFoti.ContainsKey(inizio))
                {
                    Variabili.operazioniSuPc.CreaCartella(nomeCartellaBackup, inizio, fine, commento);
                }
                else
                {
                    var vecchio = elencoDateFoti[inizio];
                    DateTime inizioVecchio = vecchio.DateTime;
                    DateTime fineVecchio = vecchio.DateTimeFine;
                    string commentoVecchio = vecchio.GetCommento();
                    if (fine != fineVecchio)
                    {
                        Variabili.calendario.EventoSciogliRaggruppamento(vecchio.setDataOra, nomeCartellaBackup);
                        Variabili.calendario.Raggruppa(inizio, fine, commento, nomeCartellaBackup, elencoDateFoti);
                    }
                    if (commento != commentoVecchio)
                    {
                        string nomeNuovo = Variabili.operazioniSuPc.CalcolaNomeCartella(inizio, fine, commento);
                        commentoVecchio = vecchio.GetCommento(); // messo per debug
                        string nomeVecchio = Variabili.operazioniSuPc.CalcolaNomeCartella(inizioVecchio, fineVecchio, commentoVecchio);
                        Variabili.operazioniSuPc.RinominaCartella(nomeCartellaBackup, nomeVecchio, nomeNuovo);
                    }
                }*/
            }
        }
    }
}
