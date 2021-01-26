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
    static class Variabili
    {
        public static Button codePopup = new Button();
        public static bool mostraFoto;
        public static int comandi;
        public static DataBaseFoto dataBaseFotoLocali;
        public static Avvenimento DataOraEvidenziata;
        public static int MostraFotoInGiorno;
        public static int MostraFotoInGiornoPrevValue;
        public static SetDataOraBase MostraFotoSetDataOra;
        public static List<UnitaEsterna> UnitaEsterne = new List<UnitaEsterna>();
        public static SortedList<string, string> UnitaEsterneAccreditate = new SortedList<string, string>();
        public static SortedList<string, string> UnitaEsterneRifiutate = new SortedList<string, string>();

        public static ArchivioLocale ArchivioLocale = new ArchivioLocale();
        public static Backup Backup = new Backup();
        public static Calendario Calendario = new Calendario();
    }
}
