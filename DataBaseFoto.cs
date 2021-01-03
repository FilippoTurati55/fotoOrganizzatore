using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool creaDataBase()
        {
            bool res = false;
            ProcessDirectory(pathBase);
            return res;
        }
        void ProcessDirectory(string dir)
        {
            string[] fileEntries = Directory.GetFiles(dir);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }
        void ProcessFile(string path)
        {
            aggiungiFoto(path);
        }
        public bool aggiungiFoto(string path)
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
        public bool aggiungiFoto(long dimensione, string path)
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
    }
}
