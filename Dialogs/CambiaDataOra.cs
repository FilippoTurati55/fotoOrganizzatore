using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoOrganizzatore.Dialogs
{
    public partial class CambiaDataOra : Form
    {
        public CambiaDataOra()
        {
            InitializeComponent();
        }

        public void setDateTime(DateTime dt)
        {
            textBoxAnno.Text = dt.Year.ToString("D4");
            textBoxMese.Text = dt.Month.ToString("D2");
            textBoxGiorno.Text = dt.Day.ToString("D2");
            textBoxOra.Text = dt.Hour.ToString("D2");
            textBoxMinuto.Text = dt.Minute.ToString("D2");
            textBoxSecondo.Text = dt.Second.ToString("D2");
        }

        private void accredita_Click(object sender, EventArgs e)
        {

        }
    }
}
