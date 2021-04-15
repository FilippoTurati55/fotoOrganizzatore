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
        int aspettaSpegnimentoFoto = 0;
        public Form1()
        {
            InitializeComponent();
            splitContainerAnni.Dock = DockStyle.Fill;
            splitContainerAnni.Visible = false;
            splitContainerCruscotto.Dock = DockStyle.Fill;
            splitContainerCruscotto.Visible = true;
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.Location = new Point(1, 1);
            Preferenze.LeggiPreferenze();
            //Variabili.cruscotto = new Cruscotto(this);
            //Variabili.cruscotto.Show();
            if (Variabili.ArchivioLocale.PreparaCartelleFoto())
            {

                Variabili.dataBaseFotoLocali = new DataBaseFoto(Preferenze.NomeCartellaFotoOrganizzate);
                Variabili.dataBaseFotoLocali.creaDataBase(Variabili.Calendario);
                var t = Task.Run(() => taskCercaDispositivi());
                Variabili.Backup.CercaUnitaEsterne(this);
                // Variabili.Calendario.MostraCalendarioFoto(avvenimenti, false);
                Variabili.comandi = Comandi.mostraCalendarioFoto;
                aggiungiAnni();
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
            /*foreach (Control c in splitContainer1.Panel1.Controls)
            {
                try
                {
                    Avvenimento a = (Avvenimento)c;
                    a.resize();
                }
                catch { }
            }*/
        }

        private void timerBase_Tick(object sender, EventArgs e)
        {
            switch (Variabili.comandi)
            {
                case Comandi.mostraCalendarioFoto:
                    Variabili.Calendario.MostraCalendarioFoto(avvenimenti, false);
                    nomeCartella = "";
                    vignette.Controls.Clear();
                    //Variabili.comandi = Comandi.nessuno;
                    Variabili.comandi = Comandi.aggiornaMenuFoto;
                    break;
                case Comandi.aggiornaMenuFoto:
                    bool accendi = false;
                    for (int n = 0; n < vignette.Controls.Count; n++)
                    {
                        BoxImmagine bi = (BoxImmagine) vignette.Controls[n];
                        if (bi.getSselected())
                        {
                            accendi = true;
                            break;
                        }
                    }
                    // buttonRuota.Visible = accendi;
                    panelAzioniSuFoto.Visible = accendi;
                    if (accendi)
                    {
                        if (Variabili.cestinoMostrato)
                        {
                            buttonCancella.Text = "ripristina";
                        }
                        else
                        {
                            buttonCancella.Text = "cancella";
                        }
                    }
                    Variabili.comandi = Comandi.nessuno;
                    break;
            }
            if (Variabili.MostraFotoInGiorno != Variabili.MostraFotoInGiornoPrevValue)
            {
                Variabili.MostraFotoInGiornoPrevValue = Variabili.MostraFotoInGiorno;
                numeroFotoMostrate = 0;
                vignette.Controls.Clear();
                Variabili.comandi = Comandi.aggiornaMenuFoto;
                Variabili.show.resetImmagini();
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
                            if (FileImmagini.IsImage(src))
                            {
                                if (vignetta.leggiImmagineDaFile(src))
                                {
                                    vignette.Controls.Add(vignetta);
                                    Variabili.show.associaImmagineENome(vignetta,src);
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
                            else
                            {
                                // è presente un file non immagine,
                                // potrebbe essere mostrato in un altro modo
                                // todo
                                numeroFotoMostrate++;
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
            if (Variabili.showFoto)
            {
                Show show = new Show();
                DialogResult dr;
                dr = show.ShowDialog();
            }
            if (Variabili.mostraFoto)
            {
                if (Variabili.mostraFotoCount > mostrato)
                {
                    if (!this.Controls.Contains(Variabili.codePopup))
                    {
                        this.Controls.Add(Variabili.codePopup);
                    }//splitContainer1.Panel1.Controls.Add(Variabili.codePopup);
                    int larghezza;
                    int altezza;
                    /*if (Variabili.showFoto)
                    {
                        // è una prova
                        larghezza = splitContainer1.Size.Width;
                        altezza = splitContainer1.Size.Height;
                    }
                    else
                    {*/
                    larghezza = avvenimenti.Size.Width; // splitContainer1.Panel1.Size.Width;
                    altezza = avvenimenti.Size.Height; // splitContainer1.Panel1.Size.Height;
                    //}
                    //Variabili.codePopup.Size = new Size(larghezza, 400);
                    Variabili.codePopup.Location = new Point(1, 1);
                    //Variabili.codePopup.Dock = DockStyle.Fill;
                    Variabili.codePopup.resize(larghezza, altezza);
                    Variabili.codePopup.Enabled = true;
                    Variabili.codePopup.BringToFront();
                    Variabili.codePopup.Refresh();
                    mostrato++;
                    aspettaSpegnimentoFoto = 3;
                }
            }
            else
            {
                if (aspettaSpegnimentoFoto <= 0)
                {
                    if (this.Controls.Contains(Variabili.codePopup))
                        this.Controls.Remove(Variabili.codePopup);
                }
                else
                {
                    aspettaSpegnimentoFoto--;
                }
            }
            if (Variabili.mostraCartellaSpeciale)
            {
                // Calendario va messo nelle variabili globali
                Calendario calendario = new Calendario();
                DataBaseFoto dataBaseFotoLocali = new DataBaseFoto(Variabili.nomeCartellaSpeciale);
                dataBaseFotoLocali.creaDataBase(calendario, 1);
                calendario.MostraCalendarioFoto(avvenimenti, false);
                elencoFotiDaMostrareInVignetta = Directory.GetFiles(Variabili.nomeCartellaSpeciale);
                numeroFotoDaMostrare = elencoFotiDaMostrareInVignetta.Count();
                posX = posY = 0;
                numeroFotoMostrate = 0;
                vignette.Controls.Clear();
                Variabili.show.resetImmagini();
                System.GC.Collect();
                buttonRoot.Text = Variabili.nomeCartellaSpeciale;
                aggiornaSplitContinerAnni();
                Variabili.mostraCartellaSpeciale = false;
            }
        }

        private void show_Click(object sender, EventArgs e)
        {
            //Variabili.showFoto = !Variabili.showFoto;
            //Show show = new Show();
            Variabili.show.SetDesktopLocation(0, 0);
            DialogResult dr;
            dr = Variabili.show.ShowDialog();
        }
        public int getLarghezza()
        {
            return this.Size.Width;
        }
        public int getAltezza()
        {
            return this.Size.Height;
        }

        private void avvenimenti_Resize(object sender, EventArgs e)
        {
            Panel contenitore = (Panel)sender;
            foreach (Control c in contenitore.Controls)
            {
                try
                {
                    Avvenimento a = (Avvenimento)c;
                    a.resize();
                }
                catch { }
            }

        }

        private void buttonRoot_Click(object sender, EventArgs e)
        {
            int livelloRicorsione = getLivelloRicorsione();
            if (livelloRicorsione == 3)
            {
                // ritorniamo a mostrare il calendario di eventi base
                Variabili.nomeCartellaSpeciale = "";
                Variabili.Calendario.MostraCalendarioFoto(avvenimenti, false);
                buttonRoot.Text = "[...]";
                vignette.Controls.Clear();
                aggiornaSplitContinerAnni();
                Variabili.comandi = Comandi.aggiornaMenuFoto;
                nomeCartella = "";
            }
            else
            {
                if (livelloRicorsione > 3)
                {
                    string accorcia = Variabili.nomeCartellaSpeciale.Substring(0, Variabili.nomeCartellaSpeciale.LastIndexOf('\\'));
                    Variabili.nomeCartellaSpeciale = accorcia;
                    Variabili.mostraCartellaSpeciale = true;
                    buttonRoot.Text = accorcia;
                }
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
        #region PROCEDURE
        void aggiornaSplitContinerAnni()
        {
            //Button broot = buttonRoot;
            if (getLivelloRicorsione() > 2)
            {
                // stiamo mostrando una cartella speciale
                if (panelAnni.Controls.Count > 1)
                {
                    panelAnni.Controls.Clear();
                    panelAnni.Controls.Add(buttonRoot);
                }
            }
            else
            {
                if (panelAnni.Controls.Count < 3)
                {
                    aggiungiAnni();
                }
            }
        }
        void aggiungiAnni()
        {
            int posizione = buttonRoot.Width;
            //foreach ( var anni in Variabili.dataBaseFotoLocali.anni)
            foreach (var elemento in Variabili.dataBaseFotoLocali.anniComponenti)
            {
                //Anno anno = new Anno();
                //anno.setNomeAnno(anni.Value);
                Anno anno = elemento.Value;
                panelAnni.Controls.Add(anno);
                anno.Location = new Point(posizione, 1);
                posizione += anno.Width;
            }
        }
        int getLivelloRicorsione()
        {
            string pathAttuale = Variabili.nomeCartellaSpeciale;
            string[] pathSplit = pathAttuale.Split('\\');
            return (pathSplit.Length);
        }
        #endregion
        #region EVENTI
        private void buttonRuota_Click(object sender, EventArgs e)
        {
            for (int n = 0; n < vignette.Controls.Count; n++)
            {
                BoxImmagine bi = (BoxImmagine)vignette.Controls[n];
                if (bi.getSselected())
                {
                    bi.ruotaImmagine();
                    break;
                }
            }
        }
        private void buttonCancella_Click(object sender, EventArgs e)
        {
            for (int n = 0; n < vignette.Controls.Count; n++)
            {
                BoxImmagine bi = (BoxImmagine)vignette.Controls[n];
                if (bi.getSselected())
                {
                    string nomeFile = bi.getNomeFile();
                    if (buttonCancella.Text == "ripristina")
                    {
                        Utility.ripristinaFoto(nomeFile);
                    }
                    else
                    {
                        Utility.cancellaFoto(nomeFile);
                    }
                }
            }
        }

        private void Cruscotto_Click(object sender, EventArgs e)
        {
            splitContainerAnni.Visible = false;
            splitContainerCruscotto.Visible = true;
            //Variabili.cruscotto.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            splitContainerCruscotto.Visible = false;
            splitContainerAnni.Visible = true;
        }
        #endregion
        #region CRUSCOTTO
        public void AggiungiDiscoBackup()
        {
            Discobackup db = new Discobackup();
            splitContainerUpDx.Panel2.Controls.Add(db);
        }
        #endregion
    }
}
