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
        public Discobackup()
        {
            InitializeComponent();
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
    }
}
