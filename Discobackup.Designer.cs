
namespace FotoOrganizzatore
{
    partial class Discobackup
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
            this.nome = new System.Windows.Forms.Label();
            this.numeroDiSerieIndicazione = new System.Windows.Forms.Label();
            this.numeroDiSerie = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Disco backup:";
            // 
            // nome
            // 
            this.nome.AutoSize = true;
            this.nome.Location = new System.Drawing.Point(292, 10);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(116, 44);
            this.nome.TabIndex = 1;
            this.nome.Text = "nome";
            // 
            // numeroDiSerieIndicazione
            // 
            this.numeroDiSerieIndicazione.AutoSize = true;
            this.numeroDiSerieIndicazione.Location = new System.Drawing.Point(3, 135);
            this.numeroDiSerieIndicazione.Name = "numeroDiSerieIndicazione";
            this.numeroDiSerieIndicazione.Size = new System.Drawing.Size(300, 44);
            this.numeroDiSerieIndicazione.TabIndex = 2;
            this.numeroDiSerieIndicazione.Text = "Numero di serie:";
            // 
            // numeroDiSerie
            // 
            this.numeroDiSerie.AutoSize = true;
            this.numeroDiSerie.Location = new System.Drawing.Point(318, 135);
            this.numeroDiSerie.Name = "numeroDiSerie";
            this.numeroDiSerie.Size = new System.Drawing.Size(239, 44);
            this.numeroDiSerie.TabIndex = 3;
            this.numeroDiSerie.Text = "numeroSerie";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(394, 153);
            this.button1.TabIndex = 4;
            this.button1.Text = "Esamina";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Discobackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numeroDiSerie);
            this.Controls.Add(this.numeroDiSerieIndicazione);
            this.Controls.Add(this.nome);
            this.Controls.Add(this.label1);
            this.Name = "Discobackup";
            this.Size = new System.Drawing.Size(1784, 852);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nome;
        private System.Windows.Forms.Label numeroDiSerieIndicazione;
        private System.Windows.Forms.Label numeroDiSerie;
        private System.Windows.Forms.Button button1;
    }
}
