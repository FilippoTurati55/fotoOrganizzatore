
namespace FotoOrganizzatore
{
    partial class BoxImmagine
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

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.immagine = new FotoOrganizzatore.Immagine();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.immagine)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 40);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.BoxImmagine_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.immagine_MouseLeave);
            // 
            // immagine
            // 
            this.immagine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.immagine.Location = new System.Drawing.Point(0, 0);
            this.immagine.Name = "immagine";
            this.immagine.Size = new System.Drawing.Size(320, 180);
            this.immagine.TabIndex = 1;
            this.immagine.TabStop = false;
            this.immagine.Click += new System.EventHandler(this.button1_Click);
            this.immagine.MouseEnter += new System.EventHandler(this.BoxImmagine_MouseEnter);
            this.immagine.MouseLeave += new System.EventHandler(this.immagine_MouseLeave);
            // 
            // BoxImmagine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.immagine);
            this.Name = "BoxImmagine";
            this.Size = new System.Drawing.Size(320, 180);
            this.MouseEnter += new System.EventHandler(this.BoxImmagine_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.immagine_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.immagine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Immagine immagine;
        private System.Windows.Forms.Timer timer1;
    }
}
