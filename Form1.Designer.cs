
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
            this.show = new System.Windows.Forms.Button();
            this.timerBase = new System.Windows.Forms.Timer(this.components);
            this.buttonRuota = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAnni)).BeginInit();
            this.splitContainerAnni.Panel1.SuspendLayout();
            this.splitContainerAnni.Panel2.SuspendLayout();
            this.splitContainerAnni.SuspendLayout();
            this.panelAnni.SuspendLayout();
            this.comandi.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerAnni
            // 
            this.splitContainerAnni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerAnni.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.splitContainerAnni.Size = new System.Drawing.Size(3012, 1070);
            this.splitContainerAnni.SplitterDistance = 1780;
            this.splitContainerAnni.TabIndex = 0;
            // 
            // avvenimenti
            // 
            this.avvenimenti.AutoScroll = true;
            this.avvenimenti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.avvenimenti.Location = new System.Drawing.Point(0, 60);
            this.avvenimenti.Name = "avvenimenti";
            this.avvenimenti.Size = new System.Drawing.Size(1778, 1008);
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
            this.panelAnni.Size = new System.Drawing.Size(1778, 60);
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
            this.vignette.Location = new System.Drawing.Point(0, 94);
            this.vignette.Name = "vignette";
            this.vignette.Size = new System.Drawing.Size(1226, 974);
            this.vignette.TabIndex = 1;
            // 
            // comandi
            // 
            this.comandi.AutoSize = true;
            this.comandi.BackColor = System.Drawing.SystemColors.Info;
            this.comandi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.comandi.Controls.Add(this.buttonRuota);
            this.comandi.Controls.Add(this.show);
            this.comandi.Dock = System.Windows.Forms.DockStyle.Top;
            this.comandi.Location = new System.Drawing.Point(0, 0);
            this.comandi.Name = "comandi";
            this.comandi.Size = new System.Drawing.Size(1226, 94);
            this.comandi.TabIndex = 0;
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
            // buttonRuota
            // 
            this.buttonRuota.Location = new System.Drawing.Point(179, -1);
            this.buttonRuota.Name = "buttonRuota";
            this.buttonRuota.Size = new System.Drawing.Size(166, 90);
            this.buttonRuota.TabIndex = 1;
            this.buttonRuota.Text = "ruota";
            this.buttonRuota.UseVisualStyleBackColor = true;
            this.buttonRuota.Visible = false;
            this.buttonRuota.Click += new System.EventHandler(this.buttonRuota_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3012, 1070);
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
    }
}

