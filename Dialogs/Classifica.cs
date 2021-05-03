using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoOrganizzatore.Dialogs
{
    public partial class Classifica : Form
    {
        public Classifica()
        {
            InitializeComponent();
        }

        public void elencaClassificazioniPresenti()
        {
            DataBaseFoto dbf = Variabili.getDataBaseFotoAttivo();
            for (int n = 0; n < dbf.classificazioni.Count; n++)
            {
                string classificazione = dbf.classificazioni.Keys[n];
                listBoxElencoClassificazioni.Items.Add(classificazione);
            }
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            switch (e.KeyValue)
            {
                case 13:    // enter
                    aggiungiClassificazione(tb.Text);
                    break;
            }
        }

        void aggiungiClassificazione(string nuovo)
        {
            DataBaseFoto dbf = Variabili.getDataBaseFotoAttivo();
            if (!dbf.classificazioni.ContainsKey(nuovo))
            {
                dbf.classificazioni.Add(nuovo, null);
            }
        }
    }
}
