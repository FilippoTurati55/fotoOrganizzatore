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
            // immagine1.Image = leggiImmagineDaFile(@"c:\foto\2018\01 01\\WP_20180101_10_08_18_Rich.jpg");
            Immagine i = new Immagine();
            i.leggiImmagineDaFile(@"c:\foto\2018\01 01\\WP_20180101_10_08_18_Rich.jpg");
            this.Controls.Add(i);
            
        }
    }
}
