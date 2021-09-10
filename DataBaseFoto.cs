using FotoOrganizzatore.Classi_statiche;
using FotoOrganizzatore.Dialogs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoOrganizzatore
{
    public class DataBaseFoto
    {
        int doppie = 0;
        public SortedList<DateTime, string> elencoFotoPerData = new SortedList<DateTime, string>();
        public SortedList<string , DateTime> elencoFotoPerNome = new SortedList<string, DateTime>();
        public SortedList<long, List<string>> elencoFotoPerDimensione = new SortedList<long, List<string>>();
        public SortedList<int, String> anni = new SortedList<int, string>();
        public SortedList<int, Anno> anniComponenti = new SortedList<int, Anno>();
        public SortedList<string, List<DateTime>> classificazioni = new SortedList<string, List<DateTime>>();
        public List<string> elencoFotoNuovaClassificazione = new List<string>();
        //public SortedList<string, CartellaBase> cartelleSpeciali = new SortedList<string, CartellaBase>();
        public string pathBase;
        public string pathFotoDoppie;
        AndamentoAttivita andamento = new AndamentoAttivita();
        public DataBaseFoto(string path, string cartellaDoppie)
        {
            pathBase = path;
            pathFotoDoppie = cartellaDoppie;
        }
        public void pubblicaAndamentoInFinestra(string nomeAttivita)
        {
            //if (!dove.Controls.Contains(andamento))
            //{
                andamento.nomina(nomeAttivita);
              //  dove.Controls.Add(andamento);
            //}
        }
        public bool creaDataBase(Calendario calendario)
        {
            return creaDataBase(calendario, 0);
        }
        public bool creaDataBase(Calendario calendario, int saltaGiri)
        {
            bool res = false;
            Variabili.tracciaMessaggi(andamento, "start creazione data base",true);
            ProcessDirectory(pathBase,calendario,saltaGiri);
            calendario.aggiungiDateACalendarioComplessivo();
            Variabili.tracciaMessaggi(andamento, "data base creato",true);
            Variabili.tracciaMessaggi("classificate per data " + elencoFotoPerData.Count + " in " + pathBase);
            Variabili.tracciaMessaggi("classificate per nome " + elencoFotoPerNome.Count + " in " + pathBase);
            Variabili.tracciaMessaggi("classificate per dimensione " + elencoFotoPerDimensione.Count + " in " + pathBase);
            return res;
        }
        void ProcessDirectory(string dir, Calendario calendario, int saltaGiri)
        {
            if (!dir.StartsWith("c:"))
                ;
            Variabili.tracciaMessaggi(andamento, "analisi cartella " + dir, Preferenze.verboso);
            string[] fileEntries;
            DateTime dataTime = new DateTime();
            string commentoProposto = "";
            // verifica correttezza nome cartella
            string[] dirScomposto = dir.Replace("/", "\\").Split('\\');
            if (saltaGiri <= 0)
            {
                switch (dirScomposto.Length)
                {
                    case 3:   // a questo livello possono esserci anni o cartelle speciali
                              // verifica cosa è
                        int annoForse;
                        if (Int32.TryParse(dirScomposto[2], out annoForse))
                        {
                            // anno
                            if (!anni.ContainsKey(annoForse))
                            {
                                anni.Add(annoForse, dirScomposto[2]);
                                Anno anno = new Anno();
                                anno.setNomeAnno(dirScomposto[2]);
                                anniComponenti.Add(annoForse, anno);
                            }
                        }
                        else
                        {
                            // cartella speciale
                            if (dirScomposto[2] != "InfoFotografo")
                            {
                                //if (!cartelleSpeciali.ContainsKey(dirScomposto[2]))
                                //{
                                //CartellaBase cb = new CartellaBase();
                                //cartelleSpeciali.Add(dirScomposto[2], cb);
                                calendario.AggiungiCartellaSpeciale(dirScomposto[2], dir);
                                return;
                                //}
                            }
                        }
                        break;
                    case 4:   // a questo livello possono esserci avvenimenti (date e commento) 
                              // o altro se si parte da vcartella speciale
                        DateTime inizio = new DateTime(),
                                 fine = new DateTime();
                        string b = "";
                        if (Utility.CalcolaDateTimeDaPath(dirScomposto, ref inizio, ref fine, ref b))
                        {
                            // nome cartella corretto
                            ;
                        }
                        else
                        {
                            // nome cartella errato, cerca le date dei file presenti in cartella
                            // todo : considerare il caso di cartella vuota
                            fileEntries = Directory.GetFiles(dir);
                            DateTime dataMinima = new DateTime(3000, 1, 1);
                            DateTime dataMassima = new DateTime(1, 1, 1);
                            foreach (string fileName in fileEntries)
                            {
                                if (Utility.CalcolaDateTimeFileImmagine(fileName, ref dataTime))
                                {
                                    if (dataTime > dataMassima)
                                        dataMassima = dataTime;
                                    if (dataTime < dataMinima)
                                        dataMinima = dataTime;
                                }
                            }
                            // calcola commento proposto
                            string[] commento = dirScomposto[3].Split(' ');
                            bool notNumber = false;
                            for (int n = 0; n < commento.Length; n++)
                            {
                                if ((!Utility.isNumber(commento[n])) ||
                                    (notNumber))
                                {
                                    notNumber = true;
                                    if (commentoProposto != "")
                                        commentoProposto += " ";
                                    commentoProposto += commento[n];
                                }
                            }
                            // verificare se le foto sono nell'anno giusto!
                            // per es. la cartella c:\foto\2005\brescia 18-6-05\
                            // contiene foto con data 2002
                            RinominaCartella aub = new RinominaCartella();
                            aub.setnomeErratoCartella(dir);
                            string dataMin = dataMinima.ToShortDateString();
                            string dataMax = dataMassima.ToShortDateString();
                            aub.setdataMinimaMassima(dataMin, dataMax);
                            aub.setnomeCommentoProposto(dataMinima, dataMassima, commentoProposto);
                            // aub.inizializza(drive, label, numeroDiSerie);
                            DialogResult dr;
                            //aub.Size = new Size(650, 300);
                            //aub.Size = new System.Drawing.Size(480, 370);
                            dr = aub.ShowDialog();
                            if ((dr == DialogResult.OK) || (dr == DialogResult.Yes))
                            {
                                // correggi
                                string nomeCompleto;
                                if (aub.getAnnoModificato())
                                {
                                    nomeCompleto = pathBase + "\\" + aub.getNome();
                                }
                                else
                                {
                                    nomeCompleto = pathBase + "\\" + dirScomposto[2] + "\\" + aub.getNome();
                                }
                                string commentoFinale = aub.getCommento();
                                if (commentoFinale != "")
                                    nomeCompleto += " " + commentoFinale;
                                Utility.MuoviCartella(dir, nomeCompleto);
                                dir = nomeCompleto;
                            }
                            else
                            {
                                ; // crea cartella speciale
                            }
                        }
                        break;
                }
            }
            fileEntries = Directory.GetFiles(dir);
            if (saltaGiri <= 0)
            {
                if (fileEntries.Length != 0)
                {
                    // crea calendario
                    // Variabili.Calendario.AggiungiData(fileEntries[0], dir);
                    calendario.AggiungiData(fileEntries[0], dir);
                }
            }
            foreach (string fileName in fileEntries)
            {
                ProcessFile(fileName);
            }
            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            foreach (string subdirectory in subdirectoryEntries)
            {
                if (saltaGiri > 0)
                {
                    string[] dirSplit = subdirectory.Split('\\');
                    string nome = dirSplit[dirSplit.Length - 1];
                    calendario.AggiungiCartellaSpeciale(nome, subdirectory);
                }
                else
                {
                    ProcessDirectory(subdirectory, calendario, saltaGiri - 1);
                }
            }
        }
        public void ProcessFile(string path)
        {
            string estensione = path.Substring(path.LastIndexOf('.') + 1);
            if ((estensione != "txt") && (estensione != "db") && (estensione != "ini"))
            {
                //controllaNormalizzaNomeFile(path);
                //aggiungiFoto(path);
                DateTime dt = new DateTime();
                controllaNormalizzaNomeFile(path, ref dt);
            }
        }
        public bool verificaPresenzaFoto(string nomeFoto)
        {
            bool res = false;
            if (File.Exists(nomeFoto))
            {
                var info = new FileInfo(nomeFoto);
                long lunghezza = info.Length;
                List<string> lista1;
                if (elencoFotoPerDimensione.ContainsKey(lunghezza))
                {
                    lista1 = elencoFotoPerDimensione[lunghezza];
                    // confronta per contenuto
                    foreach(string nomeFile in lista1)
                    {
                        if (Utility.ConfrontaFile(nomeFoto,nomeFile))
                        {
                            // foto doppia
                            res = true;
                            break;
                        }
                        else
                        {
                            // foto diversa
                        }
                    }
                }
            }
            return res;
        }
        bool aggiungiFoto(DateTime dt, string path)
        {
            bool result = false;
            if (File.Exists(path))
            {
                var info = new FileInfo(path);
                long lunghezza = info.Length;
                result = aggiungiFoto(lunghezza, path);
                //result = aggiungiFoto(info.Name, path);
                aggiungiFotoNomi(dt, path);
            }
            return result;
        }
        bool aggiungiFotoNomi(DateTime dataFoto, string path)
        {
            bool result = false;
            if (!elencoFotoPerData.ContainsKey(dataFoto))
            {
                elencoFotoPerData.Add(dataFoto, path);
                elencoFotoPerNome.Add(path, dataFoto);
                result = true;
            }
            return result;
        }
        bool aggiungiFoto(long dimensione, string path)
        {
            bool result = false;
            List<string> lista1;
            if (!elencoFotoPerDimensione.ContainsKey(dimensione))
            {
                lista1 = new List<string>();
                elencoFotoPerDimensione.Add(dimensione, lista1);
            }
            else
            {
                lista1 = elencoFotoPerDimensione[dimensione];
            }
            lista1.Add(path);
            return result;
        }
        public bool togliFoto(DateTime dt, string nome)
        {
            bool res = false;
            long dimensione;
            if (elencoFotoPerData.ContainsKey(dt))
            {
                elencoFotoPerData.Remove(dt);
            }
            if (elencoFotoPerNome.ContainsKey(nome))
            {
                elencoFotoPerNome.Remove(nome);
            }
            var info = new FileInfo(nome);
            dimensione = info.Length;
            if (elencoFotoPerDimensione.ContainsKey(dimensione))
            {
                List<string> elenco = elencoFotoPerDimensione[dimensione];
                if (elenco.Contains(nome))
                {
                    elenco.Remove(nome);
                    if (elenco.Count == 0)
                    {
                        elencoFotoPerDimensione.Remove(dimensione);
                    }
                }
            }
            return res;
        }
        void controllaNormalizzaNomeFile(string fileName, ref DateTime dt)
        {
            string nomeTrattato = "";
            string nomeSoloFile = fileName.Substring(fileName.LastIndexOf('\\') + 1);
            string[] nome = nomeSoloFile.Split('.');
            bool nomeFileCorretto = false;
            nomeFileCorretto = Funzioni.verificaCorrettezzaNomeFile(nome[0], ref dt);
            if (!nomeFileCorretto)
            {
                FileImmagini.CalcolaMomentoScattoFoto(fileName, ref dt);
            }
            else
            {
                Utility.CalcolaDateTimeDaNomeFile(nomeSoloFile, ref dt);
            }
            // verifica se la data è univoca
            if (elencoFotoPerData.ContainsKey(dt))
            {
                nomeFileCorretto = false;
                bool fine = false;
                DateTime dt1 = dt;
                while (fine == false)
                {
                    dt1 = dt1.AddSeconds(1);
                    if (!elencoFotoPerData.ContainsKey(dt1))
                    {
                        dt = dt1;
                        fine = true;
                    }
                }
            }
            if (!nomeFileCorretto)
            {
                string nomeNuovo = Funzioni.nomeFileDaDateTime(dt);
                string inizio = fileName.Substring(0, fileName.LastIndexOf('\\'));
                string estensione = fileName.Substring(fileName.LastIndexOf('.'));
                string nuovoNome = inizio + "\\" + nomeNuovo + estensione;
                // rinominare il file!
                // tracciare nel file di report
                // verificare se esite il file, se esiste già ricalcolare data e ora come sopra
                while (File.Exists(nuovoNome))
                {
                    dt = dt.AddSeconds(1);
                    nomeNuovo = Funzioni.nomeFileDaDateTime(dt);
                    nuovoNome = inizio + "\\" + nomeNuovo + estensione;
                }
                if (fileName != nuovoNome)
                {
                    File.Move(fileName, nuovoNome);
                    fileName = nuovoNome;
                }
            }
            elencoFotoPerData.Add(dt, fileName);
            elencoFotoPerNome.Add(fileName, dt);
            aggiungiFoto(dt, fileName);
        }
        public string rinominaFotoInserisciInDB(DateTime dt, string nomeVecchio)
        {
            if (elencoFotoPerData.ContainsKey(dt))
            {
                //nomeFileCorretto = false;
                bool fine = false;
                DateTime dt1 = dt;
                while (fine == false)
                {
                    dt1 = dt1.AddSeconds(1);
                    if (!elencoFotoPerData.ContainsKey(dt1))
                    {
                        dt = dt1;
                        fine = true;
                    }
                }
            }
            //if (!nomeFileCorretto)
            //{
                string nomeNuovo = Funzioni.nomeFileDaDateTime(dt);
                string inizio = nomeVecchio.Substring(0, nomeVecchio.LastIndexOf('\\'));
                string estensione = nomeVecchio.Substring(nomeVecchio.LastIndexOf('.'));
                string nuovoNome = inizio + "\\" + nomeNuovo + estensione;
                // rinominare il file!
                // tracciare nel file di report
                File.Move(nomeVecchio, nuovoNome);
                nomeVecchio = nuovoNome;
            //}
            elencoFotoPerData.Add(dt, nomeVecchio);
            elencoFotoPerNome.Add(nomeVecchio, dt);
            aggiungiFoto(dt, nomeVecchio);
            return nomeVecchio;
        }
        bool verificaDateTimeInPath(string fileName)
        {
            bool result = false;
            DateTime dt = new DateTime();
            string conclusione = "", commento = "";
            result = Utility.CalcolaDateTimeDaStringa(fileName, ref dt, ref conclusione, ref commento);
            return result;
        }
        string normalizzaNomeFile(string fileName)
        {
            // todo
            return fileName;
        }
        public bool classificaFoto(string nomeFile)
        {
            bool res = false;
            string[] dirScomposto = nomeFile.Replace("/", "\\").Split('\\');
            DateTime data = new DateTime();
            string b = "";
            string nome = nomeFile.Replace("/", "\\").Substring(nomeFile.LastIndexOf("\\") + 1);
            if (Utility.CalcolaDateTimeDaNomeFile(nome, ref data))
            {
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
                string nomeFileNuovo = percorsoFoto + "\\" + dirScomposto[dirScomposto.Length - 1];
                controllaNormalizzaNomeFile(nomeFileNuovo, ref data);
                // File.Move(nomeFile, nomeFileNuovo);
            }
            else
            {
                // nome file non corretto
                /*if (CalcolaDateTimeFileImmagine(nome, ref data))
                {
                    ;
                }*/
                ;
            }
            return res;
        }

    }
}
