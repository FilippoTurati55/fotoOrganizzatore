using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoOrganizzatore
{
    class CalendarioComplessivo : Calendario
    {
        SortedList<DateTime, SetDataOraBase> avvenimentiDoppi = new SortedList<DateTime, SetDataOraBase>();
        int numeroDateAggiunte = 0;
        public bool AggiungiData(DateTime chiave, SetDataOraBase avvenimento)
        {
            bool res = false;
            if (!elencoDateFotiAsync.ContainsKey(chiave))
            {
                // nuovo
                elencoDateFotiAsync.Add(chiave, avvenimento);
                numeroDateAggiunte++;
                res = true;
            }
            else
            {
                avvenimentiDoppi.Add(chiave, avvenimento);// già presente
            }
            return res;
        }
        public void Inizio()
        {
            numeroDateAggiunte = 0;
        }
        public void MessaggiConclusioneAggiunta()
        {
            Variabili.tracciaMessaggi("aggiunte " + numeroDateAggiunte + " nuove date a calendario complessivo");
            
            Variabili.tracciaMessaggi("presenti " + elencoDateFotiAsync.Count + " date nel calendario complessivo");
            if (avvenimentiDoppi.Count != 0)
            {
                Variabili.tracciaMessaggi("presenti " + avvenimentiDoppi.Count + " date doppie nel calendario complessivo");
            }
            ScriviSuDisco();
        }
        #region DISCO
        public bool LeggiDaDisco()
        {
            bool res = false;
            string path;
            if (Preferenze.creaCartellaDatiPermanenti())
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/fotografo/preferenze/calendarioComplessivo.txt";

                if (File.Exists(path))
                {
                    string[] lines = System.IO.File.ReadAllLines(path, Encoding.GetEncoding("iso-8859-1"));
                    try
                    {
                        for (int n = 1; n < lines.Length; n += 3)
                        {
                            // s = sr.ReadLine();
                            string evento = lines[n];
                            string date = lines[n + 1];
                            string cartella = lines[n + 2];
                            // data
                            string[] dataInizioFine = date.Split(' ');
                            string[] dataInizio = dataInizioFine[0].Split('_');
                            string[] dataFine = dataInizioFine[1].Split('_');
                            int annoInizio = Int32.Parse(dataInizio[0]);
                            int meseInizio = Int32.Parse(dataInizio[1]);
                            int giornoInizio = Int32.Parse(dataInizio[2]);
                            int annoFine = Int32.Parse(dataFine[0]);
                            int meseFine = Int32.Parse(dataFine[1]);
                            int giornoFine = Int32.Parse(dataFine[2]);
                            DateTime inizio = new DateTime(annoInizio, meseInizio, giornoInizio);
                            DateTime fine = new DateTime(annoFine, meseFine, giornoFine);
                            SetDataOraBase sdob = new SetDataOraBase();
                            sdob.DateTimeInizio = inizio;
                            sdob.SetDateTimeFine(fine);
                        }
                        res = true;
                    }
                    catch { };
                }
            }
            return res;

        }
        public bool ScriviSuDisco()
        {
            bool res = false;
            string path;
            if (numeroDateAggiunte != 0)
            {
                if (Preferenze.creaCartellaDatiPermanenti())
                {
                    path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/fotografo/preferenze/calendarioComplessivo.txt";
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("iso-8859-1"));
                    sw.WriteLine("calendario complessivo versione 1.1");
                    foreach (var dt in elencoDateFotiAsync)
                    {
                        DateTime inizio = dt.Value.DateTimeInizio;
                        DateTime fine = dt.Value.GetDateTimeFine();
                        // data non presente nel backup
                        string nomeCartellaOriginale = dt.Value.nomeCompletoCartella;
                        sw.WriteLine("evento: " + dt.Value.testoCommento);
                        sw.WriteLine(inizio.Year + "_" + inizio.Month + "_" + inizio.Day + " " +
                                        fine.Year + "_" + fine.Month + "_" + fine.Day);
                        sw.WriteLine(dt.Value.nomeCompletoCartella);
                    }
                    sw.Close();
                    Variabili.tracciaMessaggi("calendario complessivo salvato su disco");
                    res = true;
                }
                numeroDateAggiunte = 0;
            }
            return res;
        }
        #endregion
    }
}
