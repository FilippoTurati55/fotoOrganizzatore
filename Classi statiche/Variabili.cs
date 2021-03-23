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
        public static ImmagineIngrandita codePopup = new ImmagineIngrandita();
        public static Comandi comandi;
        public static int mostraFotoCount = 0;
        public static bool mostraFoto = false;
        public static bool mostraCartellaSpeciale = false;
        public static string nomeCartellaSpeciale = "";
        public static bool showFoto;
        public static bool fermaTaskRicercaDispositivi;
        public static DataBaseFoto dataBaseFotoLocali;
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

        public static Show show = new Show();
    }
}
