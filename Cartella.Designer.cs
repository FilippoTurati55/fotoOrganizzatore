
namespace FotoOrganizzatore
{
    partial class Cartella
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
            this.nomeCartella = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nomeCartella
            // 
            this.nomeCartella.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomeCartella.Location = new System.Drawing.Point(1, 1);
            this.nomeCartella.Name = "nomeCartella";
            this.nomeCartella.Size = new System.Drawing.Size(400, 72);
            this.nomeCartella.TabIndex = 2;
            this.nomeCartella.Text = "cartella speciale";
            this.nomeCartella.Click += new System.EventHandler(this.nomeCartella_Click);
            // 
            // Cartella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.nomeCartella);
            this.Name = "Cartella";
            this.Size = new System.Drawing.Size(404, 76);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nomeCartella;
    }
}
