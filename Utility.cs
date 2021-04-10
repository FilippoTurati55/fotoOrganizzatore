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
        public static bool muoviFile(string sorgente, string destinazione)
        {
            bool res = false;
            if (File.Exists(sorgente))
            {
                string cartellaDestinazione = destinazione.Substring(destinazione.LastIndexOf('\\'));
                if (Directory.Exists(cartellaDestinazione))
                {
                    File.Move(sorgente, destinazione);
                    res = true;
                }
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
                        cancellaInfoRipristiniFotoCancellata(nomeFile);
                    }
                    else
                    {
                        // cataloga senza sapere dove
                        classificaFoto(nomeFile);
                    }
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
                    for (int m = 0; m < info.Length; m++)
                    {
                        if (info[n] != "")
                        {
                            sw.WriteLine(info[n]);
                        }
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
            DateTime inizio = new DateTime(),
                     fine = new DateTime();
            string b = "";
            if (Utility.CalcolaDateTimeDaPath(dirScomposto, ref inizio, ref fine, ref b))
            {
                /*
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
                */
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
