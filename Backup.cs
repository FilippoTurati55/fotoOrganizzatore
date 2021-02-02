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
        public string idUnivoco;
        string format;
        string label;           // id costruttore o simile es. Lexar
        public string name;     // percorso. es. f://
        string drive;           // unità disco es. F
        string numeroDiSerie;   // numero di serie
        long spazioLibero, spazioDisponibile, spazioTotale;
        public string identificatore = "";     // identificatore utente es. backup foto
        DriveType tipo;

        public bool esaminaDisco(DriveInfo driveInfo)
        {
            bool res = false;
            name = driveInfo.Name;
            tipo = driveInfo.DriveType;
            if (driveInfo.IsReady)
            {
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
                identificatore = Variabili.UnitaEsterneAccreditate[idUnivoco];
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
    class Backup
    {
        UnitaEsterna disco;
        DataBaseFoto dataBaseFotoSuDiscoBackup;
        Calendario calendarioBackup = new Calendario();
        public void CercaUnitaEsterne()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                switch (d.DriveType)
                {
                    case DriveType.Removable:
                        disco = new UnitaEsterna();
                        if (disco.esaminaDisco(d))
                        {
                            Variabili.UnitaEsterne.Add(disco);
                            if (disco.accredita())
                            {
                                //Variabili.UnitaEsterneAccreditate.Add(disco.idUnivoco, disco.identificatore);
                                var t = Task.Run(() => taskBackup());
                            }    
                        }
                        break;
                }
            }
        }
        void taskBackup()
        {
            dataBaseFotoSuDiscoBackup = new DataBaseFoto(disco.name);
            dataBaseFotoSuDiscoBackup.creaDataBase(calendarioBackup);
            // anni = Variabili.operazioniSuPc.elencaAnni(name);
            /*Variabili.elencaDateFotoInCartellaClasse.ElencaImmediatamente(elencoDateFoti, anni, false, elencoDateDateDoppie, true);
            aggiungiModificaDateSuBackup(name);
            copiaFotoNuove();
            */
        }
    }
}
