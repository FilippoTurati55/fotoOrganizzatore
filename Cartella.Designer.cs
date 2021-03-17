
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
            this.buttonNomeCartella = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNomeCartella
            // 
            this.buttonNomeCartella.Location = new System.Drawing.Point(1, 1);
            this.buttonNomeCartella.Name = "buttonNomeCartella";
            this.buttonNomeCartella.Size = new System.Drawing.Size(480, 60);
            this.buttonNomeCartella.TabIndex = 3;
            this.buttonNomeCartella.Text = "cartellaSpeciale";
            this.buttonNomeCartella.UseVisualStyleBackColor = true;
            this.buttonNomeCartella.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonNomeCartella_Click);
            // 
            // Cartella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.buttonNomeCartella);
            this.Name = "Cartella";
            this.Size = new System.Drawing.Size(484, 64);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNomeCartella;
    }
}
