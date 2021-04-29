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
        string nomeFile = "";
        DateTime dt;
        bool selezionato = false;
        bool ingresso = false;
        public BoxImmagine()
        {
            InitializeComponent();
        }

        public bool leggiImmagineDaFile(string path)
        {
            nomeFile = path;
            return (immagine.leggiImmagineDaFile(path));
        }
        #region ACCESSO
        public DateTime getDateTime()
        {
            DataBaseFoto dbf = Variabili.getDataBaseFotoAttivo();
            if (dbf.elencoFotoPerNome.ContainsKey(nomeFile))
            {
                dt = dbf.elencoFotoPerNome[nomeFile];
            }
            return dt;
        }
        public Image getImmagine()
        {
            return immagine.Image;
        }
        public bool getSselected()
        {
            return selected;
        }
        public string getNomeFile()
        {
            return nomeFile;
        }
        #endregion
        #region AZIONI
        public void ruotaImmagine()
        {
            immagine.ruotaImmagine();

        }
        #endregion
        #region EVENTI

        private void button1_Click(object sender, EventArgs e)
        {
            if (selected)
            {
                button1.BackColor = Color.Black;
                selected = false;
            }
            else
            {
                if (Variabili.primoBoxSelezionato == null)
                    Variabili.primoBoxSelezionato = this;
                button1.BackColor = Color.Red;
                selected = true;
            }
            Variabili.setComandi(Comandi.aggiornaMenuFoto);
        }
        private void BoxImmagine_MouseEnter(object sender, EventArgs e)
        {
            /*timer1.Interval = 10;
            timer1.Start();*/
            selezionato = true;
            //ingresso = true;
            Variabili.codePopup.setImmagine(this.immagine.Image, nomeFile);
            Variabili.mostraFotoCount++;
            Variabili.mostraFoto = true;
        }

        private void immagine_MouseLeave(object sender, EventArgs e)
        {
            /*timer1.Interval = 10;
            timer1.Start();
            selezionato = false;*/
            Variabili.mostraFoto = false;
        }
        #endregion

        /*private void timer1_Tick(object sender, EventArgs e)
        {
            if (selezionato)
            {
                if (ingresso)
                {
                    Variabili.codePopup.setImmagine(this.immagine.Image, nomeFile);
                    Variabili.mostraFotoCount++;
                    Variabili.mostraFoto = true;
                    ingresso = false;
                }
            }
            else
            {
                Variabili.mostraFoto = false;
            }
        }*/
    }
}
