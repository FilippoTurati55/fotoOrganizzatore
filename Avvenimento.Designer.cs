
namespace FotoOrganizzatore
{
    partial class Avvenimento
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
            this.statoButton = new System.Windows.Forms.Button();
            this.dataInizio = new System.Windows.Forms.TextBox();
            this.dataFine = new System.Windows.Forms.TextBox();
            this.commento = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // statoButton
            // 
            this.statoButton.Location = new System.Drawing.Point(1, 1);
            this.statoButton.Name = "statoButton";
            this.statoButton.Size = new System.Drawing.Size(91, 49);
            this.statoButton.TabIndex = 0;
            this.statoButton.UseVisualStyleBackColor = true;
            this.statoButton.Click += new System.EventHandler(this.SetInizioFine_Click);
            // 
            // dataInizio
            // 
            this.dataInizio.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataInizio.Location = new System.Drawing.Point(98, 1);
            this.dataInizio.Name = "dataInizio";
            this.dataInizio.Size = new System.Drawing.Size(1369, 72);
            this.dataInizio.TabIndex = 1;
            this.dataInizio.Text = "2017 07 14 mercoledì";
            this.dataInizio.MouseEnter += new System.EventHandler(this.data_MouseEnter);
            // 
            // dataFine
            // 
            this.dataFine.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataFine.Location = new System.Drawing.Point(691, 5);
            this.dataFine.Name = "dataFine";
            this.dataFine.Size = new System.Drawing.Size(124, 72);
            this.dataFine.TabIndex = 2;
            this.dataFine.MouseEnter += new System.EventHandler(this.data_MouseEnter);
            // 
            // commento
            // 
            this.commento.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commento.Location = new System.Drawing.Point(1161, 5);
            this.commento.Name = "commento";
            this.commento.Size = new System.Drawing.Size(218, 72);
            this.commento.TabIndex = 3;
            this.commento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Evento_KeyUp);
            this.commento.Leave += new System.EventHandler(this.Evento_LostFocus);
            this.commento.MouseEnter += new System.EventHandler(this.data_MouseEnter);
            // 
            // Avvenimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.commento);
            this.Controls.Add(this.dataFine);
            this.Controls.Add(this.dataInizio);
            this.Controls.Add(this.statoButton);
            this.Name = "Avvenimento";
            this.Size = new System.Drawing.Size(1470, 80);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button statoButton;
        private System.Windows.Forms.TextBox dataInizio;
        private System.Windows.Forms.TextBox dataFine;
        private System.Windows.Forms.TextBox commento;
    }
}
