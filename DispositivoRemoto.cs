using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using external_drive_lib.interfaces;

namespace FotoOrganizzatore
{
    enum STATO_DISPOSITIVO
    {
        DA_ESAMINARE,
        DA_CATALOGARE,
        SCARTATO,
        ACCETTATO
    }
    class Foto
    {
        // commento da cancellare
        public string nome;
        public IFile file;
        public DateTime dateTime;
        public Foto(string Nome, IFile File, DateTime DateTime)
        {
            nome = Nome;
            file = File;
            dateTime = DateTime;
        }
    }
    class CartellaFoti
    {
        public DateTime DataUltimaLettura;
        public SortedList<string, Foto> DateTrovateVecchie = new SortedList<String, Foto>();
        public SortedList<string, Foto> DateTrovateNuove = new SortedList<String, Foto>();
        //public SortedList<DateTime, Avvenimento> elencoDateFotiCompleta = new SortedList<DateTime, Avvenimento>();
        //public SortedList<DateTime, Avvenimento> elencoDateFotiNuove = new SortedList<DateTime, Avvenimento>();
        public CartellaFoti(DateTime dataUltimaLettura)
        { DataUltimaLettura = dataUltimaLettura; }
    }
    class DispositivoRemoto
    {
        SortedList<string, CartellaFoti> CartelleFoto = new SortedList<string, CartellaFoti>();
        // SortedList<string, DateTime> DateTrovate = new SortedList<string, DateTime>();
        IDrive idrive;
        DateTime DataUltimaLetturaFoto;
        public string FormatoData;
        public string NomeCartellaContenenteLeFoto;
        public string NomeDispositivo;
        public string IdentificatoreUnico;
        public string IdentificatoreTipoDispositivo;
        public int NumeroFotiNuove;
        public int NumeroFotiVecchie;
        public STATO_DISPOSITIVO statoDispositivo = STATO_DISPOSITIVO.DA_ESAMINARE;
        AndamentoAttivita andamento = new AndamentoAttivita();

