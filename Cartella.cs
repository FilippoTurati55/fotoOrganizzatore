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
            dataInizio.Location = new Point(2,2);
            Font font = new Font("Times new roman", 12);
            Size occupazioneStringaInizio = TextRenderer.MeasureText("0000 00 00 mercoledì", font);
            dataInizio.Width = occupazioneStringaInizio.Width;
            posX += dataInizio.Width + 1;
            return true;
        }
        #endregion
    }
}
