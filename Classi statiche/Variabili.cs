using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoOrganizzatore
{
    enum Passi
    {
        RicercaDispositivi,
        RicercaNuoveFoto,
        TrovateNuoveFoto,
        LetturaNuoveFoto,
        ConclusaLetturaNuoveFoto
    }
    enum Comandi
    {
        mostraCalendarioFoto,
        aggiornaMenuFoto,
        nessuno
    }
    static class Variabili
    {
        public static BoxImmagine primoBoxSelezionato;
        public static Button buttonRoot;
        public static ImmagineIngrandita codePopup = new ImmagineIngrandita();
        static Comandi comandi = Comandi.nessuno;
        public static int nDispositiviCollegati;
        public static int mostraFotoCount = 0;
        public static bool mostraFoto = false;
        public static bool mostraCartellaSpeciale = false;
        public static bool cestinoMostrato = false;
        public static string nomeCartellaSpeciale = "";
        public static bool showFoto;
        public static bool fermaTaskRicercaDispositivi;
        public static DateTime DataLetturaFotoPrecedente;
        public static Avvenimento DataOraEvidenziata;
        public static List<DispositivoRemoto> DispositiviRemoti = new List<DispositivoRemoto>();
        public static DispositivoRemoto DispositivoPrincipale;
        public static int MostraFotoInGiorno;
        public static int MostraFotoInGiornoPrevValue;
        public static SetDataOraBase MostraFotoSetDataOra;
        public static int NumeroDispositiviUsbTrovatiInEsame;
        public static Passi Passo = Passi.RicercaDispositivi;
        public static int selezioneAnno;
        public static Anno selezioneAnnoComponente = null;
        public static List<UnitaEsterna> UnitaEsterne = new List<UnitaEsterna>();
        public static SortedList<string, string> UnitaEsterneAccreditate = new SortedList<string, string>();
        public static SortedList<string, string> UnitaEsterneRifiutate = new SortedList<string, string>();

        public static ArchivioLocale ArchivioLocale = new ArchivioLocale();
        public static Backup Backup = new Backup();
        public static Calendario Calendario = new Calendario();
        static Calendario CalendarioAttivo = Calendario;
        public static DataBaseFoto dataBaseFotoLocali;
        static DataBaseFoto dataBaseFotoAttivo;
        public static Show show = new Show();
        static string TracciaMessaggi = "";
        public static bool nuoviMessaggi = false;
        public static Queue codaMessaggi = new Queue();
        // public static Queue codaComandiDaTask = new Queue();
        #region ACCESSO
        public static void setCalendarioAttivo(Calendario calendario, DataBaseFoto dataBaseFoto)
        {
            CalendarioAttivo = calendario;
            dataBaseFotoAttivo = dataBaseFoto;
        }
        static public void setComandi(Comandi comando)
        {
            comandi = comando;
        }
        static public Comandi getComandi()
        {
            return comandi;
        }
        public static Calendario getCalendarioAttivo()
        {
            return CalendarioAttivo;
        }
        public static DataBaseFoto getDataBaseFotoAttivo()
        {
            return dataBaseFotoAttivo;
        }
        #endregion
        #region messaggi
        public static string tracciaMessaggi() { return TracciaMessaggi; }
        public static void tracciaMessaggi(AndamentoAttivita andamento, string messaggio, bool verboso)
        {
            codaMessaggi.Enqueue(andamento);
            andamento.inAtto = messaggio;
            if (verboso)
                tracciaMessaggi(messaggio);
        }
        public static void tracciaMessaggi(string messaggio)
        {
            TracciaMessaggi += messaggio + "\n";
            nuoviMessaggi = true;
        }
        #endregion
        //public static Cruscotto cruscotto;
    }
}
