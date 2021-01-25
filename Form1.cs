using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoOrganizzatore
{
    public partial class Form1 : Form
    {
        int numeroFotoMostrate = 0;
        int numeroFotoDaMostrare = 0;
        string nomeCartella = "";
        string[] elencoFotiDaMostrareInVignetta;
        public Form1()
        {
            InitializeComponent();
            Preferenze.LeggiPreferenze();
            if (Variabili.ArchivioLocale.PreparaCartelleFoto())
            {
                Variabili.Backup.CercaUnitaEsterne();
                Variabili.dataBaseFotoLocali = new DataBaseFoto(Preferenze.NomeCartellaFotoOrganizzate);
                Variabili.dataBaseFotoLocali.creaDataBase();
                Variabili.Calendario.MostraCalendarioFoto(splitContainer1.Panel1, false);
                // Variabili.Calendario.ElencaDateFotoCatalogate();
                /*Immagine i = new Immagine();
                i.leggiImmagineDaFile(@"c:\foto\2018\01 01\\WP_20180101_10_08_18_Rich.jpg");
                this.Controls.Add(i);
                */
                /* BoxImmagine bi = new BoxImmagine();
                bi.leggiImmagineDaFile(@"c:\foto\2018\01 01\\WP_20180101_10_08_18_Rich.jpg");
                this.Controls.Add(bi);
                */
                /*Avvenimento a1 = new Avvenimento();
                Avvenimento a2 = new Avvenimento();
                // this.Controls.Add(a);
                splitContainer1.Panel1.Controls.Add(a1);
                a1.resize();
                splitContainer1.Panel1.Controls.Add(a2);
                a2.Location = new Point(0, a1.Height);*/
            }
            // mostra messaggio mancata creazione cartella archivio locale foto
            timerBase.Interval = 100;
            timerBase.Start();
        }

        private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            foreach (Control c in splitContainer1.Panel1.Controls)
            {
                Avvenimento a = (Avvenimento)c;
                a.resize();
            }
        }

        private void timerBase_Tick(object sender, EventArgs e)
        {
            switch (Variabili.comandi)
            {
                case 1:
                    Variabili.Calendario.MostraCalendarioFoto(splitContainer1.Panel1, false);
                    Variabili.comandi = 0;
                    break;
            }
            if (Variabili.MostraFotoInGiorno != Variabili.MostraFotoInGiornoPrevValue)
            {
                Variabili.MostraFotoInGiornoPrevValue = Variabili.MostraFotoInGiorno;
                numeroFotoMostrate = 0;
                splitContainer1.Panel2.Controls.Clear();
                SetDataOraBase puntato = Variabili.MostraFotoSetDataOra;
                nomeCartella = puntato.nomeCompletoCartella;
                elencoFotiDaMostrareInVignetta = Directory.GetFiles(nomeCartella);
                numeroFotoDaMostrare = elencoFotiDaMostrareInVignetta.Count();
            }
            if (nomeCartella != "")
            {
                if (numeroFotoMostrate < numeroFotoDaMostrare)
                {
                    string src;
                    string prevsrc;
                    BoxImmagine vignetta = new BoxImmagine();
                    bool trovatoQualcosa = false;
                    try
                    {
                        src = elencoFotiDaMostrareInVignetta[numeroFotoMostrate];
                        vignetta.leggiImmagineDaFile(src);
                        splitContainer1.Panel2.Controls.Add(vignetta);
                        numeroFotoMostrate++;

                        /*FileStream stream = new FileStream(src, FileMode.Open, FileAccess.Read);
                        System.Drawing.Image myImage = System.Drawing.Image.FromStream(stream);
                        stream.Close();

                        BitmapImage image = new BitmapImage();
                        image.BeginInit();
                        image.UriSource = new Uri(src);
                        image.EndInit();
                        Image img = new Image();
                        img.Source = image;*/

                        /*
                        string src = Variabili.NomeCartellaFotoInCartella[Variabili.NomeCartellaNumeroFoto++];
                        Image img = new Image();
                        var uri = new Uri(src);
                        var img1 = new BitmapImage(uri);
                        img.Source = img1;
                        */
                        // img.Source = new ImageSourceConverter().ConvertFromString(src) as ImageSource;

                        //Vignetta vignetta = new Vignetta();
                        //vignetta.setImmagine(img);
                        //SelezioneFotoSP.Children.Add(vignetta);
                        //vignetta.Visibility = Visibility.Visible;
                        // ripristina per vedere 
                        /* oraif (gruppoVignette.setImmagine(n, src))
                        {
                            //gruppoVignette.setImmagine(n, myImage);

                            trovatoQualcosa = true;
                            prevsrc = src;
                        }
                        else
                        {
                            // segnalare errore
                            n--;
                        } */
                    }
                    catch
                    {
                        // segnalare errore
                        //n--;
                    }
                    /*if (trovatoQualcosa)
                    {
                        SelezioneFotoSP.Children.Add(gruppoVignette);
                        gruppoVignette.Visibility = Visibility.Visible;
                    }*/
                }
            }
        }
    }
}
