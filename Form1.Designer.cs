﻿
namespace FotoOrganizzatore
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainerAnni = new System.Windows.Forms.SplitContainer();
            this.avvenimenti = new System.Windows.Forms.Panel();
            this.panelAnni = new System.Windows.Forms.Panel();
            this.buttonRoot = new System.Windows.Forms.Button();
            this.vignette = new System.Windows.Forms.Panel();
            this.comandi = new System.Windows.Forms.Panel();
            this.buttonClassifica = new System.Windows.Forms.Button();
            this.Cruscotto = new System.Windows.Forms.Button();
            this.panelAzioniSuFoto = new System.Windows.Forms.Panel();
            this.buttonSelezionaTutti = new System.Windows.Forms.Button();
            this.buttonCambiaData = new System.Windows.Forms.Button();
            this.classifica = new System.Windows.Forms.Button();
            this.buttonRuota = new System.Windows.Forms.Button();
            this.buttonCancella = new System.Windows.Forms.Button();
            this.show = new System.Windows.Forms.Button();
            this.timerBase = new System.Windows.Forms.Timer(this.components);
            this.splitContainerCruscotto = new System.Windows.Forms.SplitContainer();
            this.splitContainerUp = new System.Windows.Forms.SplitContainer();
            this.panelAndamenti = new System.Windows.Forms.Panel();
            this.splitContainerUpDx = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.messaggiGlobali = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAnni)).BeginInit();
            this.splitContainerAnni.Panel1.SuspendLayout();
            this.splitContainerAnni.Panel2.SuspendLayout();
            this.splitContainerAnni.SuspendLayout();
            this.panelAnni.SuspendLayout();
            this.comandi.SuspendLayout();
            this.panelAzioniSuFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCruscotto)).BeginInit();
            this.splitContainerCruscotto.Panel1.SuspendLayout();
            this.splitContainerCruscotto.Panel2.SuspendLayout();
            this.splitContainerCruscotto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerUp)).BeginInit();
            this.splitContainerUp.Panel1.SuspendLayout();
            this.splitContainerUp.Panel2.SuspendLayout();
            this.splitContainerUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerUpDx)).BeginInit();
            this.splitContainerUpDx.Panel1.SuspendLayout();
            this.splitContainerUpDx.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerAnni
            // 
            this.splitContainerAnni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerAnni.Location = new System.Drawing.Point(0, 0);
            this.splitContainerAnni.Name = "splitContainerAnni";
            // 
            // splitContainerAnni.Panel1
            // 
            this.splitContainerAnni.Panel1.AutoScroll = true;
            this.splitContainerAnni.Panel1.Controls.Add(this.avvenimenti);
            this.splitContainerAnni.Panel1.Controls.Add(this.panelAnni);
            this.splitContainerAnni.Panel1.Resize += new System.EventHandler(this.splitContainer1_Panel1_Resize);
            // 
            // splitContainerAnni.Panel2
            // 
            this.splitContainerAnni.Panel2.AutoScroll = true;
            this.splitContainerAnni.Panel2.Controls.Add(this.vignette);
            this.splitContainerAnni.Panel2.Controls.Add(this.comandi);
            this.splitContainerAnni.Size = new System.Drawing.Size(3459, 503);
            this.splitContainerAnni.SplitterDistance = 1385;
            this.splitContainerAnni.TabIndex = 0;
            // 
            // avvenimenti
            // 
            this.avvenimenti.AutoScroll = true;
            this.avvenimenti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.avvenimenti.Location = new System.Drawing.Point(0, 60);
            this.avvenimenti.Name = "avvenimenti";
            this.avvenimenti.Size = new System.Drawing.Size(1383, 441);
            this.avvenimenti.TabIndex = 2;
            this.avvenimenti.Resize += new System.EventHandler(this.avvenimenti_Resize);
            // 
            // panelAnni
            // 
            this.panelAnni.AutoSize = true;
            this.panelAnni.BackColor = System.Drawing.SystemColors.Info;
            this.panelAnni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAnni.Controls.Add(this.buttonRoot);
            this.panelAnni.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAnni.Location = new System.Drawing.Point(0, 0);
            this.panelAnni.MinimumSize = new System.Drawing.Size(2, 60);
            this.panelAnni.Name = "panelAnni";
            this.panelAnni.Size = new System.Drawing.Size(1383, 60);
            this.panelAnni.TabIndex = 1;
            // 
            // buttonRoot
            // 
            this.buttonRoot.AutoSize = true;
            this.buttonRoot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRoot.Location = new System.Drawing.Point(1, 1);
            this.buttonRoot.Name = "buttonRoot";
            this.buttonRoot.Size = new System.Drawing.Size(85, 54);
            this.buttonRoot.TabIndex = 0;
            this.buttonRoot.Text = "[...]";
            this.buttonRoot.UseVisualStyleBackColor = true;
            this.buttonRoot.Click += new System.EventHandler(this.buttonRoot_Click);
            // 
            // vignette
            // 
            this.vignette.AutoScroll = true;
            this.vignette.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vignette.Location = new System.Drawing.Point(0, 124);
            this.vignette.Name = "vignette";
            this.vignette.Size = new System.Drawing.Size(2068, 377);
            this.vignette.TabIndex = 1;
            // 
            // comandi
            // 
            this.comandi.AutoSize = true;
            this.comandi.BackColor = System.Drawing.SystemColors.Info;
            this.comandi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.comandi.Controls.Add(this.buttonClassifica);
            this.comandi.Controls.Add(this.Cruscotto);
            this.comandi.Controls.Add(this.panelAzioniSuFoto);
            this.comandi.Controls.Add(this.show);
            this.comandi.Dock = System.Windows.Forms.DockStyle.Top;
            this.comandi.Location = new System.Drawing.Point(0, 0);
            this.comandi.Name = "comandi";
            this.comandi.Size = new System.Drawing.Size(2068, 124);
            this.comandi.TabIndex = 0;
            // 
            // buttonClassifica
            // 
            this.buttonClassifica.Location = new System.Drawing.Point(1392, 19);
            this.buttonClassifica.Name = "buttonClassifica";
            this.buttonClassifica.Size = new System.Drawing.Size(305, 68);
            this.buttonClassifica.TabIndex = 5;
            this.buttonClassifica.Text = "classifica";
            this.buttonClassifica.UseVisualStyleBackColor = true;
            this.buttonClassifica.Click += new System.EventHandler(this.buttonClassifica_Click);
            // 
            // Cruscotto
            // 
            this.Cruscotto.Location = new System.Drawing.Point(1832, 19);
            this.Cruscotto.Name = "Cruscotto";
            this.Cruscotto.Size = new System.Drawing.Size(177, 78);
            this.Cruscotto.TabIndex = 4;
            this.Cruscotto.Text = "button1";
            this.Cruscotto.UseVisualStyleBackColor = true;
            this.Cruscotto.Click += new System.EventHandler(this.Cruscotto_Click);
            // 
            // panelAzioniSuFoto
            // 
            this.panelAzioniSuFoto.Controls.Add(this.buttonSelezionaTutti);
            this.panelAzioniSuFoto.Controls.Add(this.buttonCambiaData);
            this.panelAzioniSuFoto.Controls.Add(this.classifica);
            this.panelAzioniSuFoto.Controls.Add(this.buttonRuota);
            this.panelAzioniSuFoto.Controls.Add(this.buttonCancella);
            this.panelAzioniSuFoto.Location = new System.Drawing.Point(188, 10);
            this.panelAzioniSuFoto.Name = "panelAzioniSuFoto";
            this.panelAzioniSuFoto.Size = new System.Drawing.Size(1173, 109);
            this.panelAzioniSuFoto.TabIndex = 3;
            this.panelAzioniSuFoto.Visible = false;
            // 
            // buttonSelezionaTutti
            // 
            this.buttonSelezionaTutti.AutoSize = true;
            this.buttonSelezionaTutti.Location = new System.Drawing.Point(869, 3);
            this.buttonSelezionaTutti.Name = "buttonSelezionaTutti";
            this.buttonSelezionaTutti.Size = new System.Drawing.Size(264, 90);
            this.buttonSelezionaTutti.TabIndex = 5;
            this.buttonSelezionaTutti.Text = "seleziona tutti";
            this.buttonSelezionaTutti.UseVisualStyleBackColor = true;
            this.buttonSelezionaTutti.Click += new System.EventHandler(this.buttonSelezionaTutti_Click);
            // 
            // buttonCambiaData
            // 
            this.buttonCambiaData.AutoSize = true;
            this.buttonCambiaData.Location = new System.Drawing.Point(615, 3);
            this.buttonCambiaData.Name = "buttonCambiaData";
            this.buttonCambiaData.Size = new System.Drawing.Size(238, 90);
            this.buttonCambiaData.TabIndex = 4;
            this.buttonCambiaData.Text = "cambia data";
            this.buttonCambiaData.UseVisualStyleBackColor = true;
            this.buttonCambiaData.Click += new System.EventHandler(this.buttonCambiaData_Click);
            // 
            // classifica
            // 
            this.classifica.AutoSize = true;
            this.classifica.Location = new System.Drawing.Point(403, 3);
            this.classifica.Name = "classifica";
            this.classifica.Size = new System.Drawing.Size(196, 90);
            this.classifica.TabIndex = 3;
            this.classifica.Text = "classifica";
            this.classifica.UseVisualStyleBackColor = true;
            this.classifica.Click += new System.EventHandler(this.classifica_Click);
            // 
            // buttonRuota
            // 
            this.buttonRuota.AutoSize = true;
            this.buttonRuota.Location = new System.Drawing.Point(12, 3);
            this.buttonRuota.Name = "buttonRuota";
            this.buttonRuota.Size = new System.Drawing.Size(166, 90);
            this.buttonRuota.TabIndex = 1;
            this.buttonRuota.Text = "ruota";
            this.buttonRuota.UseVisualStyleBackColor = true;
            this.buttonRuota.Click += new System.EventHandler(this.buttonRuota_Click);
            // 
            // buttonCancella
            // 
            this.buttonCancella.AutoSize = true;
            this.buttonCancella.Location = new System.Drawing.Point(184, 3);
            this.buttonCancella.Name = "buttonCancella";
            this.buttonCancella.Size = new System.Drawing.Size(196, 90);
            this.buttonCancella.TabIndex = 2;
            this.buttonCancella.Text = "cancella";
            this.buttonCancella.UseVisualStyleBackColor = true;
            this.buttonCancella.Click += new System.EventHandler(this.buttonCancella_Click);
            // 
            // show
            // 
            this.show.Location = new System.Drawing.Point(2, -2);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(171, 90);
            this.show.TabIndex = 0;
            this.show.Text = "show";
            this.show.UseVisualStyleBackColor = true;
            this.show.Click += new System.EventHandler(this.show_Click);
            // 
            // timerBase
            // 
            this.timerBase.Tick += new System.EventHandler(this.timerBase_Tick);
            // 
            // splitContainerCruscotto
            // 
            this.splitContainerCruscotto.Location = new System.Drawing.Point(130, 559);
            this.splitContainerCruscotto.Name = "splitContainerCruscotto";
            this.splitContainerCruscotto.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerCruscotto.Panel1
            // 
            this.splitContainerCruscotto.Panel1.Controls.Add(this.splitContainerUp);
            // 
            // splitContainerCruscotto.Panel2
            // 
            this.splitContainerCruscotto.Panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.splitContainerCruscotto.Panel2.Controls.Add(this.messaggiGlobali);
            this.splitContainerCruscotto.Size = new System.Drawing.Size(1598, 359);
            this.splitContainerCruscotto.SplitterDistance = 170;
            this.splitContainerCruscotto.TabIndex = 1;
            // 
            // splitContainerUp
            // 
            this.splitContainerUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerUp.Location = new System.Drawing.Point(0, 0);
            this.splitContainerUp.Name = "splitContainerUp";
            // 
            // splitContainerUp.Panel1
            // 
            this.splitContainerUp.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainerUp.Panel1.Controls.Add(this.panelAndamenti);
            // 
            // splitContainerUp.Panel2
            // 
            this.splitContainerUp.Panel2.Controls.Add(this.splitContainerUpDx);
            this.splitContainerUp.Size = new System.Drawing.Size(1598, 170);
            this.splitContainerUp.SplitterDistance = 130;
            this.splitContainerUp.TabIndex = 0;
            // 
            // panelAndamenti
            // 
            this.panelAndamenti.AutoScroll = true;
            this.panelAndamenti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAndamenti.Location = new System.Drawing.Point(0, 0);
            this.panelAndamenti.Name = "panelAndamenti";
            this.panelAndamenti.Size = new System.Drawing.Size(130, 170);
            this.panelAndamenti.TabIndex = 0;
            // 
            // splitContainerUpDx
            // 
            this.splitContainerUpDx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerUpDx.Location = new System.Drawing.Point(0, 0);
            this.splitContainerUpDx.Name = "splitContainerUpDx";
            // 
            // splitContainerUpDx.Panel1
            // 
            this.splitContainerUpDx.Panel1.Controls.Add(this.button1);
            // 
            // splitContainerUpDx.Panel2
            // 
            this.splitContainerUpDx.Panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainerUpDx.Size = new System.Drawing.Size(1464, 170);
            this.splitContainerUpDx.SplitterDistance = 488;
            this.splitContainerUpDx.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(257, 76);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // messaggiGlobali
            // 
            this.messaggiGlobali.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messaggiGlobali.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.07143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messaggiGlobali.Location = new System.Drawing.Point(0, 0);
            this.messaggiGlobali.Name = "messaggiGlobali";
            this.messaggiGlobali.Size = new System.Drawing.Size(1598, 185);
            this.messaggiGlobali.TabIndex = 0;
            this.messaggiGlobali.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3431, 1070);
            this.Controls.Add(this.splitContainerCruscotto);
            this.Controls.Add(this.splitContainerAnni);
            this.Name = "Form1";
            this.Text = "Organizzatore fotografie";
            this.splitContainerAnni.Panel1.ResumeLayout(false);
            this.splitContainerAnni.Panel1.PerformLayout();
            this.splitContainerAnni.Panel2.ResumeLayout(false);
            this.splitContainerAnni.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAnni)).EndInit();
            this.splitContainerAnni.ResumeLayout(false);
            this.panelAnni.ResumeLayout(false);
            this.panelAnni.PerformLayout();
            this.comandi.ResumeLayout(false);
            this.panelAzioniSuFoto.ResumeLayout(false);
            this.panelAzioniSuFoto.PerformLayout();
            this.splitContainerCruscotto.Panel1.ResumeLayout(false);
            this.splitContainerCruscotto.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCruscotto)).EndInit();
            this.splitContainerCruscotto.ResumeLayout(false);
            this.splitContainerUp.Panel1.ResumeLayout(false);
            this.splitContainerUp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerUp)).EndInit();
            this.splitContainerUp.ResumeLayout(false);
            this.splitContainerUpDx.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerUpDx)).EndInit();
            this.splitContainerUpDx.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerAnni;
        private System.Windows.Forms.Timer timerBase;
        private System.Windows.Forms.Panel comandi;
        private System.Windows.Forms.Button show;
        private System.Windows.Forms.Panel vignette;
        private System.Windows.Forms.Panel panelAnni;
        private System.Windows.Forms.Button buttonRoot;
        private System.Windows.Forms.Panel avvenimenti;
        private System.Windows.Forms.Button buttonRuota;
        private System.Windows.Forms.Panel panelAzioniSuFoto;
        private System.Windows.Forms.Button buttonCancella;
        private System.Windows.Forms.Button Cruscotto;
        private System.Windows.Forms.SplitContainer splitContainerCruscotto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainerUp;
        private System.Windows.Forms.SplitContainer splitContainerUpDx;
        private System.Windows.Forms.Button classifica;
        private System.Windows.Forms.Button buttonCambiaData;
        private System.Windows.Forms.Button buttonSelezionaTutti;
        private System.Windows.Forms.Button buttonClassifica;
        private System.Windows.Forms.RichTextBox messaggiGlobali;
        private System.Windows.Forms.Panel panelAndamenti;
    }
}

