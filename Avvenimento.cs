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
    public partial class Avvenimento : UserControl
    // in fotografo si chiamava SetDataOra
    {
        Color ColorePrimaDiEvidenziatura;
        public delegate void EventoClickEventHandler(Avvenimento click);
        public event EventoClickEventHandler EventoClick;
        public delegate void EventoModificaCommentoEventHandler(Avvenimento modificaCommento);
        public event EventoModificaCommentoEventHandler EventoModificaCommento;
        public Avvenimento()
        {
            InitializeComponent();
        }
        #region EVENTI
        private void SetInizioFine_Click(object sender, EventArgs e)
        {
            if (EventoClick != null)
            {
                EventoClick.Invoke(this);
            }
        }

        private void data_MouseEnter(object sender, EventArgs e)
        {
            Variabili.MostraFotoInGiorno++; // = true;
            Variabili.MostraFotoSetDataOra = this;
            TextBox tb = (TextBox)sender;
            if (Variabili.DataOraEvidenziata != null)
            {
                Variabili.DataOraEvidenziata.BackColor = ColorePrimaDiEvidenziatura;
            }
            Variabili.DataOraEvidenziata = tb;
            ColorePrimaDiEvidenziatura = tb.BackColor;
            tb.BackColor = Color.Red;
        }

        private void Evento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CambiaNomeEvento();
        }
        private void Evento_LostFocus(object sender, EventArgs e)
        {
            CambiaNomeEvento();
        }
        bool CambiaNomeEvento()
        {
            bool cambiato = false;
            if (EventoModificaCommento != null)
            {
                EventoModificaCommento.Invoke(this);
            }
            return cambiato;
        }
        #endregion
        #region RESIZE
        public bool resize()
        {
            //int larghezza = this.Width;
            int larghezza = Parent.Width;
            int altezza = Height;
            int posX = 1;
            statoButton.Location = new Point(2, 2);
            statoButton.Height = dataInizio.Height - 1;
            statoButton.Width = statoButton.Height;
            posX += statoButton.Width + 2;
            dataInizio.Location = new Point(posX, 1);
            //dataInizio.Height = altezza - 2;
            //dataInizio.Width = (larghezza - 2) / 10;
            Font font = new Font("Times new roman", 12);
            Size occupazioneStringaInizio = TextRenderer.MeasureText("0000 00 00 mercoledì", font);
            dataInizio.Width = occupazioneStringaInizio.Width;
            posX += dataInizio.Width + 1;
            dataFine.Location = new Point(posX, 1);
            dataFine.Visible = (dataFine.Text != "");
            //dataFine.Height = altezza - 2;
            Size occupazioneStringaFine = TextRenderer.MeasureText("0000 00", font);
            dataFine.Width = occupazioneStringaFine.Width;
            posX += dataFine.Width + 1;
            commento.Location = new Point(posX, 1);
            //commento.Height = altezza - 2;
            commento.Width = larghezza - posX - 1;
            return true;
        }
        #endregion
    }
}
