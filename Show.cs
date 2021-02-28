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
        SortedList<int, ImmagineShow> elencoImmagini = new SortedList<int, ImmagineShow>();
        int indice;
        public Show()
        {
            InitializeComponent();
            this.SetDesktopLocation(0, 0);
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.Location = new Point(1, 1);
        }
        public void associaImmagineENome(BoxImmagine immagine, string nome)
        {
            ImmagineShow immShow = new ImmagineShow();
            immShow.boxImmagine = immagine;
            immShow.nome = nome;
            elencoImmagini.Add(elencoImmagini.Count, immShow);
        }
        public void resetImmagini()
        {
            elencoImmagini.Clear();
        }

        private void Show_Shown(object sender, EventArgs e)
        {
            indice = 0;
            timer1.Interval = 2000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (elencoImmagini.Count > 0)
            {
                if (indice >= elencoImmagini.Count)
                {
                    indice = 0;
                }
                ImmagineShow ish = elencoImmagini[indice++];
                // BoxImmagine bi = ish.boxImmagine; // elencoImmagini[indice++].boxImmagine;
                immagine1.Image = ish.boxImmagine.getImmagine(); // bi.getImmagine();
                labelNome.Text = ish.nome;
                resize();
            }
        }
        bool resize()
        {
            int larghezza = this.Size.Width;
            int altezza = this.Size.Height;
            float larghezzaImmagine = immagine1.PreferredSize.Width;
            float altezzaImmagine = immagine1.PreferredSize.Height;
            float rapportoFotoOriginale = larghezzaImmagine / altezzaImmagine;
            ;
            float rapportoFinestra = (float)larghezza / (float)altezza;
            if (rapportoFinestra < rapportoFotoOriginale)
            {
                // comanda larghezza
                immagine1.Width = larghezza;
                float altezzaStimata = larghezza / rapportoFotoOriginale;
                immagine1.Height = (int)altezzaStimata;
                immagine1.Location = new Point(1, (altezza - (int)altezzaStimata) / 2);
            }
            else
            {
                // comanda altezza
                immagine1.Height = altezza;
                float larghezzaStimata = altezza * rapportoFotoOriginale;
                immagine1.Width = (int)larghezzaStimata;
                immagine1.Location = new Point((larghezza - (int)larghezzaStimata) / 2,1);
            }
            // label1.Text = nomeFile;
            return true;
        }

        private void immagine1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    class ImmagineShow
    {
        public BoxImmagine boxImmagine;
        public string nome;
    }
}
