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
    public partial class AndamentoAttivita : UserControl
    {
        //public delegate void Registra(AndamentoAttivita io);
        //public event Registra registra;
        public string inAtto = "";
        public string memoriaNomeAttivita = "";
        public AndamentoAttivita()
        {
            InitializeComponent();
        }
        /*public void Registra()
        {
            registra(this);
        }*/
        public void nomina(string nome)
        {
            nomeAttivita.Text = nome;
        }
        public void aggiorna()
        {
            attivitaSvolta.Text = inAtto;
        }
    }
}
