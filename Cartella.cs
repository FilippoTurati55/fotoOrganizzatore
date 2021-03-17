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
    public partial class Cartella : UserControl
    {
        public CartellaBase Cab = null;
        public Cartella()
        {
            InitializeComponent();
        }
        public Cartella(CartellaBase collegamentoParent)
        {
            InitializeComponent();
            Cab = collegamentoParent;
        }
        #region RESIZE
        public bool resize()
        {
            int larghezza = Parent.Width - 25;
            int posX = 1;
            buttonNomeCartella.Location = new Point(2,2);
            Font font = new Font("Times new roman", 12);
            Size occupazioneStringaInizio = TextRenderer.MeasureText("0000 00 00 mercoledì", font);
            buttonNomeCartella.Width = occupazioneStringaInizio.Width;
            posX += buttonNomeCartella.Width + 1;
            return true;
        }
        #endregion
        #region ACCESSO
        public void setNomeCartella(string nome)
        {
            buttonNomeCartella.Text = nome;
        }
        #endregion

        private void buttonNomeCartella_Click(object sender, MouseEventArgs e)
        {
            // calendario e dataBaseFotoLocali vanno messi nelle variabili statiche
            Variabili.nomeCartellaSpeciale = Cab.getPathCompleto();
            Variabili.mostraCartellaSpeciale = true;

        }
    }
}
