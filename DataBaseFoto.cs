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
    class DataBaseFoto
    {
        int doppie = 0;
        public SortedList<long, String[]> elencoFoto = new SortedList<long, String[]>();
        public string pathBase;
        public DataBaseFoto(string path)
        {
            pathBase = path;
        }
        public bool creaDataBase(Calendario calendario)
        {
            bool res = false;
            ProcessDirectory(pathBase,calendario);
            return res;
        }
        void ProcessDirectory(string dir, Calendario calendario)
        {
            string[] fileEntries;
            DateTime dataTime = new DateTime();
            string commentoProposto = "";
            // verifica correttezza nome cartella
            string[] dirScomposto = dir.Replace("/", "\\").Split('\\');
            if (dirScomposto.Length == 4)
            {
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
                    DateTime dataMinima = new DateTime(3000,1,1);
                    DateTime dataMassima = new DateTime(1,1,1);
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
                    aub.setnomeCommentoProposto(dataMinima, dataMassima,commentoProposto);
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
            }
            fileEntries = Directory.GetFiles(dir);
            if (fileEntries.Length != 0)
            {
                // crea calendario
                // Variabili.Calendario.AggiungiData(fileEntries[0], dir);
                calendario.AggiungiData(fileEntries[0], dir);
            }
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory,calendario);
        }
        void ProcessFile(string path)
        {
            controllaNormalizzaNomeFile(path);
            aggiungiFoto(path);
        }
        bool aggiungiFoto(string path)
        {
            bool result = false;
            if (File.Exists(path))
            {
                var info = new FileInfo(path);
                long lunghezza = info.Length;
                result = aggiungiFoto(lunghezza, path);
            }
            return result;
        }
        bool aggiungiFoto(long dimensione, string path)
        {
            bool result = false;
            if (!elencoFoto.ContainsKey(dimensione))
            {
                string[] array1 = new string[1];
                array1[0] = path;
                elencoFoto.Add(dimensione, array1);
            }
            else
            {
                doppie++;
                string[] array2 = elencoFoto[dimensione];
                string[] array3 = new string[array2.Length + 1];
                for (int i = 0; i < array2.Length; i++)
                {
                    array3[i] = array2[i];
                }
                array3[array2.Length] = path;
                elencoFoto[dimensione] = array3;
                string[] array4 = elencoFoto[dimensione];
            }
            return result;
        }
        string controllaNormalizzaNomeFile(string fileName)
        {
            string nome = fileName;
            if (!verificaNomeFile(fileName))
            {
                nome = normalizzaNomeFile(fileName);
            }
            return nome;
        }
        bool verificaNomeFile(string fileName)
        {
            bool result = false;
            DateTime dt = new DateTime();
            string conclusione = "", commento = "";
            result = Utility.CalcolaDateTimeDaStringa(fileName, ref dt, ref conclusione, ref commento);
            return result;
        }
        string normalizzaNomeFile(string fileName)
        {
            return fileName;
        }
    }
}
