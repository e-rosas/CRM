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
            this.components = new System.ComponentModel.Container();
            this.LBConfiguracion = new System.Windows.Forms.Label();
            this.PConfiguracion = new System.Windows.Forms.Panel();
            this.BTAceptar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Cliente = new System.Windows.Forms.RadioButton();
            this.Servidor = new System.Windows.Forms.RadioButton();
            this.Configuracion = new System.Windows.Forms.GroupBox();
            this.PConfiguracion.SuspendLayout();
            this.Configuracion.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBConfiguracion
            // 
            this.LBConfiguracion.AutoSize = true;
            this.LBConfiguracion.Location = new System.Drawing.Point(186, 9);
            this.LBConfiguracion.Name = "LBConfiguracion";
            this.LBConfiguracion.Size = new System.Drawing.Size(96, 13);
            this.LBConfiguracion.TabIndex = 6;
            this.LBConfiguracion.Text = "CONFIGURACION";
            // 
            // PConfiguracion
            // 
            this.PConfiguracion.BackColor = System.Drawing.Color.LightYellow;
            this.PConfiguracion.Controls.Add(this.Configuracion);
            this.PConfiguracion.Controls.Add(this.BTAceptar);
            this.PConfiguracion.Location = new System.Drawing.Point(13, 39);
            this.PConfiguracion.Name = "PConfiguracion";
            this.PConfiguracion.Size = new System.Drawing.Size(445, 143);
            this.PConfiguracion.TabIndex = 5;
            // 
            // BTAceptar
            // 
            this.BTAceptar.Location = new System.Drawing.Point(305, 64);
            this.BTAceptar.Name = "BTAceptar";
            this.BTAceptar.Size = new System.Drawing.Size(87, 38);
            this.BTAceptar.TabIndex = 2;
            this.BTAceptar.Text = "ACEPTAR";
            this.BTAceptar.UseVisualStyleBackColor = true;
            this.BTAceptar.Click += new System.EventHandler(this.BTAceptar_Click);
            // 
            // Cliente
            // 
            this.Cliente.AutoSize = true;
            this.Cliente.Checked = true;
            this.Cliente.Location = new System.Drawing.Point(29, 36);
            this.Cliente.Name = "Cliente";
            this.Cliente.Size = new System.Drawing.Size(83, 17);
            this.Cliente.TabIndex = 7;
            this.Cliente.TabStop = true;
            this.Cliente.Text = "Vista Cliente";
            this.Cliente.UseVisualStyleBackColor = true;
            // 
            // Servidor
            // 
            this.Servidor.AutoSize = true;
            this.Servidor.Location = new System.Drawing.Point(29, 72);
            this.Servidor.Name = "Servidor";
            this.Servidor.Size = new System.Drawing.Size(90, 17);
            this.Servidor.TabIndex = 8;
            this.Servidor.TabStop = true;
            this.Servidor.Text = "Vista Servidor";
            this.Servidor.UseVisualStyleBackColor = true;
            // 
            // Configuracion
            // 
            this.Configuracion.Controls.Add(this.Cliente);
            this.Configuracion.Controls.Add(this.Servidor);
            this.Configuracion.Location = new System.Drawing.Point(50, 28);
            this.Configuracion.Name = "Configuracion";
            this.Configuracion.Size = new System.Drawing.Size(200, 100);
            this.Configuracion.TabIndex = 10;
            this.Configuracion.TabStop = false;
            this.Configuracion.Text = "Configuracion";
            // 
            // FormConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 217);
            this.Controls.Add(this.LBConfiguracion);
            this.Controls.Add(this.PConfiguracion);
            this.Name = "FormConfiguracion";
            this.Text = "Configuracion";
            this.PConfiguracion.ResumeLayout(false);
            this.Configuracion.ResumeLayout(false);
            this.Configuracion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBConfiguracion;
        private System.Windows.Forms.Panel PConfiguracion;
        private System.Windows.Forms.Button BTAceptar;
        private System.Windows.Forms.GroupBox Configuracion;
        private System.Windows.Forms.RadioButton Cliente;
        private System.Windows.Forms.RadioButton Servidor;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}