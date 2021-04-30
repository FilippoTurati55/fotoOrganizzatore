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
        public DateTime getDateTime()
        {
            int anno,mese,giorno,ora,minuto,secondo;
            DateTime dt = new DateTime();
            if ((Int32.TryParse(textBoxAnno.Text, out anno)) &&
                (Int32.TryParse(textBoxMese.Text, out mese)) &&
                (Int32.TryParse(textBoxGiorno.Text, out giorno)) &&
                (Int32.TryParse(textBoxOra.Text, out ora)) &&
                (Int32.TryParse(textBoxMinuto.Text, out minuto)) &&
                (Int32.TryParse(textBoxSecondo.Text, out secondo)))
            {
                if ((anno > 1900) && (anno < 2100) &&
                    (mese > 0) && (mese < 13) &&
                    (giorno > 0) && (giorno < 32) &&
                    (ora >= 0) && (ora < 24) &&
                    (minuto >= 0) && (minuto < 60) &&
                    (secondo >= 0) && (secondo < 60))
                {
                    dt = new DateTime(anno,mese,giorno,ora,minuto,secondo);
                }
            }
            return dt;
        }
        private void accredita_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
