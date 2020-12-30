
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
            this.immagine1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.immagine1)).BeginInit();
            this.SuspendLayout();
            // 
            // immagine1
            // 
            this.immagine1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.immagine1.InitialImage = null;
            this.immagine1.Location = new System.Drawing.Point(1913, 876);
            this.immagine1.Name = "immagine1";
            this.immagine1.Size = new System.Drawing.Size(183, 92);
            this.immagine1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.immagine1.TabIndex = 0;
            this.immagine1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2215, 1070);
            this.Controls.Add(this.immagine1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.immagine1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox immagine1;
    }
}

