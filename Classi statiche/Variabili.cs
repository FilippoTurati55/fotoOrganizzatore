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
    static class Variabili
    {
        public static ImmagineIngrandita codePopup = new ImmagineIngrandita();
        public static bool mostraFoto;
        public static int comandi;
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
        public static List<UnitaEsterna> UnitaEsterne = new List<UnitaEsterna>();
        public static SortedList<string, string> UnitaEsterneAccreditate = new SortedList<string, string>();
        public static SortedList<string, string> UnitaEsterneRifiutate = new SortedList<string, string>();

        public static ArchivioLocale ArchivioLocale = new ArchivioLocale();
        public static Backup Backup = new Backup();
        public static Calendario Calendario = new Calendario();
    }
}
