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
        public BoxImmagine()
        {
            InitializeComponent();
        }

        public bool leggiImmagineDaFile(string path)
        {
            nomeFile = path;
            return (immagine.leggiImmagineDaFile(path));
        }

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
        }

        private void BoxImmagine_MouseEnter(object sender, EventArgs e)
        {
            /*Button b = new Button();
            b.Visible = true;
            b.Image = this.immagine.Image;
            b.Width = 600;
            b.Height = 400;*/
            Variabili.codePopup.setImmagine(this.immagine.Image, nomeFile);
            Variabili.mostraFotoCount++;
            Variabili.mostraFoto = true;
            /*//Form1..ActiveForm.Controls.Add(b);
            this.Parent.Parent.Controls.Add(b);*/
        }

        private void immagine_MouseLeave(object sender, EventArgs e)
        {
            Variabili.mostraFoto = false;
        }
    }
}
