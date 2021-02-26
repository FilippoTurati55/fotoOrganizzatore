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
    public partial class Show : Form
    {
        SortedList<int, BoxImmagine> elencoImmagini = new SortedList<int, BoxImmagine>();
        int indice;
        public Show()
        {
            InitializeComponent();
            this.SetDesktopLocation(0, 0);
        }
        public void associaImmagine(BoxImmagine immagine)
        {
            elencoImmagini.Add(elencoImmagini.Count, immagine);
        }
        public void resetImmagini()
        {
            elencoImmagini.Clear();
        }

        private void Show_Shown(object sender, EventArgs e)
        {
            indice = 0;
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BoxImmagine bi = elencoImmagini[indice];
            immagine1.Image = bi.BackgroundImage;      
        }
    }
}
