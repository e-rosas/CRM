namespace CRM
{
    partial class FormServidor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGVTransacciones = new System.Windows.Forms.DataGridView();
            this.TBBusqueda = new System.Windows.Forms.TextBox();
            this.BtnBucar = new System.Windows.Forms.Button();
            this.LBTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTActualizar = new System.Windows.Forms.Button();
            this.TABTransacciones = new System.Windows.Forms.TabControl();
            this.TABTransaccion = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTransacciones)).BeginInit();
            this.TABTransacciones.SuspendLayout();
            this.TABTransaccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVTransacciones
            // 
            this.DGVTransacciones.AllowUserToAddRows = false;
            this.DGVTransacciones.AllowUserToDeleteRows = false;
            this.DGVTransacciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DGVTransacciones.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVTransacciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVTransacciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTransacciones.EnableHeadersVisualStyles = false;
            this.DGVTransacciones.Location = new System.Drawing.Point(23, 52);
            this.DGVTransacciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DGVTransacciones.Name = "DGVTransacciones";
            this.DGVTransacciones.ReadOnly = true;
            this.DGVTransacciones.RowHeadersVisible = false;
            this.DGVTransacciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVTransacciones.Size = new System.Drawing.Size(930, 318);
            this.DGVTransacciones.TabIndex = 0;
            // 
            // TBBusqueda
            // 
            this.TBBusqueda.Location = new System.Drawing.Point(201, 15);
            this.TBBusqueda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBBusqueda.Name = "TBBusqueda";
            this.TBBusqueda.Size = new System.Drawing.Size(576, 29);
            this.TBBusqueda.TabIndex = 1;
            // 
            // BtnBucar
            // 
            this.BtnBucar.Location = new System.Drawing.Point(784, 13);
            this.BtnBucar.Name = "BtnBucar";
            this.BtnBucar.Size = new System.Drawing.Size(77, 31);
            this.BtnBucar.TabIndex = 2;
            this.BtnBucar.Text = "Buscar";
            this.BtnBucar.UseVisualStyleBackColor = true;
            this.BtnBucar.Click += new System.EventHandler(this.BtnBucar_Click);
            // 
            // LBTitulo
            // 
            this.LBTitulo.AutoSize = true;
            this.LBTitulo.Location = new System.Drawing.Point(418, 9);
            this.LBTitulo.Name = "LBTitulo";
            this.LBTitulo.Size = new System.Drawing.Size(134, 21);
            this.LBTitulo.TabIndex = 3;
            this.LBTitulo.Text = "TRANSACCIONES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "No Folio, RFC, Correo:";
            // 
            // BTActualizar
            // 
            this.BTActualizar.Location = new System.Drawing.Point(867, 13);
            this.BTActualizar.Name = "BTActualizar";
            this.BTActualizar.Size = new System.Drawing.Size(90, 31);
            this.BTActualizar.TabIndex = 5;
            this.BTActualizar.Text = "Actualizar";
            this.BTActualizar.UseVisualStyleBackColor = true;
            this.BTActualizar.Click += new System.EventHandler(this.BTActualizar_Click);
            // 
            // TABTransacciones
            // 
            this.TABTransacciones.Controls.Add(this.TABTransaccion);
            this.TABTransacciones.Location = new System.Drawing.Point(6, 33);
            this.TABTransacciones.Name = "TABTransacciones";
            this.TABTransacciones.SelectedIndex = 0;
            this.TABTransacciones.Size = new System.Drawing.Size(980, 436);
            this.TABTransacciones.TabIndex = 6;
            // 
            // TABTransaccion
            // 
            this.TABTransaccion.Controls.Add(this.label1);
            this.TABTransaccion.Controls.Add(this.BTActualizar);
            this.TABTransaccion.Controls.Add(this.DGVTransacciones);
            this.TABTransaccion.Controls.Add(this.TBBusqueda);
            this.TABTransaccion.Controls.Add(this.BtnBucar);
            this.TABTransaccion.Location = new System.Drawing.Point(4, 30);
            this.TABTransaccion.Name = "TABTransaccion";
            this.TABTransaccion.Padding = new System.Windows.Forms.Padding(3);
            this.TABTransaccion.Size = new System.Drawing.Size(972, 402);
            this.TABTransaccion.TabIndex = 0;
            this.TABTransaccion.Text = "TRANSACCIONES";
            this.TABTransaccion.UseVisualStyleBackColor = true;
            // 
            // FormServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 478);
            this.Controls.Add(this.TABTransacciones);
            this.Controls.Add(this.LBTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(987, 475);
            this.Name = "FormServidor";
            this.Text = "Servidor";
            this.Load += new System.EventHandler(this.FormServidor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVTransacciones)).EndInit();
            this.TABTransacciones.ResumeLayout(false);
            this.TABTransaccion.ResumeLayout(false);
            this.TABTransaccion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVTransacciones;
        private System.Windows.Forms.TextBox TBBusqueda;
        private System.Windows.Forms.Button BtnBucar;
        private System.Windows.Forms.Label LBTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTActualizar;
        private System.Windows.Forms.TabControl TABTransacciones;
        private System.Windows.Forms.TabPage TABTransaccion;
    }
}