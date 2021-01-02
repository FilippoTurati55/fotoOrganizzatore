
namespace FotoOrganizzatore
{
    partial class AccreditamentoUnitaBackup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.disco = new System.Windows.Forms.Label();
            this.costruttore = new System.Windows.Forms.Label();
            this.numeroDiSerie = new System.Windows.Forms.Label();
            this.identificatore = new System.Windows.Forms.TextBox();
            this.accredita = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // disco
            // 
            this.disco.AutoSize = true;
            this.disco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disco.Location = new System.Drawing.Point(86, 36);
            this.disco.Name = "disco";
            this.disco.Size = new System.Drawing.Size(277, 64);
            this.disco.TabIndex = 0;
            this.disco.Text = "percorso: ";
            // 
            // costruttore
            // 
            this.costruttore.AutoSize = true;
            this.costruttore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costruttore.Location = new System.Drawing.Point(86, 134);
            this.costruttore.Name = "costruttore";
            this.costruttore.Size = new System.Drawing.Size(214, 64);
            this.costruttore.TabIndex = 1;
            this.costruttore.Text = "______";
            // 
            // numeroDiSerie
            // 
            this.numeroDiSerie.AutoSize = true;
            this.numeroDiSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroDiSerie.Location = new System.Drawing.Point(86, 225);
            this.numeroDiSerie.Name = "numeroDiSerie";
            this.numeroDiSerie.Size = new System.Drawing.Size(214, 64);
            this.numeroDiSerie.TabIndex = 2;
            this.numeroDiSerie.Text = "______";
            // 
            // identificatore
            // 
            this.identificatore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.identificatore.Location = new System.Drawing.Point(97, 376);
            this.identificatore.Name = "identificatore";
            this.identificatore.Size = new System.Drawing.Size(1058, 71);
            this.identificatore.TabIndex = 3;
            this.identificatore.Text = "copia sicurezza";
            // 
            // accredita
            // 
            this.accredita.BackColor = System.Drawing.Color.Lime;
            this.accredita.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accredita.Location = new System.Drawing.Point(839, 625);
            this.accredita.Name = "accredita";
            this.accredita.Size = new System.Drawing.Size(573, 274);
            this.accredita.TabIndex = 4;
            this.accredita.Text = "Accredita";
            this.accredita.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(129, 625);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(573, 274);
            this.button1.TabIndex = 5;
            this.button1.Text = "Blocca";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AccreditamentoUnitaBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1545, 947);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.accredita);
            this.Controls.Add(this.identificatore);
            this.Controls.Add(this.numeroDiSerie);
            this.Controls.Add(this.costruttore);
            this.Controls.Add(this.disco);
            this.Name = "AccreditamentoUnitaBackup";
            this.Text = "AccreditamentoUnitaBackup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label disco;
        private System.Windows.Forms.Label costruttore;
        private System.Windows.Forms.Label numeroDiSerie;
        private System.Windows.Forms.TextBox identificatore;
        private System.Windows.Forms.Button accredita;
        private System.Windows.Forms.Button button1;
    }
}