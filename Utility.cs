using external_drive_lib.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoOrganizzatore
{
    static class Utility
    {
        public static string TempPath { get; set; } = New_temp_path;
        private static string New_temp_path
        {
            get
            {
                var temp_dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\";
                if (Directory.Exists(temp_dir + "Temp"))
                    temp_dir += "Temp\\";
                temp_dir += "external_drive_temp\\temp-" + DateTime.Now.Ticks;

                Directory.CreateDirectory(temp_dir);
                return temp_dir;
            }
        }
        #region DATA_DA_STRINGA
        public static bool CalcolaDateTimeDaNomeFile(string nomeFile, ref DateTime data)
        {
            bool res = false;
            int anno, mese, giorno;
            int ora, minuto, secondo;
            string[] nomeSplit = nomeFile.Split('_');
            string annoS = nomeSplit[1].Substring(0, 4);
            string meseS = nomeSplit[1].Substring(4, 2);
            string giornoS = nomeSplit[1].Substring(6, 2);
            string oraS = nomeSplit[2].Substring(0, 2);
            string minutoS = nomeSplit[2].Substring(2, 2);
            string secondoS = nomeSplit[2].Substring(4, 2);
            if (Int32.TryParse(annoS, out anno) &&
                Int32.TryParse(meseS,out mese) &&
                Int32.TryParse(giornoS,out giorno) &&
                Int32.TryParse(oraS,out ora) &&
                Int32.TryParse(minutoS,out minuto) &&
                Int32.TryParse(secondoS,out secondo))
            {
                data = new DateTime(anno, mese, giorno,ora,minuto,secondo);
                res = true;
            }
            return res;
        }
        public static bool CalcolaDateTimeDaPath(string[] fileFotoSplit, ref DateTime inizio, ref DateTime fine, ref string commento)
        {
            int anno, mese, giorno = 1;
            int annoFine = 0, meseFine = 0, giornoFine = 0;
            bool res = false;
            bool fineUgualeInizio = false;
            bool fineCorretta = false;
            try
            {
                if (fileFotoSplit.Length >= 4)
                {
                    if (Int32.TryParse(fileFotoSplit[2], out anno))
                    {
                        string[] meseGiorno = fileFotoSplit[3].Split(' ');
                        if (Int32.TryParse(meseGiorno[0], out mese))
                        {
                            bool giornoCorretto = false;
                            if (meseGiorno[1].Contains('_'))
                            {
                                // evento su più di un giorno
                                string[] giornoMultiplo = meseGiorno[1].Split('_');
                                switch (giornoMultiplo.Length)
                                {
                                    case 2: // contiene giorno inizio e giorno fine
                                        if ((Int32.TryParse(giornoMultiplo[0], out giorno)) &&
                                            (Int32.TryParse(giornoMultiplo[1], out giornoFine)))
                                        {
                                            annoFine = anno;
                                            meseFine = mese;
                                            fineCorretta = true;
                                        }
                                        break;
                                    case 3: // contiene giorno inizio, mese e giorno fine
                                        if ((Int32.TryParse(giornoMultiplo[0], out giorno)) &&
                                            (Int32.TryParse(giornoMultiplo[1], out meseFine)) &&
                                            (Int32.TryParse(giornoMultiplo[2], out giornoFine)))
                                        {
                                            annoFine = anno;
                                            fineCorretta = true;
                                        }
                                        break;
                                    case 4: // contiene giorno inizio, anno, mese e giorno fine
                                        if ((Int32.TryParse(giornoMultiplo[0], out giorno)) &&
                                            (Int32.TryParse(giornoMultiplo[1], out annoFine)) &&
                                            (Int32.TryParse(giornoMultiplo[2], out meseFine)) &&
                                            (Int32.TryParse(giornoMultiplo[3], out giornoFine)))
                                            fineCorretta = true;
                                        break;
                                }
                                if (fineCorretta)
                                {
                                    fine = new DateTime(annoFine, meseFine, giornoFine);
                                    giornoCorretto = true;
                                }
                                /*fine = giornoMultiplo[1];
                                for (int n = 2; n < giornoMultiplo.Length; n++)
                                {
                                    // evento su più mesi o anni
                                    fine += " " + giornoMultiplo[n];
                                }
                                if (Int32.TryParse(giornoMultiplo[0], out giorno))
                                    giornoCorretto = true;*/
                            }
                            else
                            {
                                fineUgualeInizio = true;
                                if (Int32.TryParse(meseGiorno[1], out giorno))
                                    giornoCorretto = true;
                            }
                            if (meseGiorno.Length > 2)
                            {
                                commento += meseGiorno[2];
                                for (int n = 3; n < meseGiorno.Length; n++)
                                {
                                    commento += " " + meseGiorno[n];
                                }
                            }
                            if (giornoCorretto)
                            {
                                inizio = new DateTime(anno, mese, giorno);
                                if (fineUgualeInizio)
                                    fine = inizio;
                                res = true;
                            }
                        }
                    }
                }
            }
            catch
            {
                // tracciare l'errore nel calcolo della data
                ;
            }
            return res;
        }
        public static bool CalcolaDateTimeDaStringa(string nomeFile, ref DateTime dateTime, ref string conclusione, ref string commento)
        {
            int anno, mese, giorno;
            bool res = false;
            try
            {
                string[] fileFotoSplit = nomeFile.Split('\\');
                if (fileFotoSplit.Length == 5)
                {
                    if (Int32.TryParse(fileFotoSplit[2], out anno))
                    {
                        string[] meseGiorno = fileFotoSplit[3].Split(' ');
                        if (Int32.TryParse(meseGiorno[0], out mese))
                        {
                            bool giornoCorretto = false;
                            if (meseGiorno[1].Contains('_'))
                            {
                                // evento su più di un giorno
                                string[] giornoMultiplo = meseGiorno[1].Split('_');
                                conclusione = giornoMultiplo[1];
                                for (int n = 2; n < giornoMultiplo.Length; n++)
                                {
                                    // evento su più mesi o anni
                                    conclusione += " " + giornoMultiplo[n];
                                }
                                if (Int32.TryParse(giornoMultiplo[0], out giorno))
                                    giornoCorretto = true;
                            }
                            else
                            {
                                if (Int32.TryParse(meseGiorno[1], out giorno))
                                    giornoCorretto = true;
                            }
                            if (meseGiorno.Length > 2)
                            {
                                commento += meseGiorno[2];
                                for (int n = 3; n < meseGiorno.Length; n++)
                                {
                                    commento += " " + meseGiorno[n];
                                }
                            }
                            if (giornoCorretto)
                            {
                                dateTime = new DateTime(anno, mese, giorno);
                                res = true;
                            }
                        }
                    }
                }
            }
            catch
            {
                // tracciare l'errore nel calcolo della data
                ;
            }
            return res;
        }
        public static bool CalcolaDateTimeDaStringa(string anno, string data, ref DateTime dateTime, ref string conclusione, ref string commento)
        {
            bool res = false;
            conclusione = "";
            try
            {
                int annoInt, meseInt, giornoInt;
                _ = Int32.TryParse(anno, out annoInt);
                string[] dataGiorno = data.Split(' ');
                _ = Int32.TryParse(dataGiorno[0], out meseInt);
                if (!dataGiorno[1].Contains("_"))
                {
                    _ = Int32.TryParse(dataGiorno[1], out giornoInt);
                }
                else
                {
                    string[] giornoMultiplo = dataGiorno[1].Split('_');
                    _ = Int32.TryParse(giornoMultiplo[0], out giornoInt);
                    conclusione = giornoMultiplo[1];
                    for (int n = 2; n < giornoMultiplo.Length; n++)
                    {
                        conclusione += " " + giornoMultiplo[n];
                    }
                }
                if (dataGiorno.Length > 2)
                {
                    commento += dataGiorno[2];
                    for (int n = 3; n < dataGiorno.Length; n++)
                    {
                        commento += " " + dataGiorno[n];
                    }
                }
                dateTime = new DateTime(annoInt, meseInt, giornoInt);
                res = true;
            }
            catch { }
            return res;
        }
        #endregion
        #region DATA_DA_FILE_IMMAGINE
        public static bool CalcolaDateTimeFileImmagine(string nomeFile, ref DateTime dt)
        {
            bool res = false;
            string conclusione = "",
                commento = "";
            res = Utility.CalcolaDateTimeDaStringa(nomeFile, ref dt, ref conclusione, ref commento);
            if (!res)
            {
                // il nome della foto potrebbe non contenere la data
                if (FileImmagini.CalcolaMomentoScattoFoto(nomeFile, ref dt))
                    res = true;
            }
            return res;
        }
        #endregion
        #region NOME_CARTELLA_DA_DATA
        public static string CalcolaNomeCartella(DateTime dataInizio, DateTime dataFine)
        {
            return CalcolaNomeCartella(dataInizio, dataFine, "");
        }
        public static string CalcolaNomeCartella(DateTime dataInizio, DateTime dataFine, string commento)
        {
            string nomeCartella = dataInizio.Month.ToString("D2") + " " +
                                    dataInizio.Day.ToString("D2");
            if (dataInizio.ToShortDateString() != dataFine.ToShortDateString())
            {
                nomeCartella += "_";
                if (dataInizio.Year != dataFine.Year)
                {
                    nomeCartella += dataFine.Year.ToString("D4") + "_";
                    nomeCartella += dataFine.Month.ToString("D2") + "_";
                }
                else
                {
                    if (dataInizio.Month != dataFine.Month)
                    {
                        nomeCartella += dataFine.Month.ToString("D2") + "_";
                    }
                }
                nomeCartella += dataFine.Day.ToString("D2");
            }
            if (commento != "")
                nomeCartella += " " + commento;
            return nomeCartella;
        }
        #endregion
        #region DISCO
        public static bool ConfrontaFile(string file1, string file2)
        {
            // confronta due file della stessa dimensione
            bool res = false;
            Int64 a, b;
            try
            {
                if ((File.Exists(file1)) && (File.Exists(file2)))
                {
                    res = true;
                    BinaryReader binaryReader1 = new BinaryReader(File.OpenRead(file1));
                    BinaryReader binaryReader2 = new BinaryReader(File.OpenRead(file2));
                    while (1 == 1)
                    {
                        a = binaryReader1.ReadInt64();
                        b = binaryReader2.ReadInt64();
                        if (a != b)
                        {
                            res = false;
                            break;
                        }
                    }
                }
            }
            catch { }
            return res;
        }
        public static string CreaCartella(string disco, string nome)
        {
            string nomeCompleto = disco + @"/" + nome;
            try
            {
                if (!Directory.Exists(nomeCompleto))
                {
                    Directory.CreateDirectory(nomeCompleto);
                }
            }
            catch
            {
                nomeCompleto = "";
            }
            return nomeCompleto;
        }
        public static bool CopiaCartella(string sorgente, string destinazione)
        {
            if (sorgente != destinazione)
            {
                if (!Directory.Exists(destinazione))
                {
                    Directory.CreateDirectory(sorgente);
                }
                CopiaCartellainEsistente(sorgente, destinazione);
            }
            return true;
        }
        public static bool MuoviCartella(string sorgente, string destinazione)
        {
            if (sorgente != destinazione)
            {
                if (!Directory.Exists(destinazione))
                {
                    Directory.Move(sorgente, destinazione);
                }
                else
                {
                    MuoviCartellainEsistente(sorgente, destinazione);
                    Directory.Delete(sorgente);
                }
            }
            return true;
        }
        static bool MuoviCartellainEsistente(string sorgente, string destinazione)
        {
            bool result = false;
            List<string> files = new List<string>(Directory.EnumerateFiles(sorgente));
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                string nomeCorto = fi.Name;
                string fileDestinazione = destinazione + "\\" + nomeCorto;
                if (File.Exists(fileDestinazione))
                {
                    // modificare il modo in cui viene creato il nome del file doppio,
                    // non va modificata l'estensione
                    string cartellaDoppie = fileDestinazione.Substring(0, 3) + "doppie";
                    if (!Directory.Exists(cartellaDoppie))
                        Directory.CreateDirectory(cartellaDoppie);
                    string nomeDoppio = cartellaDoppie + "\\" + nomeCorto;
                    int numeroDoppio = 2;
                    string nomeDoppioIntero = nomeDoppio + "." + numeroDoppio;
                    while (File.Exists(nomeDoppioIntero))
                    {
                        numeroDoppio++;
                    }
                    File.Move(file, nomeDoppioIntero);
                }
                else
                {
                    File.Move(file, fileDestinazione);
                }
            }
            return true;
        }
        static bool CopiaCartellainEsistente(string sorgente, string destinazione)
        {
            bool result = false;
            List<string> files = new List<string>(Directory.EnumerateFiles(sorgente));
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                string nomeCorto = fi.Name;
                string fileDestinazione = destinazione + "\\" + nomeCorto;
                if (File.Exists(fileDestinazione))
                {
                    // il file esiste già 
                    // todo: si potrebbe verificare se sono uguali o diversi
                    ;
                }
                else
                {
                    File.Copy(file, fileDestinazione);
                }
            }
            return true;
        }
        public static bool muoviFile(string sorgente, string destinazione)
        {
            bool res = false;
            if (File.Exists(sorgente))
            {
                string cartellaDestinazione = destinazione.Substring(0,destinazione.LastIndexOf('\\'));
                if (!Directory.Exists(cartellaDestinazione))
                {
                    Directory.CreateDirectory(cartellaDestinazione);
                }
                File.Move(sorgente, destinazione);
                res = true;
            }
            return res;
        }
        public static void cancellaFoto(string nomeFile)
        {
            // crea cartella cestino se non esistente
            if (!Directory.Exists(Preferenze.NomeCestino))
            {
                Directory.CreateDirectory(Preferenze.NomeCestino);
            }
            string nomeFilePulito = nomeFile.Substring(nomeFile.LastIndexOf('\\') + 1);
            string nomeFileNuovo = Preferenze.NomeCestino + "\\" + nomeFilePulito;
            File.Move(nomeFile, nomeFileNuovo);
            tracciaInfoRipristiniFotoCancellata(nomeFile, nomeFileNuovo);
            Variabili.MostraFotoInGiorno++;
        }
        public static void ripristinaFoto(string nomeFile)
        {
            // crea cartella cestino se non esistente
            if (Directory.Exists(Preferenze.NomeCestino))
            {
                if (File.Exists(nomeFile))
                {
                    string nomeFileOriginale = recuperaInfoRipristiniFotoCancellata(nomeFile);
                    if (nomeFileOriginale != "")
                    {
                        /*string nomeFilePulito = nomeFile.Substring(nomeFile.LastIndexOf('\\') + 1);
                        string nomeFileNuovo = Preferenze.NomeCestino + "\\" + nomeFilePulito;
                        File.Move(nomeFile, nomeFileNuovo);*/
                        cancellaInfoRipristiniFotoCancellata(nomeFile);
                        muoviFile(nomeFile, nomeFileOriginale);
                        //cancellaInfoRipristiniFotoCancellata(nomeFile);
                    }
                    else
                    {
                        // cataloga senza sapere dove
                        classificaFoto(nomeFile);
                        //cancellaInfoRipristiniFotoCancellata(nomeFile);
                        //cancellaInfoRipristiniFotoCancellata(nomeFile);
                    }
                    Variabili.mostraCartellaSpeciale = true;
                }
            }
        }
        static void tracciaInfoRipristiniFotoCancellata(string originale, string nomeInCestino)
        {
            StreamWriter sw;
            string nomeFileInfo = Preferenze.NomeCestino + @"\InfoResume.txt";
            if (!File.Exists(nomeFileInfo))
            {
                sw = new StreamWriter(nomeFileInfo, false, Encoding.GetEncoding("iso-8859-1"));
            }
            else
            {
                sw = new StreamWriter(nomeFileInfo, true, Encoding.GetEncoding("iso-8859-1"));
            }
            sw.WriteLine(nomeInCestino + ";" + originale);
            sw.Close();
        }
        static bool cancellaInfoRipristiniFotoCancellata(string nomeInCestino)
        {
            bool result = false;
            string[] info = null;
            string nomeFileInfo = Preferenze.NomeCestino + @"\InfoResume.txt";
            if (File.Exists(nomeFileInfo))
            {
                info = File.ReadAllLines(nomeFileInfo);
                ;
                for (int n = 0; n < info.Length; n++)
                {
                    string[] infon = info[n].Split(';');
                    if (infon[0] == nomeInCestino)
                    {
                        info[n] = "";
                        result = true;
                        break;
                    }
                }
            }
            if (result)
            {
                StreamWriter sw = new StreamWriter(nomeFileInfo, false, Encoding.GetEncoding("iso-8859-1"));
                for (int n = 0; n < info.Length; n++)
                {
                    if (info[n] != "")
                    {
                        sw.WriteLine(info[n]);
                    }
                }
                sw.Close();
            }
            return result;
        }
        static string recuperaInfoRipristiniFotoCancellata(string nomeInCestino)
        {
            string originale = "";
            string nomeFileInfo = Preferenze.NomeCestino + @"\InfoResume.txt";
            if (File.Exists(nomeFileInfo))
            {
                string[] info = File.ReadAllLines(nomeFileInfo);
                ;
                for (int n = 0; n < info.Length; n++)
                {
                    string[] infon = info[n].Split(';');
                    if (infon[0] == nomeInCestino)
                    {
                        originale = infon[1];
                        break;
                    }
                }
            }
            return originale;
        }
        #endregion
        public static bool classificaFoto(string nomeFile)
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
                File.Move(nomeFile, nomeFileNuovo);
            }
            return res;
        }
        public static string togliCommentoDaNomeCartella(string nomeConCommento)
        {
            string nomeSenzaCommento = "";
            DirectoryInfo aa = Directory.GetParent(nomeConCommento);
            string nome = nomeConCommento.Substring(aa.ToString().Length + 1);
            string[] nomeScomposto = nome.Split(' ');
            if (nomeScomposto.Length > 2)
            {
                // Commento presente
                nomeSenzaCommento = aa + "\\" + nomeScomposto[0] + " " + nomeScomposto[1];
            }
            else
            {
                // commento assente
                nomeSenzaCommento = nomeConCommento;
            }
            return nomeSenzaCommento;
        }
        public static bool isNumber(string nome)
        {
            int valore;
            return Int32.TryParse(nome, out valore);
        }
    }
}
