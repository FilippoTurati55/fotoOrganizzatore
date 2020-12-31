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
    public partial class BoxImmagine : UserControl
    {
        bool selected = false;
        public BoxImmagine()
        {
            InitializeComponent();
        }

        public void leggiImmagineDaFile(string path)
        {
            immagine.leggiImmagineDaFile(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selected)
            {
                button1.BackColor = Color.Black;
                selected = false;
            }
            else
            {
                button1.BackColor = Color.Red;
                selected = true;
            }
        }
    }
}
