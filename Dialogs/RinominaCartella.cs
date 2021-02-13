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
    public partial class RinominaCartella : Form
    {
        public RinominaCartella()
        {
            InitializeComponent();
        }
        #region
        public void setnomeErratoCartella(string name)
        {
            nomeErratoCartella.Text = name;
        }
        public void setdataMinima(string data)
        {
            dataMinima.Text = data;
        }
        public void setdataMassima(string data)
        {
            dataMassima.Text = data;
        }
        public void setnomeProposto(string name)
        {
            nomeProposto.Text = name;
        }
        #endregion

        private void accredita_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
