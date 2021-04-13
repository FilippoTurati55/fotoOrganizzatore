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
    public partial class Cruscotto : Form
    {
        Form1 form1;
        public Cruscotto(Form1 callBack)
        {
            InitializeComponent();
            form1 = callBack;
            this.SetDesktopLocation(0, 0);
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.Location = new Point(1, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.Focus();
        }
    }
}
