using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoOrganizzatore
{
    static class Variabili
    {
        public static Avvenimento MostraFotoSetDataOra;
        public static TextBox DataOraEvidenziata;
        public static int MostraFotoInGiorno;
        public static List<UnitaEsterna> UnitaEsterne = new List<UnitaEsterna>();
        public static SortedList<string,string> UnitaEsterneAccreditate = new SortedList<string, string>();

        public static Backup Backup = new Backup();
    }
}
