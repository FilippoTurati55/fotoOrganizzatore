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
        int annoCartellaIniziale;
        bool annoModificato;
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
            string[] nomeSplit = name.Split('\\');
            annoCartellaIniziale = 0;
            Int32.TryParse(nomeSplit[2], out annoCartellaIniziale);
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
        public void setnomeCommentoProposto(DateTime dataMinima, DateTime dataMassima, string commento)
        {
            int posX = label1.Location.X;
            Font font = label1.Font;
            Size dim = TextRenderer.MeasureText(label1.Text, font);
            posX += dim.Width;
            string name = Utility.CalcolaNomeCartella(dataMinima, dataMassima);
            if (annoCartellaIniziale != dataMinima.Year)
            {
                // le foto presenti nella cartella sono di un altro anno!
                nomeProposto.Text = dataMinima.Year.ToString("D4") + @"\" + name;
                nomeProposto.BackColor = Color.Yellow;
                annoModificato = true;
            }
            else
            {
                nomeProposto.Text = name;
                nomeProposto.BackColor = SystemColors.Window;
                annoModificato = false;
            }
            nomeProposto.Location = new Point(posX, nomeProposto.Location.Y);
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
        public string getNome()
        {
            return nomeProposto.Text;
        }
        public bool getAnnoModificato()
        {
            return annoModificato;
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
