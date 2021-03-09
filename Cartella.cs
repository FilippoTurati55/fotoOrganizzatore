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
            nomeCartella.Location = new Point(2,2);
            Font font = new Font("Times new roman", 12);
            Size occupazioneStringaInizio = TextRenderer.MeasureText("0000 00 00 mercoledì", font);
            nomeCartella.Width = occupazioneStringaInizio.Width;
            posX += nomeCartella.Width + 1;
            return true;
        }
        #endregion
        #region ACCESSO
        public void setNomeCartella(string nome)
        {
            nomeCartella.Text = nome;
        }
        #endregion

        private void nomeCartella_Click(object sender, EventArgs e)
        {
            // todo
            calendario e dataBaseFotoLocali vanno messi nelle variabili statiche
            string nomeCartella = Cab.getPathCompleto();
            Calendario calendario = new Calendario();
            // Panel pan = Cab.getSplitterPanel();
            DataBaseFoto dataBaseFotoLocali = new DataBaseFoto(nomeCartella);
            dataBaseFotoLocali.creaDataBase(calendario,1);
            Variabili.mostraCartellaSpeciale = true;
        }
    }
}
