﻿using System;
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
        public SetDataOraBase Sdob = null;
        public Avvenimento()
        {
            InitializeComponent();
        }
        public Avvenimento(SetDataOraBase collegamentoParent)
        {
            InitializeComponent();
            Sdob = collegamentoParent;
        }
        #region ACCESSO
        public void setCommento(string valore)
        {
            commento.Text = valore;
        }
        public string getCommento()
        {
            return commento.Text;
        }
        public void setDataFine()
        {
            if (Sdob != null)
                dataFine.Text = Sdob.GetTestoDataFine();
            else dataFine.Text = "";
        }
        public void setDataFine(string valore)
        {
            dataFine.Text = valore;
        }
        public void setDataInizio(string valore)
        {
            dataInizio.Text = valore;
        }
        public void setStato(STATO_SELEZIONE_DATA value)
        {
            switch (value)
            {
                case STATO_SELEZIONE_DATA.NIENTE:
                    statoButton.BackColor = SystemColors.Control;
                    break;
                case STATO_SELEZIONE_DATA.INIZIO:
                    statoButton.BackColor = Color.Red;
                    break;
                case STATO_SELEZIONE_DATA.FINE:
                    statoButton.BackColor = Color.Pink;
                    //apriChiudi.Visibility = Visibility.Visible;
                    break;
                case STATO_SELEZIONE_DATA.INTERMEDIO:
                    statoButton.BackColor = Color.Yellow;
                    break;
                case STATO_SELEZIONE_DATA.GIA_PRESENTE:
                    statoButton.BackColor = Color.Gray;
                    break;
            }

        }
        #endregion
        #region EVENTI
        public void resetEventiClick()
        {
            EventoClick = null;
            EventoModificaCommento = null;
        }
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
            Variabili.MostraFotoSetDataOra = this.Sdob;
            Variabili.primoBoxSelezionato = null;
            TextBox tb = (TextBox)sender;
            if (Variabili.DataOraEvidenziata != null)
            {
                // Variabili.DataOraEvidenziata.BackColor = ColorePrimaDiEvidenziatura;
                Variabili.DataOraEvidenziata.dataInizio.BackColor = 
                    Variabili.DataOraEvidenziata.dataFine.BackColor = 
                    Variabili.DataOraEvidenziata.commento.BackColor = ColorePrimaDiEvidenziatura;
            }
            Variabili.DataOraEvidenziata = this;
            ColorePrimaDiEvidenziatura = tb.BackColor;
            // tb.BackColor = Color.Red;
            dataInizio.BackColor = dataFine.BackColor = commento.BackColor = Color.Red;
            Variabili.cestinoMostrato = false;
            Variabili.setComandi(Comandi.aggiornaMenuFoto);
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
                EventoModificaCommento = null;
            }
            return cambiato;
        }
        #endregion
        #region RESIZE
        public bool resize()
        {
            int larghezza = Parent.Width - 25;
            int posX = 1;
            statoButton.Location = new Point(2, 2);
            statoButton.Height = dataInizio.Height - 1;
            statoButton.Width = statoButton.Height;
            posX += statoButton.Width + 2;
            dataInizio.Location = new Point(posX, 1);
            Font font = new Font("Times new roman", 12);
            Size occupazioneStringaInizio = TextRenderer.MeasureText("0000 00 00 mercoledì", font);
            dataInizio.Width = occupazioneStringaInizio.Width;
            posX += dataInizio.Width + 1;
            dataFine.Location = new Point(posX, 1);
            dataFine.Visible = (dataFine.Text != "");
            Size occupazioneStringaFine = TextRenderer.MeasureText("0000 00", font);
            dataFine.Width = occupazioneStringaFine.Width;
            posX += dataFine.Width + 1;
            commento.Location = new Point(posX, 1);
            commento.Width = larghezza - posX - 1;
            return true;
        }
        #endregion
    }
}
