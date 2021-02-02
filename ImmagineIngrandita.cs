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
    public partial class ImmagineIngrandita : UserControl
    {
        bool selected = false;
        int numeroResize = 0;
        string nomeFile = "";
        public ImmagineIngrandita()
        {
            InitializeComponent();
        }
        #region ACCESSO
        public void setImmagine(Image i, string nome)
        {
            immagine.Image = i;
            nomeFile = nome;
        }
        #endregion
        #region RESIZE
        public bool resize(int larghezza,int altezza)
        {
            numeroResize++;
            float larghezzaImmagine = immagine.PreferredSize.Width;
            float altezzaImmagine = immagine.PreferredSize.Height;
            float rapportoFotoOriginale = larghezzaImmagine / altezzaImmagine;
            ;
            float rapportoFinestra = (float)larghezza / (float)altezza;
            if (rapportoFinestra < rapportoFotoOriginale)
            {
                // comanda larghezza
                //immagine.Width = larghezza;
                this.Width = larghezza;
                float altezzaStimata = larghezza / rapportoFotoOriginale;
                // immagine.Height = (int)altezzaStimata;
                this.Height = (int)altezzaStimata;
            }
            else
            {
                // comanda altezza
                //immagine.Height = altezza;
                this.Height = altezza;
                float larghezzaStimata = altezza * rapportoFotoOriginale;
                // immagine.Width = (int)larghezzaStimata;
                this.Width = (int)larghezzaStimata;
            }

            //this.Width = immagine.Width;
            //this.Height = immagine.Height;
            //this.Refresh();
            //immagine.Refresh();
            label1.Text = nomeFile;
            return true;
        }
        #endregion 
    }
}
