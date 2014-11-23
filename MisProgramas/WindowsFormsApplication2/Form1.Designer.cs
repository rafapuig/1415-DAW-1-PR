namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvTabla = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMinimo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaximo = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvTabla
            // 
            this.lvTabla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTabla.Location = new System.Drawing.Point(12, 52);
            this.lvTabla.Name = "lvTabla";
            this.lvTabla.Size = new System.Drawing.Size(488, 261);
            this.lvTabla.TabIndex = 0;
            this.lvTabla.UseCompatibleStateImageBehavior = false;
            this.lvTabla.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mínimo:";
            // 
            // txtMinimo
            // 
            this.txtMinimo.Location = new System.Drawing.Point(63, 12);
            this.txtMinimo.Name = "txtMinimo";
            this.txtMinimo.Size = new System.Drawing.Size(100, 20);
            this.txtMinimo.TabIndex = 2;
            this.txtMinimo.Text = "5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Máximo:";
            // 
            // txtMaximo
            // 
            this.txtMaximo.Location = new System.Drawing.Point(252, 13);
            this.txtMaximo.Name = "txtMaximo";
            this.txtMaximo.Size = new System.Drawing.Size(100, 20);
            this.txtMaximo.TabIndex = 4;
            this.txtMaximo.Text = "8";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(376, 11);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(126, 23);
            this.btnCalcular.TabIndex = 5;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 325);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtMaximo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMinimo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvTabla);
            this.Name = "Form1";
            this.Text = "Actividad 4.18";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvTabla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMinimo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaximo;
        private System.Windows.Forms.Button btnCalcular;
    }
}

