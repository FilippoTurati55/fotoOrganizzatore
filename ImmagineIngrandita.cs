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
        public ImmagineIngrandita()
        {
            InitializeComponent();
        }
        #region ACCESSO
        public void setImmagine(Image i)
        {
            immagine.Image = i;
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
            label1.Text = "n res=" + numeroResize + " larghezza imma=" +larghezzaImmagine + " altezza imma=" + altezzaImmagine + " rapporto=" + rapportoFotoOriginale + " larghezza=" + larghezza + " altezza =" + altezza + " - larghezza = " + this.Width + "  altezza = " + this.Height;
            return true;
        }
        #endregion 
    }
}
