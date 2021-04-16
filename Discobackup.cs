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
    public partial class Discobackup : UserControl
    {
        Backup backup;
        public Discobackup(Backup riferimento)
        {
            InitializeComponent();
            backup = riferimento;
        }
        #region INTERFACCIA
        public void setNome(string Nome)
        {
            nome.Text = Nome;
        }
        public void setNumeroDiSerie(string ns)
        {
            numeroDiSerie.Text = ns;
        }
        #endregion

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            Variabili.setCalendarioAttivo(backup.calendarioBackup, backup.dataBaseFotoSuDiscoBackup);
            //splitContainerCruscotto.Visible = false;
            //splitContainerAnni.Visible = true;
            Variabili.comandi = Comandi.mostraCalendarioFoto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Variabili.setCalendarioAttivo(backup.calendarioBackup, backup.dataBaseFotoSuDiscoBackup);
        }
    }
}
