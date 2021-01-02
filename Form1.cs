using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoOrganizzatore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Preferenze.LeggiPreferenze();
            Variabili.Backup.CercaUnitaEsterne();
            /*Immagine i = new Immagine();
            i.leggiImmagineDaFile(@"c:\foto\2018\01 01\\WP_20180101_10_08_18_Rich.jpg");
            this.Controls.Add(i);
            */
            /* BoxImmagine bi = new BoxImmagine();
            bi.leggiImmagineDaFile(@"c:\foto\2018\01 01\\WP_20180101_10_08_18_Rich.jpg");
            this.Controls.Add(bi);
            */
            Avvenimento a1 = new Avvenimento();
            Avvenimento a2 = new Avvenimento();
            // this.Controls.Add(a);
            splitContainer1.Panel1.Controls.Add(a1);
            a1.resize();
            splitContainer1.Panel1.Controls.Add(a2);
            a2.Location = new Point(0, a1.Height);
        }

        private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            foreach (Control c in splitContainer1.Panel1.Controls)
            {
                Avvenimento a = (Avvenimento)c;
                a.resize();
            }
        }
    }
}
