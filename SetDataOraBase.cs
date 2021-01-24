using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoOrganizzatore
{
    public class SetDataOraBase
    {
        public DateTime DateTimeInizio { get; set; }
        DateTime DateTimeFine;
        public bool GiorniEstesi { get; set; }
        public Avvenimento avvenimento = null;
        public string testoCommento = "";
        string testoDataFine = "";
        public string testoDataInizio = "";
        public string nomeCompletoCartella = "";
        #region ACCESSO
        public void SetDataeCartella(DateTime inizio, string giornoEsteso, string commento, string cartella)
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
            if (avvenimento != null)
                avvenimento.setDataFine();
            nomeCompletoCartella = cartella;
        }
        public string GetTestoDataFine() { return testoDataFine; }
        public DateTime GetDateTimeFine() { return DateTimeFine; }
        public void SetDateTimeFine(DateTime fine)
        {
            DateTimeFine = fine;
            // calcola indicazione evento su date multiple
            testoDataFine = "";
            if (DateTimeFine != DateTimeInizio)
            {
                if (DateTimeInizio.Year != DateTimeFine.Year)
                {
                    testoDataFine = DateTimeFine.Year.ToString("D4") + " " +
                                     DateTimeFine.Month.ToString("D2") + " " +
                                     DateTimeFine.Day.ToString("D2");
                }
                else
                {
                    if (DateTimeInizio.Month != DateTimeFine.Month)
                    {
                        testoDataFine = DateTimeFine.Month.ToString("D2") + " " +
                                         DateTimeFine.Day.ToString("D2");
                    }
                    else
                    {
                        if (DateTimeInizio.Day != DateTimeFine.Day)
                        {
                            testoDataFine = DateTimeFine.Day.ToString("D2");
                        }
                    }
                }
            }
            if (avvenimento != null)
                avvenimento.setDataFine();
        }
        public void SetCommento(String commentoEvento)
        {
            testoCommento = commentoEvento;
            /*if (Evento != null)
                Evento.Text = commentoEvento;*/
        }
        public string GetCommentoVisualizzato()
        {
            testoCommento = avvenimento.getCommento();
            return (testoCommento);
        }
        #endregion
        private STATO_SELEZIONE_DATA stato = STATO_SELEZIONE_DATA.NIENTE;
        #region COMPONENTE_VISUALE
        public Avvenimento creaAvvenimento()
        {
            avvenimento = new Avvenimento(this);
            avvenimento.setDataInizio(testoDataInizio);
            avvenimento.setDataFine(testoDataFine);
            avvenimento.setCommento(testoCommento);
            avvenimento.setStato(stato);
            /*
             * avvenimento.GiorniEstesi = sdob.GiorniEstesi;
            avvenimento.DateTime = sdob.DateTime;
            avvenimento.DateTimeFine = sdob.DateTimeFine;
            */
            return avvenimento;
        }
        /*public Avvenimento creaAvvenimento(double width)
        {
            avvenimento = new Avvenimento(width);
            return avvenimento;
        }*/
        public Avvenimento get()
        {
            return avvenimento;
        }
        #endregion
        public STATO_SELEZIONE_DATA Stato
        {
            get { return stato; }
            set
            {
                stato = value;
                if (avvenimento != null)
                    avvenimento.setStato(stato);
            }

        }
    }
}
