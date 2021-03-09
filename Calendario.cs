using System;
using System.Collections;
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
        public SortedList<string, CartellaBase> cartelleSpeciali = new SortedList<string, CartellaBase>();
        Panel SceltaCalendario;
        public List<string> elencoDateDoppie = new List<string>();
        #region QUERY
        public SetDataOraBase getData(DateTime data)
        {
            SetDataOraBase result = null;
            DateTime dataFloor = new DateTime(data.Year, data.Month, data.Day);
            if (elencoDateFotiAsync.ContainsKey(dataFloor))
            {
                result = elencoDateFotiAsync[dataFloor];
            }
            return result;
        }
        #endregion
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
        public void AggiungiCartellaSpeciale(string nome, string pathCompleto)
        {
            CartellaBase cb = new CartellaBase();
            cb.setNomeCartella(nome);
            cb.setPathCompleto(pathCompleto);
            if (!cartelleSpeciali.ContainsKey(nome))
            {
                cartelleSpeciali.Add(nome, cb);
            }
        }
        public void AggiungiData(string pathCompletoFoto, string cartella)
        {
            //SetDataOra nuovoEvento = null;
            SetDataOraBase nuovoEventoBase = new SetDataOraBase();
            DateTime dateTime = new DateTime();
            string conclusione = "";
            string commento = "";
            if (Utility.CalcolaDateTimeDaStringa(pathCompletoFoto, ref dateTime, ref conclusione, ref commento))
            {
                nuovoEventoBase.SetDataeCartella(dateTime, conclusione, commento, cartella);
                if (!elencoDateFotiAsync.ContainsKey(dateTime))
                {
                    elencoDateFotiAsync.Add(dateTime, nuovoEventoBase);
                }
                else
                {
                    if (!elencoDateDoppie.Contains(pathCompletoFoto))
                        elencoDateDoppie.Add(pathCompletoFoto);
                }
            }
            else
            {
                // il nome della foto potrebbe non contenere la data
                DateTime dataFoto = new DateTime();
                if (FileImmagini.CalcolaMomentoScattoFoto(pathCompletoFoto, ref dataFoto))
                    FileImmagini.VerificaDataFotoConPath(dataFoto, pathCompletoFoto);
            }
        }
        public void MostraCalendarioFoto(Panel pannello, bool soloDateNuove)
        {
            Avvenimento avvenimento;
            Cartella cartellaSpeciale;
            SetDataOraBase sdob;
            CartellaBase cb;
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
                avvenimento.EventoModificaCommento += EventoModificaCommento;
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
            foreach (var caspe in cartelleSpeciali)
            {
                cb = caspe.Value;
                if (cb.cartella == null)
                {
                    cartellaSpeciale = cb.creaCartella();
                }
                else
                {
                    cartellaSpeciale = cb.cartella;
                }
                SceltaCalendario.Controls.Add(cartellaSpeciale);
                cartellaSpeciale.resize();
                cartellaSpeciale.Location = new Point(0, location);
                location += cartellaSpeciale.Height;
            }
        }
        #region AZIONI_EVENTI
        private void EventoSelezionaData(Avvenimento origine)
        {
            bool continua;
            int posizione;
            SetDataOraBase sdob = origine.Sdob;
            DateTime dataInizioOrigine = sdob.DateTimeInizio;
            DateTime dataFineOrigine = sdob.GetDateTimeFine();
            switch (sdob.Stato)
            {
                case STATO_SELEZIONE_DATA.NIENTE:
                    DateTime dataInizio = new DateTime();
                    if (CercaIniziPrima(dataInizioOrigine, ref dataInizio))
                    {
                        // per cambiare permanentemente le cartelle sostituire ModificaStatoGruppo
                        /*if (ModificaStatoGruppo(dataInizio, data, false, STATO_SELEZIONE_DATA.INTERMEDIO))
                        {
                            elencoDateFotiAsync[data].avvenimento.Stato = STATO_SELEZIONE_DATA.FINE;
                            int a = 0;*/
                            // occorre prima chiudere la finestra a destra
                            Raggruppa(dataInizio, dataFineOrigine, elencoDateFotiAsync[dataInizio].testoCommento, Preferenze.NomeCartellaFotoOrganizzate);
                            /*if (EventoAggiornaCalendario != null)
                                EventoAggiornaCalendario.Invoke();*/
                            //ElencaDateFotoCatalogate();
                            //MostraCalendarioFoto(SceltaCalendarioSP, false);
                        //}
                    }
                    else
                    {
                        elencoDateFotiAsync[dataInizioOrigine].Stato = STATO_SELEZIONE_DATA.INIZIO;
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
                    SciogliRaggruppamento(origine);
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
        private void EventoModificaCommento(Avvenimento origine)
        {
            string nomeInizialeCartella, nomeFinaleCartella;
            SetDataOraBase sdob = origine.Sdob;
            nomeInizialeCartella = sdob.nomeCompletoCartella;
            nomeFinaleCartella = Utility.togliCommentoDaNomeCartella(nomeInizialeCartella);
            string commentoVisualizzato = sdob.GetCommentoVisualizzato();
            if (commentoVisualizzato != "")
                nomeFinaleCartella += " " + commentoVisualizzato;
            if (nomeInizialeCartella != nomeFinaleCartella)
            {
                Directory.Move(nomeInizialeCartella, nomeFinaleCartella);
                sdob.nomeCompletoCartella = nomeFinaleCartella;
            }
        }
        void SciogliRaggruppamento(Avvenimento origine)
        {
            string nomeCartella;
            SetDataOraBase sdob = origine.Sdob;
            try
            {
                if (sdob != null)
                {
                    if (sdob.DateTimeInizio != sdob.GetDateTimeFine())
                    {
                        // raggruppamento da sciogliere
                        nomeCartella = sdob.nomeCompletoCartella.Replace('/','\\');
                        classificaCartellaConNomiNormalizzati(nomeCartella);
                        string[] nomeCartellaSplit = nomeCartella.Split('\\');
                        string finale = nomeCartellaSplit[nomeCartellaSplit.Length - 1];
                        string inizioFinale = finale.Substring(0, 5);
                        string nuovoNomeCartella = nomeCartellaSplit[0];
                        for (int n = 1; n < nomeCartellaSplit.Length - 1; n++)
                        {
                            nuovoNomeCartella += @"\" + nomeCartellaSplit[n];
                        }
                        nuovoNomeCartella += @"\" + inizioFinale;
                        if (nomeCartella != nuovoNomeCartella)
                        {
                            Directory.Move(nomeCartella, nuovoNomeCartella);
                            sdob.nomeCompletoCartella = nuovoNomeCartella;
                            sdob.SetDateTimeFine(sdob.DateTimeInizio);
                        }
                        Variabili.comandi = 1;
                    }
                }
            }
            catch { }
            /* string nomeCartella = origine. Variabili.operazioniSuPc.cercaCartellaDaData(origine.DateTime, nomeBaseCartella);
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
            } */
        }
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
                                 string nomePrimoInizioPath,
                                 SortedList<DateTime, SetDataOraBase> elencoDateFoti) 
        {
            string nomeCartella;
            string nomeCompleto = "";
            ArrayList dateDaRimuovereDaLista = new ArrayList();
            nomeCartella = Utility.CalcolaNomeCartella(dataInizio, dataFine, commento);
            if (dataInizio != dataFine)
            {
                int a = 0;
                string nomeInizioPath = nomePrimoInizioPath + @"/" + dataInizio.Year.ToString("D4");
                nomeCompleto = Utility.CreaCartella(nomeInizioPath, nomeCartella);
                if (nomeCompleto != "")
                {
                    // sposta le cartelle nell'intervallo
                    foreach (var dateTime in elencoDateFoti)
                    {
                        if (dateTime.Key == dataInizio)
                        {
                            // muovi la cartella
                            string vecchioNome = dateTime.Value.nomeCompletoCartella;
                            if (vecchioNome != "")
                            {
                                if (vecchioNome != nomeCompleto)
                                {
                                    if (Directory.Exists(nomeCompleto))
                                        Utility.MuoviCartella(vecchioNome, nomeCompleto);
                                    else Directory.Move(vecchioNome, nomeCompleto);
                                    dateTime.Value.nomeCompletoCartella = nomeCompleto;
                                    dateTime.Value.SetDateTimeFine(dataFine);
                                    //dateTime.Value.testoDataFine = ;   // errore voluto, il valore va calcolato
                                }
                            }
                        }
                        else
                        {
                            if ((dateTime.Key > dataInizio) && (dateTime.Key <= dataFine))
                            {
                                string cartellaSorgente = dateTime.Value.nomeCompletoCartella;
                                if (cartellaSorgente != "")
                                { 
                                    Utility.MuoviCartella(cartellaSorgente, nomeCompleto);
                                    // elencoDateFoti.Remove(dateTime.Key);
                                    dateDaRimuovereDaLista.Add(dateTime.Key);
                                }
                            }
                        }
                    }
                    if (dateDaRimuovereDaLista.Count > 0)
                    {
                        foreach(DateTime dt in dateDaRimuovereDaLista)
                        {
                            elencoDateFoti.Remove(dt);
                        }
                    }
                }
            }
            if (elencoDateFoti.ContainsKey(dataInizio))
            {
                SetDataOraBase sdobinizio = elencoDateFoti[dataInizio];
                sdobinizio.Stato = STATO_SELEZIONE_DATA.NIENTE;
            }
            Variabili.comandi = 1;
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
        /*string CalcolaNomeCartella(DateTime dataInizio, DateTime dataFine, string commento)
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
        */
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
        void classificaCartellaConNomiNormalizzati(string nomeCartella)
        {
            try { 
                string[] files = Directory.GetFiles(nomeCartella);
                foreach (var foto in files)
                {
                    string[] fotoScomposta = foto.Split('\\');
                    string campoData = fotoScomposta[fotoScomposta.Length - 1];
                    string[] dataComplessa = campoData.Split('_');
                    string data = dataComplessa[1];
                    string anno = data.Substring(0, 4);
                    string mese = data.Substring(4, 2);
                    string giorno = data.Substring(6, 2);
                    int annoInt, meseInt, giornoInt;
                    Int32.TryParse(anno, out annoInt);
                    Int32.TryParse(mese, out meseInt);
                    Int32.TryParse(giorno, out giornoInt);
                    DateTime dataFoto = new DateTime(annoInt, meseInt, giornoInt);
                    if (!elencoDateFotiAsync.ContainsKey(dataFoto))
                    {
                        string cartella = CalcolaNomeCartella(dataFoto, "");
                        if (!Directory.Exists(cartella))
                        {
                            // crea cartella nuova data
                            Directory.CreateDirectory(cartella);
                        }
                        SetDataOraBase nuovoEventoBase = new SetDataOraBase();
                        nuovoEventoBase.SetDataeCartella(dataFoto, "", "", cartella);
                        elencoDateFotiAsync.Add(dataFoto, nuovoEventoBase);
                    }
                    // cartella già esistente
                    string nomeCartellaFoto = elencoDateFotiAsync[dataFoto].nomeCompletoCartella;
                    if (nomeCartellaFoto != nomeCartella)
                    {
                        // sposta in cartella nuova data
                        string nomeFileCorto = fotoScomposta[fotoScomposta.Length - 1];
                        string nomeCompletoFile = nomeCartellaFoto + @"\\" + nomeFileCorto;
                        if (!File.Exists(nomeCompletoFile))
                        {
                            File.Move(foto, nomeCompletoFile);
                        }
                    }

                    /*DateTime data = FileImmagini.CalcolaDataFoto(foto);
                    string cartella = Variabili.operazioniSuPc.cercaCartellaDaData(data, nomeBaseCartella);
                    if (cartella != nomeCartella)
                    {
                        if (cartella == "")
                        {
                            int a = 0;
                            cartella = Variabili.operazioniSuPc.CreaCartella(nomeBaseCartella, data);
                        }
                        Variabili.operazioniSuPc.MuoviFile(foto, cartella);
                    }*/
                }
                /*string nuovoNomeCartella = CalcolaNomeCartella(origine.DateTime, origine.GetCommento(), nomeBaseCartella);
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
                }*/
                // if ((EventoAggiornaCalendario != null) && (!backup))
                /*if ((EventoAggiornaCalendario != null) && (nomeBaseCartella == ""))
                    EventoAggiornaCalendario.Invoke();*/
            }
            catch { }

        }
    }
}
