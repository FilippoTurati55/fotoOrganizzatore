
namespace FotoOrganizzatore
{
    partial class AndamentoAttivita
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
            this.nomeAttivita = new System.Windows.Forms.Label();
            this.attivitaSvolta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nomeAttivita
            // 
            this.nomeAttivita.AutoSize = true;
            this.nomeAttivita.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomeAttivita.Location = new System.Drawing.Point(4, 44);
            this.nomeAttivita.Name = "nomeAttivita";
            this.nomeAttivita.Size = new System.Drawing.Size(347, 64);
            this.nomeAttivita.TabIndex = 0;
            this.nomeAttivita.Text = "nome attività";
            // 
            // attivitaSvolta
            // 
            this.attivitaSvolta.AutoSize = true;
            this.attivitaSvolta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attivitaSvolta.Location = new System.Drawing.Point(431, 44);
            this.attivitaSvolta.Name = "attivitaSvolta";
            this.attivitaSvolta.Size = new System.Drawing.Size(403, 64);
            this.attivitaSvolta.TabIndex = 1;
            this.attivitaSvolta.Text = "attività in corso";
            // 
            // AndamentoAttivita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.attivitaSvolta);
            this.Controls.Add(this.nomeAttivita);
            this.Name = "AndamentoAttivita";
            this.Size = new System.Drawing.Size(1266, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nomeAttivita;
        private System.Windows.Forms.Label attivitaSvolta;
    }
}
