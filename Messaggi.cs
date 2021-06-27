using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoOrganizzatore
{
    public partial class Messaggi : UserControl
    {
        public Messaggi()
        {
            InitializeComponent();
        }

        public void trovateNuoveFoti(int numeroFoti, int numeroFotiDoppie)
        {
            if (numeroFoti != 0)
            {
                TrovateFotografie.Text = "Trovate " + numeroFoti + " nuove fotografie";
            }
            else
            {
                TrovateFotografie.Text = "Nessuna fotografia nuova trovata";
            }
            if (numeroFotiDoppie != 0)
            {
                TrovateFotoDoppie.Text = "Trovate " + numeroFotiDoppie + " foto doppie";
            }
            else
            {
                TrovateFotoDoppie.Text = "Nessuna fotografia doppia trovata";
            }
        }
    }
}
