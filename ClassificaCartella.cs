using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoOrganizzatore
{
    class ClassificaCartella
    {
        public void Classifica()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string cartella = folderBrowserDialog.SelectedPath;
                // esamina cartella
                classificaCartella(cartella);
                //Variabili.getDataBaseFotoAttivo().creaDataBase(Variabili.getCalendarioAttivo());
                //Variabili.calendario.ElencaDateFotoCatalogate();
                //Variabili.calendario.MostraCalendarioFoto(sp, Variabili.MostrateSoloFotoNuove);
            }
        }
        void classificaCartella(string cartella)
        {
            string evento = "";
            string nomeCartella = "";
            int NumeroFotiNuove = 0;
            int NumeroFotiDoppie = 0;
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(cartella);
            foreach (string fileName in fileEntries)
            {
                if (Variabili.getDataBaseFotoAttivo().verificaPresenzaFoto(fileName))
                {

                }
                /*
                FileInfo file = new FileInfo(fileName);
                string nomeFile = file.Name;
                DateTime data = new DateTime();
                data = file.LastWriteTime;
                DateTime dt1 = new DateTime(data.Year, data.Month, data.Day);
                if (!Variabili.operazioniSuPc.CercaDataInCartelle(data, ref evento, ref nomeCartella))
                {
                    // cartella data da creare
                    nomeCartella = Variabili.operazioniSuPc.CreaCartella("", data);
                    Directory.CreateDirectory(nomeCartella);
                    Variabili.elencoDateCreate.Add(dt1, nomeCartella);
                }
                string nomeFileDestinazione = nomeCartella + "/" + nomeFile;
                if (!File.Exists(nomeFileDestinazione))
                {
                    if (!Variabili.elencoDateDiFotoNuove.ContainsKey(dt1))
                        Variabili.elencoDateDiFotoNuove.Add(dt1, dt1);
                    File.Move(fileName, nomeFileDestinazione);
                    Variabili.elencoFotoClassificate.Add(nomeFileDestinazione, data);
                    NumeroFotiNuove++;
                }
                */
            }
            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(cartella);
            foreach (string subdirectory in subdirectoryEntries)
            {
                classificaCartella(subdirectory);
            }
        }
    }
}
