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
    public partial class Anno : UserControl
    {
        int valoreAnno = 0;
        public Anno()
        {
            InitializeComponent();
        }

        private void buttonAnno_Click(object sender, EventArgs e)
        {
            Variabili.selezioneAnno = valoreAnno;
            Variabili.comandi = Comandi.mostraCalendarioFoto;
            cambiaColore(true);
        }

        public void setNomeAnno(string valore)
        {
            buttonAnno.Text = valore;
            Int32.TryParse(valore, out valoreAnno);
        }
        public void cambiaColore(bool evidenzia)
        {
            if (evidenzia)
            {
                if ((Variabili.selezioneAnnoComponente != null) &&
                    (Variabili.selezioneAnnoComponente != this))
                {
                    Variabili.selezioneAnnoComponente.cambiaColore(false);
                }
                buttonAnno.BackColor = Color.Yellow;
                Variabili.selezioneAnnoComponente = this;
            }
            else buttonAnno.BackColor = SystemColors.Control;
        }
    }
}
