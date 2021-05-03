
namespace FotoOrganizzatore.Dialogs
{
    partial class Classifica
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
            this.listBoxElencoClassificazioni = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelNuovaClassificazione = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxElencoClassificazioni
            // 
            this.listBoxElencoClassificazioni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxElencoClassificazioni.FormattingEnabled = true;
            this.listBoxElencoClassificazioni.ItemHeight = 64;
            this.listBoxElencoClassificazioni.Location = new System.Drawing.Point(8, 19);
            this.listBoxElencoClassificazioni.Name = "listBoxElencoClassificazioni";
            this.listBoxElencoClassificazioni.Size = new System.Drawing.Size(2354, 1092);
            this.listBoxElencoClassificazioni.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(629, 1182);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1733, 71);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // labelNuovaClassificazione
            // 
            this.labelNuovaClassificazione.AutoSize = true;
            this.labelNuovaClassificazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNuovaClassificazione.Location = new System.Drawing.Point(13, 1186);
            this.labelNuovaClassificazione.Name = "labelNuovaClassificazione";
            this.labelNuovaClassificazione.Size = new System.Drawing.Size(558, 64);
            this.labelNuovaClassificazione.TabIndex = 2;
            this.labelNuovaClassificazione.Text = "nuova classificazione";
            // 
            // Classifica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2414, 1313);
            this.Controls.Add(this.labelNuovaClassificazione);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBoxElencoClassificazioni);
            this.Name = "Classifica";
            this.Text = "Classifica";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxElencoClassificazioni;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelNuovaClassificazione;
    }
}