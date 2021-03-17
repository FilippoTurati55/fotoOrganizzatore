
namespace FotoOrganizzatore
{
    partial class Anno
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
            this.buttonAnno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAnno
            // 
            this.buttonAnno.AutoSize = true;
            this.buttonAnno.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAnno.Location = new System.Drawing.Point(1, 1);
            this.buttonAnno.Name = "buttonAnno";
            this.buttonAnno.Size = new System.Drawing.Size(114, 54);
            this.buttonAnno.TabIndex = 0;
            this.buttonAnno.Text = "anno";
            this.buttonAnno.UseVisualStyleBackColor = true;
            this.buttonAnno.Click += new System.EventHandler(this.buttonAnno_Click);
            // 
            // Anno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.buttonAnno);
            this.Name = "Anno";
            this.Size = new System.Drawing.Size(118, 58);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAnno;
    }
}
