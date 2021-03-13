
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.vignette = new System.Windows.Forms.Panel();
            this.comandi = new System.Windows.Forms.Panel();
            this.show = new System.Windows.Forms.Button();
            this.timerBase = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.avvenimenti = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.comandi.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.avvenimenti);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Resize += new System.EventHandler(this.splitContainer1_Panel1_Resize);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.vignette);
            this.splitContainer1.Panel2.Controls.Add(this.comandi);
            this.splitContainer1.Size = new System.Drawing.Size(3012, 1070);
            this.splitContainer1.SplitterDistance = 1780;
            this.splitContainer1.TabIndex = 0;
            // 
            // vignette
            // 
            this.vignette.AutoScroll = true;
            this.vignette.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vignette.Location = new System.Drawing.Point(0, 93);
            this.vignette.Name = "vignette";
            this.vignette.Size = new System.Drawing.Size(1226, 975);
            this.vignette.TabIndex = 1;
            // 
            // comandi
            // 
            this.comandi.AutoSize = true;
            this.comandi.BackColor = System.Drawing.SystemColors.Info;
            this.comandi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.comandi.Controls.Add(this.show);
            this.comandi.Dock = System.Windows.Forms.DockStyle.Top;
            this.comandi.Location = new System.Drawing.Point(0, 0);
            this.comandi.Name = "comandi";
            this.comandi.Size = new System.Drawing.Size(1226, 93);
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
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1778, 93);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 90);
            this.button1.TabIndex = 0;
            this.button1.Text = "[...]";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // avvenimenti
            // 
            this.avvenimenti.AutoScroll = true;
            this.avvenimenti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.avvenimenti.Location = new System.Drawing.Point(0, 93);
            this.avvenimenti.Name = "avvenimenti";
            this.avvenimenti.Size = new System.Drawing.Size(1778, 975);
            this.avvenimenti.TabIndex = 2;
            this.avvenimenti.Resize += new System.EventHandler(this.avvenimenti_Resize);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3012, 1070);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Organizzatore fotografie";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.comandi.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Timer timerBase;
        private System.Windows.Forms.Panel comandi;
        private System.Windows.Forms.Button show;
        private System.Windows.Forms.Panel vignette;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel avvenimenti;
    }
}

