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
    public partial class AccreditamentoUnitaBackup : Form
    {
        public AccreditamentoUnitaBackup()
        {
            InitializeComponent();
        }

        public void inizializza(string disco, string costruttore, string numeroDiSerie)
        {
            discoImpostazione.Text = disco + ":";
            costruttoreImpostazione.Text = costruttore;
            numeroDiSerieImpostazione.Text = numeroDiSerie;
        }
        public string getIdentificatore()
        {
            return identificatore.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void accredita_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