        public bool Esamina(IDrive _idrive)
        {
            idrive = _idrive;
            IdentificatoreUnico = idrive.unique_id;
            IdentificatoreTipoDispositivo = idrive.friendly_name;
            // Variabili.tracciaMessaggi("trovato dispositivo: " + IdentificatoreTipoDispositivo);
            var t = Task.Run(() => taskEsamina());
            return true;
        }
        void taskEsamina()
        {
            bool trovato = false;
            // LeggiInfoDaDevice(idrive);
            if (!LeggiInfoDevice())
            {
                // dispositivo non classificato
                andamento.memoriaNomeAttivita = IdentificatoreTipoDispositivo;
                Variabili.tracciaMessaggi(andamento, "da classificare", false);
                Variabili.tracciaMessaggi("trovato nuovo dispositivo da catalogare di tipo: " + IdentificatoreTipoDispositivo);
                statoDispositivo = STATO_DISPOSITIVO.DA_CATALOGARE;
            }
            else
            {
                if (CartelleFoto.Count != 0)
                {
                    andamento.memoriaNomeAttivita = NomeDispositivo;
                    Variabili.tracciaMessaggi(andamento, "lettura foto", false);
                    Variabili.tracciaMessaggi("trovato dispositivo: " + IdentificatoreTipoDispositivo);
                    Variabili.Passo = Passi.RicercaNuoveFoto;
                    Variabili.DispositivoPrincipale = this;
                    // cerca foto nuove su camera
                    trovato |= LeggiDateFotoRemoto();
                    Variabili.Passo = Passi.LetturaNuoveFoto;
                    LeggiNuoveFotoDaRemoto();
                    Variabili.Passo = Passi.ConclusaLetturaNuoveFoto;
                    if (NumeroFotiNuove == 0)
                        Variabili.tracciaMessaggi(andamento, "non trovate foto nuove", false);
                    else Variabili.tracciaMessaggi(andamento, "lette " + NumeroFotiNuove + " foto nuove", false);
                    // modifica temporaneo 
                    AggiornaInfoDevice();
                }
                /*provvisorio
                 * else
                {
                    if (CercaCartellaCamera(_idrive))
                    {
                        //return n;
                    }
                }*/
            }
        }
        bool CercaCartellaCamera(IDrive d)
        {
            bool found = false;
            foreach (var child in d.folders)
            {
                if (CercaCartellaCameraRecursive(child))
                    return true;
            }
            return found;
        }
        bool CercaCartellaCameraRecursive(IFolder folder)
        {
            bool found = false;
            if (folder.name.ToUpper() == "CAMERA")
            {
                found = true;
            }
            else
            {
                foreach (var child in folder.child_folders)
                {
                    if (CercaCartellaCameraRecursive(child))
                        return true;
                }
            }
            return found;
        }
        #region LEGGI_INFO_FILE_REMOTO
        bool LeggiInfoDevice()
        {
            bool res = AnalizzaPreferenzeDispositivo(@"c:/foto/InfoFotografo/" + IdentificatoreUnico + ".txt");
            return res;
        }
        bool AggiornaInfoDevice()
        {
            bool res = false;
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"c:/foto/InfoFotografo/" + IdentificatoreUnico + ".txt", false))
            {
                //cartella_foto | Memoria condivisa interna\DCIM\Camera | 2019_10_01
                file.WriteLine("cartella_foto|" +
                            NomeCartellaContenenteLeFoto + "|" +
                            DateTime.Today.Year.ToString("D4") + "_" +
                            DateTime.Today.Month.ToString("D2") + "_" +
                            DateTime.Today.Day.ToString("D2"));
                //nome_dispositivo | telefono Carlo
                file.WriteLine("nome_dispositivo|" + NomeDispositivo);
                //formato_data | IMG:AAAA_MM_GG: HH_MM_SS file.WriteLine("Fourth line");
                file.WriteLine("formato_data|" + FormatoData);
            }
            return res;
        }
        bool LeggiInfoDaDevice(IDrive d)
        {
            bool res = false;
            foreach (var child in d.folders)
            {
                if (child.name == "Memoria condivisa interna")
                {
                    res |= LeggiInfoDaDevice(child);
                    if (res)
                        break;
                }
            }
            return res;
        }
        bool LeggiInfoDaDevice(IFolder d)
        {
            bool res = false;
            foreach (var child in d.files)
            {
                if (child.name == "InfoFotografo.txt")
                {
                    // leggi contenuto file
                    res |= AnalizzaFileInfo(child);
                    if (res)
                        break;
                }
            }
            return res;
        }
        bool AnalizzaFileInfo(IFile sorgenteRemoto)
        {
            bool res = false;
            sorgenteRemoto.copy_sync(Utility.TempPath);
            res = AnalizzaPreferenzeDispositivo(Utility.TempPath + @"\" + sorgenteRemoto.name);
            return res;
        }

        private bool AnalizzaPreferenzeDispositivo(string sorgente)
        {
            bool res = false;
            try
            {
                string[] lines = System.IO.File.ReadAllLines(sorgente);
                foreach (var line in lines)
                {
                    try
                    {
                        string[] lineSplit = line.Split('|');
                        switch (lineSplit[0])
                        {
                            case "cartella_foto":
                                int anno, mese, giorno;
                                string[] dataSplit = lineSplit[2].Split('_');
                                anno = Int32.Parse(dataSplit[0]);
                                mese = Int32.Parse(dataSplit[1]);
                                giorno = Int32.Parse(dataSplit[2]);
                                DataUltimaLetturaFoto = new DateTime(anno, mese, giorno);
                                NomeCartellaContenenteLeFoto = lineSplit[1];
                                CartellaFoti cartellaFoti = new CartellaFoti(DataUltimaLetturaFoto);
                                Variabili.DataLetturaFotoPrecedente = DataUltimaLetturaFoto;
                                CartelleFoto.Add(lineSplit[1], cartellaFoti);
                                res = true;
                                break;
                            case "nome_dispositivo":
                                NomeDispositivo = lineSplit[1];
                                //Variabili.tracciaMessaggi(andamento, NomeDispositivo, false);
                                Variabili.tracciaMessaggi(andamento, "data base creato", true);
                                Variabili.tracciaMessaggi(IdentificatoreTipoDispositivo + " è registrato come: " + NomeDispositivo);
                                break;
                            case "formato_data":
                                FormatoData = lineSplit[1];
                                break;
                        }
                    }
                    catch { }
                }
            }
            catch { }
            return res;
        }
        #endregion
        #region LEGGI_FOTO_DA_REMOTO
        bool LeggiDateFotoRemoto()
        {
            bool trovato = false;
            foreach (KeyValuePair<string, CartellaFoti> cartella in CartelleFoto)
            {
                string percorso = cartella.Key;
                var cartellaFoto = CercaCartellaIndicata(percorso);
                if (cartellaFoto != null)
                {
                    CalcolaDateCartellaRemota(cartellaFoto, cartella.Value);
                    trovato = true;
                }
            }
            return trovato;
        }
        IFolder CercaCartellaIndicata(string percorso)
        {
            IFolder result = null;
            string[] cartellePercorso = percorso.Split('\\');
            if (idrive.folders.Count() > 0)
            {
                foreach (var child in idrive.folders)
                {
                    if (child.name == cartellePercorso[0])
                    {
                        foreach (var child1 in child.child_folders)
                        {
                            if (child1.name == cartellePercorso[1])
                            {
                                foreach (var child2 in child1.child_folders)
                                {
                                    if (child2.name == cartellePercorso[2])
                                    {
                                        result = child2;
                                        return result;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
        bool CalcolaDateCartellaRemota(IFolder folder, CartellaFoti cartellaFoti)
        {
            Variabili.tracciaMessaggi("ultima lettura foto da " + NomeDispositivo + " il giorno " +
                DataUltimaLetturaFoto.Day.ToString("D2") + " " +
                DataUltimaLetturaFoto.Month.ToString("D2") + " " + 
                DataUltimaLetturaFoto.Year.ToString("D4"));
            foreach (var file in folder.files)
            {
                string nomeFile = file.name;
                DateTime dt = new DateTime();
                //SetDataOra sdo = new SetDataOra();
                dt = file.last_write_time;
                DateTime dt1 = new DateTime(dt.Year, dt.Month, dt.Day);
                Foto foto = new Foto(nomeFile, file, dt);
                if (dt > DataUltimaLetturaFoto)
                {
                    cartellaFoti.DateTrovateNuove.Add(nomeFile, foto);
                    /*if (!Variabili.calendario.elencoDateFotiNuove.ContainsKey(dt1))
                        Variabili.calendario.elencoDateFotiNuove.Add(dt1, dt1);*/
                    Variabili.Passo = Passi.TrovateNuoveFoto;
                    //nuoveDate = true;
                }
                else cartellaFoti.DateTrovateVecchie.Add(nomeFile, foto);
            }
            /* provvisorio 27 1 21
             * if (nuoveDate)
                Variabili.MostraCalendartioNuoveFoto = true; */
            if (cartellaFoti.DateTrovateNuove.Count == 0)
                Variabili.tracciaMessaggi("in " + NomeDispositivo + " non sono state trovate foto nuove");
            Variabili.tracciaMessaggi("in " + NomeDispositivo + " trovate " + cartellaFoti.DateTrovateNuove.Count + " nuove foto");
            if (cartellaFoti.DateTrovateVecchie.Count != 0)
                Variabili.tracciaMessaggi("in " + NomeDispositivo + " sono presenti " + cartellaFoti.DateTrovateVecchie.Count + " foto già scaricate");
            return true;
        }
        void LeggiNuoveFotoDaRemoto()
        {
            foreach (KeyValuePair<string, CartellaFoti> cartella in CartelleFoto)
            {
                string evento = "";
                string percorso = cartella.Key;
                var cartellaFoto = CercaCartellaIndicata(percorso);
                int nonCopiata = 0;
                if (cartellaFoto != null)
                {
                    foreach (var fotoRemota in cartella.Value.DateTrovateNuove)
                    {
                        Foto foto = fotoRemota.Value;
                        IFile fileFoto = foto.file;
                        DateTime data = foto.dateTime;
                        string pathTrovato = "";
                        SetDataOraBase sdob = Variabili.Calendario.getData(data);
                        string percorsoFoto;
                        if (sdob != null)
                        {
                            // data già presente
                            percorsoFoto = sdob.nomeCompletoCartella;
                        }
                        else
                        {
                            percorsoFoto = Variabili.Calendario.CalcolaNomeCartella(data, "");
                            if (!Directory.Exists(percorsoFoto))
                            {
                                Directory.CreateDirectory(percorsoFoto);
                            }
                        }
                        fileFoto.copy_sync(percorsoFoto);
                        NumeroFotiNuove++;
                        /*if (Variabili.operazioniSuPc.CercaDataInCartelle(data, ref evento, ref pathTrovato))
                        {
                            // cartella già presente
                            if (data > DataUltimaLetturaFoto)
                            {
                                fileFoto.copy_sync(pathTrovato);
                                NumeroFotiNuove++;
                            }
                            else
                            {
                                nonCopiata++;
                                NumeroFotiVecchie++;
                            }
                        }
                        else
                        {
                            // cartella da creare
                            string nomeCartella = Variabili.operazioniSuPc.CreaCartella("", data);
                            fileFoto.copy_sync(nomeCartella);
                            NumeroFotiNuove++;
                        }*/
                    }
                }
            }
            Variabili.tracciaMessaggi("da " + NomeDispositivo + " lette " + NumeroFotiNuove + " foto");
        }
        #endregion
    }
}
