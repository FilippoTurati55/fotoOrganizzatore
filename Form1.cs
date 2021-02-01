using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using external_drive_lib.interfaces;

namespace FotoOrganizzatore
{
    public partial class Form1 : Form
    {
        int numeroFotoMostrate = 0;
        int numeroFotoDaMostrare = 0;
        string nomeCartella = "";
        string[] elencoFotiDaMostrareInVignetta;
        int posX, posY;
        int mostrato = 0;
        int ritardoErroreLettura = 0;
        public Form1()
        {
            InitializeComponent();
            Preferenze.LeggiPreferenze();
            if (Variabili.ArchivioLocale.PreparaCartelleFoto())
            {
                var t = Task.Run(() => taskCercaDispositivi());
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
                try
                {
                    Avvenimento a = (Avvenimento)c;
                    a.resize();
                }
                catch { }
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
                System.GC.Collect();
                SetDataOraBase puntato = Variabili.MostraFotoSetDataOra;
                nomeCartella = puntato.nomeCompletoCartella;
                elencoFotiDaMostrareInVignetta = Directory.GetFiles(nomeCartella);
                numeroFotoDaMostrare = elencoFotiDaMostrareInVignetta.Count();
                posX = posY = 0;
            }
            if (nomeCartella != "")
            {
                if (ritardoErroreLettura <= 0)
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
                            if (vignetta.leggiImmagineDaFile(src))
                            {
                                splitContainer1.Panel2.Controls.Add(vignetta);
                                vignetta.Location = new Point(posX, posY);
                                posX += vignetta.Width;
                                if (posX > vignetta.Width * 4)
                                {
                                    posX = 0;
                                    posY += vignetta.Height;
                                }
                                numeroFotoMostrate++;
                            }
                            else
                            {
                                ritardoErroreLettura = 20;
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                else
                {
                    ritardoErroreLettura--;
                }
            }
            if (Variabili.mostraFoto)
            {
                if (Variabili.mostraFotoCount > mostrato)
                {
                    this.Controls.Add(Variabili.codePopup);
                    //splitContainer1.Panel1.Controls.Add(Variabili.codePopup);
                    int larghezza = splitContainer1.Panel1.Size.Width;
                    int altezza = splitContainer1.Panel1.Size.Height;
                    //Variabili.codePopup.Size = new Size(larghezza, 400);
                    Variabili.codePopup.Location = new Point(1, 1);
                    //Variabili.codePopup.Dock = DockStyle.Fill;
                    Variabili.codePopup.resize(larghezza, altezza);
                    Variabili.codePopup.Enabled = true;
                    Variabili.codePopup.BringToFront();
                    Variabili.codePopup.Refresh();
                    mostrato++;
                }
            }
            else
            {
                if (this.Controls.Contains(Variabili.codePopup))
                    this.Controls.Remove(Variabili.codePopup);
            }
        }
        void taskCercaDispositivi()
        {
            while (!Variabili.fermaTaskRicercaDispositivi)
            {
                PortableDrivers.Show_all_portable_drives();  // 1.4 s
                if (PortableDrivers.elencoDispositiviUsb.Count > 0)
                {
                    while (Variabili.NumeroDispositiviUsbTrovatiInEsame < PortableDrivers.elencoDispositiviUsb.Count)
                    {
                        Object[] portable_drives = PortableDrivers.elencoDispositiviUsb.ToArray();
                        // var dispositivoTrovato = PortableDrivers.CercaCartellaCameraInTuttiIDispositiviUsb();
                        IDrive pd = (IDrive)portable_drives[Variabili.NumeroDispositiviUsbTrovatiInEsame++];
                        int dispositivoTrovato = PortableDrivers.CercaCartellaCameraInUnDispositivoUsb(pd);
                        if ((dispositivoTrovato >= 0) && (PortableDrivers.elencoDispositiviUsb.Count > dispositivoTrovato))
                        {
                            ;// messaggi.Text = "trovato " + PortableDrivers.elencoDispositiviUsb[dispositivoTrovato].ToString() + " corretto";
                        }
                        else
                        {
                            ;// messaggi.Text = "trovato " + PortableDrivers.elencoDispositiviUsb[0].ToString() + " senza cartella CAMERA";
                        }
                        PortableDrivers.Enumerate_all_camera_pics();
                    }
                }
                else
                {
                    ;// messaggi.Text = "trovato niente";
                }
                Thread.Sleep(1000);
            }
        }
    }
}
