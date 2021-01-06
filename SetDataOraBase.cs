using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoOrganizzatore
{
    class SetDataOraBase
    {
        public DateTime DateTimeInizio { get; set; }
        public DateTime DateTimeFine { get; set; }
        public bool GiorniEstesi { get; set; }
        public Avvenimento avvenimento = null;
        public string testoCommento = "";
        public string testoDataFine = "";
        public string testoDataInizio = "";
        public void SetData(DateTime inizio, string giornoEsteso, string commento)
        {
            int giorno, mese, anno;
            DateTimeInizio = inizio;
            DateTimeFine = inizio;
            if (giornoEsteso != "")
            {
                testoDataInizio = inizio.Year.ToString("D4") + " " + inizio.Month.ToString("D2") + " " + inizio.Day.ToString("D2") + " " + inizio.ToString("dddddddddd", new CultureInfo("it-IT"));// valore.DayOfWeek.ToString("ddd");//,new CultureInfo("fr-FR"));
                testoDataFine = giornoEsteso;
                // dataFine.Visibility = Visibility.Visible;
                GiorniEstesi = true;
                string[] fine = giornoEsteso.Split(' ');
                switch (fine.Length)
                {
                    case 1:
                        giorno = Int16.Parse(fine[0]);
                        DateTimeFine = new DateTime(inizio.Year, inizio.Month, giorno);
                        break;
                    case 2:
                        giorno = Int16.Parse(fine[1]);
                        mese = Int16.Parse(fine[0]);
                        DateTimeFine = new DateTime(inizio.Year, mese, giorno);
                        break;
                    case 3:
                        giorno = Int16.Parse(fine[2]);
                        mese = Int16.Parse(fine[1]);
                        anno = Int16.Parse(fine[0]);
                        DateTimeFine = new DateTime(anno, mese, giorno);
                        break;
                }
            }
            else
            {
                testoDataInizio = inizio.Year.ToString("D4") + " " + inizio.Month.ToString("D2") + " " + inizio.Day.ToString("D2") + " " + inizio.ToString("dddddddddd", new CultureInfo("it-IT"));
                // dataFine.Visibility = Visibility.Hidden;
                GiorniEstesi = false;
            }
            testoCommento = commento;
        }
        public void SetCommento(String commentoEvento)
        {
            testoCommento = commentoEvento;
            /*if (Evento != null)
                Evento.Text = commentoEvento;*/
        }
    }
}
