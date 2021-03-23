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
        public Image getImmagine()
        {
            return immagine.Image;
        }
        public void ruotaImmagine()
        {
            immagine.ruotaImmagine();
           
        }
        public bool getSselected()
        {
            return selected;
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
                button1.BackColor = Color.Red;
                selected = true;
            }
            Variabili.comandi = Comandi.aggiornaMenuFoto;
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
