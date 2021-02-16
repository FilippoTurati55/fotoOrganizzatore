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
    public partial class RinominaCartella : Form
    {
        int posizioneDescrizioneDataMinima;
        public RinominaCartella()
        {
            InitializeComponent();
        }
        #region
        public void setnomeErratoCartella(string name)
        {
            int posX = disco.Location.X;
            Font font = disco.Font; 
            Size dim =  TextRenderer.MeasureText(disco.Text, font);
            posX += dim.Width;
            nomeErratoCartella.Text = name;
            font = nomeErratoCartella.Font;
            dim = TextRenderer.MeasureText(nomeErratoCartella.Text, font);
            posX += dim.Width;
            label2.Location = new Point(posX, label2.Location.Y);
        }
        public void setdataMinimaMassima(string newDataMinima, string newDataMassima)
        {
            int posX = descrizioneDataMinima.Location.X;
            Font font = descrizioneDataMinima.Font;
            Size dim = TextRenderer.MeasureText(descrizioneDataMinima.Text, font);
            posX += dim.Width;
            posizioneDescrizioneDataMinima = posX;
            dataMinima.Text = newDataMinima;
            dataMinima.Location = new Point(posizioneDescrizioneDataMinima, this.dataMinima.Location.Y);

            font = aDuepunti.Font;
            dim = TextRenderer.MeasureText(aDuepunti.Text, font);
            posX = posizioneDescrizioneDataMinima - dim.Width;
            aDuepunti.Location = new Point(posX, aDuepunti.Location.Y);
            dataMassima.Text = newDataMassima;
            dataMassima.Location = new Point(posizioneDescrizioneDataMinima, dataMassima.Location.Y);
        }
        public void setnomeCommentoProposto(string name, string commento)
        {
            int posX = label1.Location.X;
            Font font = label1.Font;
            Size dim = TextRenderer.MeasureText(label1.Text, font);
            posX += dim.Width;
            nomeProposto.Text = name;
            nomeProposto.Location = new Point(posX, nomeProposto.Location.Y);
            commentoProposto.Text = name;
            //font = nomeProposto.Font;
            //dim = TextRenderer.MeasureText(nomeProposto.Text, font);
            posX += nomeProposto.Width;
            label4.Location = new Point(posX, label4.Location.Y);
            font = label4.Font;
            dim = TextRenderer.MeasureText(label4.Text, font);
            posX += dim.Width;
            commentoProposto.Location = new Point(posX, commentoProposto.Location.Y);
            commentoProposto.Text = commento;
        }
        public string getCommento()
        {
            return commentoProposto.Text;
        }
        #endregion
        private void accredita_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
