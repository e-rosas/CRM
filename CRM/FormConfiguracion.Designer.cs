namespace CRM
{
    partial class FormConfiguracion
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
            this.LBConfiguracion = new System.Windows.Forms.Label();
            this.PConfiguracion = new System.Windows.Forms.Panel();
            this.LBDireccion = new System.Windows.Forms.Label();
            this.BTAceptar = new System.Windows.Forms.Button();
            this.TBDireccion = new System.Windows.Forms.TextBox();
            this.PConfiguracion.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBConfiguracion
            // 
            this.LBConfiguracion.AutoSize = true;
            this.LBConfiguracion.Location = new System.Drawing.Point(203, 9);
            this.LBConfiguracion.Name = "LBConfiguracion";
            this.LBConfiguracion.Size = new System.Drawing.Size(96, 13);
            this.LBConfiguracion.TabIndex = 6;
            this.LBConfiguracion.Text = "CONFIGURACION";
            // 
            // PConfiguracion
            // 
            this.PConfiguracion.BackColor = System.Drawing.Color.LightYellow;
            this.PConfiguracion.Controls.Add(this.LBDireccion);
            this.PConfiguracion.Controls.Add(this.BTAceptar);
            this.PConfiguracion.Controls.Add(this.TBDireccion);
            this.PConfiguracion.Location = new System.Drawing.Point(13, 39);
            this.PConfiguracion.Name = "PConfiguracion";
            this.PConfiguracion.Size = new System.Drawing.Size(497, 100);
            this.PConfiguracion.TabIndex = 5;
            // 
            // LBDireccion
            // 
            this.LBDireccion.AutoSize = true;
            this.LBDireccion.Location = new System.Drawing.Point(16, 31);
            this.LBDireccion.Name = "LBDireccion";
            this.LBDireccion.Size = new System.Drawing.Size(85, 13);
            this.LBDireccion.TabIndex = 1;
            this.LBDireccion.Text = "DIRECCION IP :";
            // 
            // BTAceptar
            // 
            this.BTAceptar.Location = new System.Drawing.Point(368, 22);
            this.BTAceptar.Name = "BTAceptar";
            this.BTAceptar.Size = new System.Drawing.Size(87, 38);
            this.BTAceptar.TabIndex = 2;
            this.BTAceptar.Text = "ACEPTAR";
            this.BTAceptar.UseVisualStyleBackColor = true;
            this.BTAceptar.Click += new System.EventHandler(this.BTAceptar_Click);
            // 
            // TBDireccion
            // 
            this.TBDireccion.Location = new System.Drawing.Point(137, 28);
            this.TBDireccion.Name = "TBDireccion";
            this.TBDireccion.Size = new System.Drawing.Size(191, 20);
            this.TBDireccion.TabIndex = 0;
            // 
            // FormConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 187);
            this.Controls.Add(this.LBConfiguracion);
            this.Controls.Add(this.PConfiguracion);
            this.Name = "FormConfiguracion";
            this.Text = "FormConfiguracion";
            this.PConfiguracion.ResumeLayout(false);
            this.PConfiguracion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBConfiguracion;
        private System.Windows.Forms.Panel PConfiguracion;
        private System.Windows.Forms.Label LBDireccion;
        private System.Windows.Forms.Button BTAceptar;
        private System.Windows.Forms.TextBox TBDireccion;
    }
}