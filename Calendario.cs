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
    class Calendario
    {
        public SortedList<DateTime, SetDataOraBase> elencoDateFotiAsync = new SortedList<DateTime, SetDataOraBase>();
        Panel SceltaCalendario;
        public List<string> elencoDateDoppie = new List<string>();
        /*public void ElencaDateFotoCatalogate()
        {
            int lunghezzaRadice = Preferenze.NomeCartellaFotoOrganizzate.Length + 1;
            for (int n = 0; n < Variabili.dataBaseFotoLocali.elencoFoto.Count; n++)
            {
                var fotiEquDim = Variabili.dataBaseFotoLocali.elencoFoto.ElementAt(n);
                for (int f = 0; f < fotiEquDim.Value.Length; f++)
                {
                    var fileFoto = fotiEquDim.Value[f];
                    DateTime dt = new DateTime();
                    if (Utility.CalcolaDateTimeDaStringa(fileFoto, ref dt));
                    {

                    }
                }
            }
        }*/
        public void AggiungiData(string data)
        {
            //SetDataOra nuovoEvento = null;
            SetDataOraBase nuovoEventoBase = new SetDataOraBase();
            DateTime dateTime = new DateTime();
            string conclusione = "";
            string commento = "";
            if (Utility.CalcolaDateTimeDaStringa(data, ref dateTime, ref conclusione, ref commento))
            {
                nuovoEventoBase.SetData(dateTime, conclusione, commento);
                if (!elencoDateFotiAsync.ContainsKey(dateTime))
                {
                    elencoDateFotiAsync.Add(dateTime, nuovoEventoBase);
                }
                else
                {
                    if (!elencoDateDoppie.Contains(data))
                        elencoDateDoppie.Add(data);
                }
            }
        }
        public void MostraCalendarioFoto(Panel pannello, bool soloDateNuove)
        {
            Avvenimento avvenimento;
            SetDataOraBase sdob;
            SceltaCalendario = pannello;
            pannello.Controls.Clear();
            int location = 0;
            foreach (var dt in elencoDateFotiAsync)
            {
                sdob = dt.Value;
                if (sdob.avvenimento == null)
                {
                    avvenimento = sdob.creaAvvenimento();
                }
                else
                {
                    avvenimento = sdob.avvenimento;
                }
                avvenimento.resetEventiClick();
                avvenimento.EventoClick += EventoSelezionaData;
                //avvenimento.EventoModificaCommento += EventoModificaCommento;
                /*sdo.resetEventiClick();
                //if (dt.Value.GiorniEstesi)
                if (sdo.GiorniEstesi)
                {
                    // dt.Value.EventoClick += EventoSciogliRaggruppamento;
                    sdo.EventoClick += EventoSciogliRaggruppamento;
                }
                else
                {
                    // dt.Value.EventoClick += EventoSelezionaData;
                    sdo.EventoClick += EventoSelezionaData;
                }
                sdo.EventoModificaCommento += EventoModificaCommento;
                if ((Variabili.SelezioneCosaMostrareTutto) && (Variabili.elencoDateDiFotoNuove.ContainsKey(dt.Key)))
                {
                    sdo.dataInizio.Background =
                        sdo.dataFine.Background =
                        sdo.Evento.Background = new SolidColorBrush(Colors.Yellow);

                }
                if ((Variabili.SelezioneCosaMostrareTutto) || (Variabili.elencoDateDiFotoNuove.ContainsKey(dt.Key)))
                {
                    if ((!soloDateNuove) || (dt.Key > Variabili.DataLetturaFotoPrecedente))
                    {
                        _ = SceltaCalendario.Children.Add(sdo);
                    }
                }
                */
                SceltaCalendario.Controls.Add(avvenimento);
                avvenimento.resize();
                avvenimento.Location = new Point(0, location);
                location += avvenimento.Height;
            }
        }
        #region AZIONI_EVENTI
        private void EventoSelezionaData(Avvenimento origine)
        {
            bool continua;
            int posizione;
            SetDataOraBase sdob = origine.Sdob;
            DateTime data = sdob.DateTimeInizio;
            switch (sdob.Stato)
            {
                case STATO_SELEZIONE_DATA.NIENTE:
                    DateTime dataInizio = new DateTime();
                    if (CercaIniziPrima(data, ref dataInizio))
                    {
                        // per cambiare permanentemente le cartelle sostituire ModificaStatoGruppo
                        /*if (ModificaStatoGruppo(dataInizio, data, false, STATO_SELEZIONE_DATA.INTERMEDIO))
                        {
                            elencoDateFotiAsync[data].avvenimento.Stato = STATO_SELEZIONE_DATA.FINE;
                            int a = 0;*/
                            // occorre prima chiudere la finestra a destra
                            Raggruppa(dataInizio, data, elencoDateFotiAsync[dataInizio].testoCommento, Preferenze.NomeCartellaFotoOrganizzate);
                            /*if (EventoAggiornaCalendario != null)
                                EventoAggiornaCalendario.Invoke();*/
                            //ElencaDateFotoCatalogate();
                            //MostraCalendarioFoto(SceltaCalendarioSP, false);
                        //}
                    }
                    else
                    {
                        elencoDateFotiAsync[data].Stato = STATO_SELEZIONE_DATA.INIZIO;
                    }
                    sdob.Stato = STATO_SELEZIONE_DATA.INIZIO;
                    break;
                case STATO_SELEZIONE_DATA.INIZIO:
                    /*elencoDateFotiAsync[data].avvenimento.Stato = STATO_SELEZIONE_DATA.NIENTE;
                    continua = true;
                    posizione = elencoDateFotiAsync.IndexOfKey(data) + 1;
                    while ((continua) && (posizione < elencoDateFotiAsync.Count))
                    {
                        DateTime key = elencoDateFotiAsync.Keys[posizione];
                        switch (elencoDateFotiAsync[key].avvenimento.Stato)
                        {
                            case STATO_SELEZIONE_DATA.INIZIO:
                            case STATO_SELEZIONE_DATA.NIENTE:
                                continua = false;
                                break;
                            case STATO_SELEZIONE_DATA.INTERMEDIO:
                                elencoDateFotiAsync[key].avvenimento.Stato = STATO_SELEZIONE_DATA.NIENTE;
                                break;
                            case STATO_SELEZIONE_DATA.FINE:
                                elencoDateFotiAsync[key].avvenimento.Stato = STATO_SELEZIONE_DATA.NIENTE;
                                continua = false;
                                break;
                        }
                        posizione++;
                    }*/
                    sdob.Stato = STATO_SELEZIONE_DATA.NIENTE; 
                    break;
                case STATO_SELEZIONE_DATA.FINE:
                    /*elencoDateFotiAsync[data].avvenimento.Stato = STATO_SELEZIONE_DATA.NIENTE;
                    continua = true;
                    posizione = elencoDateFotiAsync.IndexOfKey(data) - 1;
                    while ((continua) && (posizione >= 0))
                    {
                        DateTime key = elencoDateFotiAsync.Keys[posizione];
                        switch (elencoDateFotiAsync[key].avvenimento.Stato)
                        {
                            case STATO_SELEZIONE_DATA.FINE:
                            case STATO_SELEZIONE_DATA.NIENTE:
                            case STATO_SELEZIONE_DATA.INIZIO:
                                continua = false;
                                break;
                            case STATO_SELEZIONE_DATA.INTERMEDIO:
                                elencoDateFotiAsync[key].avvenimento.Stato = STATO_SELEZIONE_DATA.NIENTE;
                                break;
                        }
                        posizione--;
                    }*/
                    break;
                case STATO_SELEZIONE_DATA.INTERMEDIO:
                    break;
                default:
                    break;
            }
        }
        /*
         * private void EventoModificaCommento(SetDataOra origine)
        {
            //bool modificata = false;
            //string nomeCartella = CalcolaNomeCartella(origine.DateTime, origine.DateTime, origine.GetCommento());
            string nomeCartella = Variabili.operazioniSuPc.cercaCartellaDaData(origine.DateTime);
            nomeCartella = Variabili.operazioniSuPc.togliCommentoDaNomeCartella(nomeCartella);
            //nomeCartella = @"c: \foto\" + origine.DateTime.Year.ToString("D4") +@"\" + nomeCartella;
            if (origine.Evento.Text != "")
                nomeCartella += " " + origine.Evento.Text;
            string nomeVecchio = Variabili.operazioniSuPc.cercaCartellaDaData(origine.DateTime);
            nomeVecchio = nomeVecchio.Replace('/', '\\');
            nomeCartella = nomeCartella.Replace('/', '\\');
            if (nomeCartella != nomeVecchio)
            {
                Directory.Move(nomeVecchio, nomeCartella);
            }
            // return modificata;
        }
        private void EventoSciogliRaggruppamento(SetDataOra origine)
        {
            //EventoSciogliRaggruppamento(origine, false);
            EventoSciogliRaggruppamento(origine, "");
        }
        public void EventoSciogliRaggruppamento(SetDataOra origine, string nomeBaseCartella)
        {
            // string nomeCartella = Variabili.operazioniSuPc.cercaCartellaDaData(origine.DateTime,backup);
            string nomeCartella = Variabili.operazioniSuPc.cercaCartellaDaData(origine.DateTime, nomeBaseCartella);
            if (nomeCartella != "")
            {
                string[] files = Directory.GetFiles(nomeCartella);
                foreach (var foto in files)
                {
                    string[] fotoScomposta = foto.Split('\\');
                    DateTime data = FileImmagini.CalcolaDataFoto(foto);
                    string cartella = Variabili.operazioniSuPc.cercaCartellaDaData(data, nomeBaseCartella);
                    if (cartella != nomeCartella)
                    {
                        if (cartella == "")
                        {
                            int a = 0;
                            cartella = Variabili.operazioniSuPc.CreaCartella(nomeBaseCartella, data);
                        }
                        Variabili.operazioniSuPc.MuoviFile(foto, cartella);
                    }
                }
                string nuovoNomeCartella = CalcolaNomeCartella(origine.DateTime, origine.GetCommento(), nomeBaseCartella);
                if (nomeCartella != nuovoNomeCartella)
                {
                    if (Directory.Exists(nuovoNomeCartella))
                    {
                        Variabili.operazioniSuPc.MuoviCartella(nomeCartella, nuovoNomeCartella);
                    }
                    else
                    {
                        Directory.Move(nomeCartella, nuovoNomeCartella);
                    }
                }
                // if ((EventoAggiornaCalendario != null) && (!backup))
                if ((EventoAggiornaCalendario != null) && (nomeBaseCartella == ""))
                    EventoAggiornaCalendario.Invoke();
            }
        }*/
        #endregion
        bool CercaIniziPrima(DateTime data, ref DateTime dataInizio)
        {
            bool trovatoInizio = false;
            foreach (var dateTime in elencoDateFotiAsync)
            {
                if (dateTime.Key == data)
                    break;
                else
                {
                    if (trovatoInizio)
                    {
                        if (dateTime.Value.Stato == STATO_SELEZIONE_DATA.FINE)
                        {
                            trovatoInizio = false;
                        }
                    }
                    else
                    {
                        if (dateTime.Value.Stato == STATO_SELEZIONE_DATA.INIZIO)
                        {
                            dataInizio = dateTime.Key;
                            trovatoInizio = true;
                        }
                    }
                }
            }
            return trovatoInizio;
        }
        public void Raggruppa(DateTime dataInizio,
                                 DateTime dataFine,
                                 string commento,
                                 string nomeCartella)
        {
            Raggruppa(dataInizio, dataFine, commento, nomeCartella, elencoDateFotiAsync);
        }
        public void Raggruppa(DateTime dataInizio,
                                 DateTime dataFine,
                                 string commento,
                                 string nomeCartellaBackup,  // rinominare in nomeInizioPath
                                 SortedList<DateTime, SetDataOraBase> elencoFoti) // rinominare in elencoDateFoti
                                // in SetDataOraBase mettere un campo che contiene il nome della cartella
        {
            string nomeCartella;
            string nomeCompleto = "";
            nomeCartella = CalcolaNomeCartella(dataInizio, dataFine, commento);
            if (dataInizio != dataFine)
            {
                int a = 0;
                string nomeInizioPath = nomeCartellaBackup + @"/" + dataInizio.Year.ToString("D4");
                nomeCompleto = Utility.CreaCartella(nomeInizioPath, nomeCartella);
                if (nomeCompleto != "")
                {
                    // sposta le cartelle nell'intervallo
                    foreach (var dateTime in elencoFoti)
                    {
                        //if ((dateTime.Key >= dataInizio) && (dateTime.Key <= dataFine))
                        if (dateTime.Key == dataInizio)
                        {
                            // muovi la cartella
                            // string vecchioNome = Variabili.operazioniSuPc.cercaCartellaDaData(dataInizio,backup);
                            string vecchioNome = cercaCartellaDaData(dataInizio, nomeCartellaBackup);
                            if (vecchioNome != "")
                            {
                                if (vecchioNome != nomeCompleto)
                                {
                                    if (Directory.Exists(nomeCompleto))
                                        Utility.MuoviCartella(vecchioNome, nomeCompleto);
                                    else Directory.Move(vecchioNome, nomeCompleto);
                                }
                            }
                        }
                        else
                        {
                            if ((dateTime.Key > dataInizio) && (dateTime.Key <= dataFine))
                            {
                                //string cartellaSorgente = Variabili.operazioniSuPc.cercaCartellaDaData(dateTime.Key, backup);
                                string cartellaSorgente = cercaCartellaDaData(dateTime.Key, nomeCartellaBackup);
                                if (cartellaSorgente == "")
                                    cartellaSorgente = cartellaSorgente;
                                //cartellaSorgente = Variabili.operazioniSuPc.cercaCartellaDaData(dateTime.Key, backup);
                                cartellaSorgente = cercaCartellaDaData(dateTime.Key, nomeCartellaBackup);
                                Utility.MuoviCartella(cartellaSorgente, nomeCompleto);//string aa = dateTime.Key.ToString();
                            }
                        }
                    }
                }
            }
        }
        public string CalcolaNomeCartella(DateTime dateTime, string commento)
        {
            return CalcolaNomeCartella(dateTime, commento, false);
        }
        public string CalcolaNomeCartella(DateTime dateTime, string commento, bool backup)
        {
            string cartellaFoti = Preferenze.NomeCartellaFotoOrganizzate;
            if (backup)
                cartellaFoti = Preferenze.NomeCartellaFotoOrganizzate;
            //string nomeCartella = @"c: \foto\" + dateTime.Year.ToString() + "\\" + dateTime.Month.ToString("D2") + " " + dateTime.Day.ToString("D2");
            string nomeCartella = cartellaFoti + @"\" + dateTime.Year.ToString() + "\\" + dateTime.Month.ToString("D2") + " " + dateTime.Day.ToString("D2");
            if (commento != "")
                nomeCartella += " " + commento;
            return nomeCartella;
        }
        public string CalcolaNomeCartella(DateTime dateTime, string commento, string nomeBaseCartella)
        {
            string cartellaFoti = Preferenze.NomeCartellaFotoOrganizzate;
            if (nomeBaseCartella != "")
                cartellaFoti = nomeBaseCartella;
            //string nomeCartella = @"c: \foto\" + dateTime.Year.ToString() + "\\" + dateTime.Month.ToString("D2") + " " + dateTime.Day.ToString("D2");
            string nomeCartella = cartellaFoti + @"\" + dateTime.Year.ToString() + "\\" + dateTime.Month.ToString("D2") + " " + dateTime.Day.ToString("D2");
            if (commento != "")
                nomeCartella += " " + commento;
            return nomeCartella;
        }
        string CalcolaNomeCartella(DateTime dataInizio, DateTime dataFine, string commento)
        {
            string nomeCartella = dataInizio.Month.ToString("D2") + " " +
                                    dataInizio.Day.ToString("D2");
            if (dataInizio != dataFine)
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
        // public string cercaCartellaDaData(DateTime dateTime, bool backup)
        string cercaCartellaDaData(DateTime dateTime, string rootBase)
            // rootBase è cambiato rispetto al parametro precedente, va verificato tutto
        {
            string result = "";
            try
            {
                string cercata = dateTime.Month.ToString("D2") + " " + dateTime.Day.ToString("D2");
                //string nomeCartella = @"c: \foto\" + dateTime.Year.ToString("D4");
                string nomeCartella = rootBase + @"\" + dateTime.Year.ToString("D4");
                string[] subdirectoryEntries = Directory.GetDirectories(nomeCartella);
                foreach (string subName in subdirectoryEntries)
                {
                    string[] sn = subName.Replace('/', '\\').Split('\\');
                    string snr = sn[3].Substring(0, 5);
                    if (snr == cercata)
                    {
                        result = subName;
                        break;
                    }
                }
            }
            catch { }
            return result;
        }
    }
}
