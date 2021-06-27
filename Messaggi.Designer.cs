
namespace FotoOrganizzatore
{
    partial class Messaggi
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
            this.label1 = new System.Windows.Forms.Label();
            this.TrovateFotografie = new System.Windows.Forms.Label();
            this.TrovateFotoDoppie = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.07143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(542, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Report classifica cartella";
            // 
            // TrovateFotografie
            // 
            this.TrovateFotografie.AutoSize = true;
            this.TrovateFotografie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.07143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrovateFotografie.Location = new System.Drawing.Point(21, 113);
            this.TrovateFotografie.Name = "TrovateFotografie";
            this.TrovateFotografie.Size = new System.Drawing.Size(400, 55);
            this.TrovateFotografie.TabIndex = 1;
            this.TrovateFotografie.Text = "Trovate fotografie";
            // 
            // TrovateFotoDoppie
            // 
            this.TrovateFotoDoppie.AutoSize = true;
            this.TrovateFotoDoppie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.07143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrovateFotoDoppie.Location = new System.Drawing.Point(21, 193);
            this.TrovateFotoDoppie.Name = "TrovateFotoDoppie";
            this.TrovateFotoDoppie.Size = new System.Drawing.Size(558, 55);
            this.TrovateFotoDoppie.TabIndex = 2;
            this.TrovateFotoDoppie.Text = "Trovate fotografie doppie";
            // 
            // Messaggi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TrovateFotoDoppie);
            this.Controls.Add(this.TrovateFotografie);
            this.Controls.Add(this.label1);
            this.Name = "Messaggi";
            this.Size = new System.Drawing.Size(1625, 852);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TrovateFotografie;
        private System.Windows.Forms.Label TrovateFotoDoppie;
    }
}
