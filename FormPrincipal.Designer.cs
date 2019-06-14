namespace Exercicio01
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPeixes = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPeixes
            // 
            this.btnPeixes.Font = new System.Drawing.Font("Arial Narrow", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeixes.Location = new System.Drawing.Point(1, 1);
            this.btnPeixes.Name = "btnPeixes";
            this.btnPeixes.Size = new System.Drawing.Size(259, 448);
            this.btnPeixes.TabIndex = 0;
            this.btnPeixes.Text = "Peixes";
            this.btnPeixes.UseVisualStyleBackColor = true;
            this.btnPeixes.Click += new System.EventHandler(this.btnPeixes_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(266, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(272, 448);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(544, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(253, 448);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnPeixes);
            this.Name = "FormPrincipal";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPeixes;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

