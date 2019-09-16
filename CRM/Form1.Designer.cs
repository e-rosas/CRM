namespace CRM
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CBProductos = new System.Windows.Forms.ComboBox();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.TBCantidad = new System.Windows.Forms.TextBox();
            this.DGVProductosFactura = new System.Windows.Forms.DataGridView();
            this.CBSucursal = new System.Windows.Forms.ComboBox();
            this.LblPrecioUnitario = new System.Windows.Forms.Label();
            this.LblTotal = new System.Windows.Forms.Label();
            this.LblSubtotal = new System.Windows.Forms.Label();
            this.LblIVA = new System.Windows.Forms.Label();
            this.LblCantidadProductos = new System.Windows.Forms.Label();
            this.BtnFinalizar = new System.Windows.Forms.Button();
            this.TBCorreo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductosFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // CBProductos
            // 
            this.CBProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBProductos.FormattingEnabled = true;
            this.CBProductos.Location = new System.Drawing.Point(12, 129);
            this.CBProductos.Name = "CBProductos";
            this.CBProductos.Size = new System.Drawing.Size(155, 29);
            this.CBProductos.TabIndex = 0;
            this.CBProductos.SelectedIndexChanged += new System.EventHandler(this.CBProductos_SelectedIndexChanged);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(363, 127);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(86, 29);
            this.BtnAgregar.TabIndex = 2;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // TBCantidad
            // 
            this.TBCantidad.Location = new System.Drawing.Point(251, 128);
            this.TBCantidad.MaxLength = 6;
            this.TBCantidad.Name = "TBCantidad";
            this.TBCantidad.Size = new System.Drawing.Size(94, 29);
            this.TBCantidad.TabIndex = 1;
            this.TBCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBCantidad_KeyPress);
            // 
            // DGVProductosFactura
            // 
            this.DGVProductosFactura.AllowUserToAddRows = false;
            this.DGVProductosFactura.AllowUserToDeleteRows = false;
            this.DGVProductosFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVProductosFactura.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVProductosFactura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVProductosFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProductosFactura.EnableHeadersVisualStyles = false;
            this.DGVProductosFactura.Location = new System.Drawing.Point(23, 205);
            this.DGVProductosFactura.Name = "DGVProductosFactura";
            this.DGVProductosFactura.ReadOnly = true;
            this.DGVProductosFactura.RowHeadersVisible = false;
            this.DGVProductosFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVProductosFactura.Size = new System.Drawing.Size(415, 150);
            this.DGVProductosFactura.TabIndex = 3;
            // 
            // CBSucursal
            // 
            this.CBSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBSucursal.FormattingEnabled = true;
            this.CBSucursal.Location = new System.Drawing.Point(12, 12);
            this.CBSucursal.Name = "CBSucursal";
            this.CBSucursal.Size = new System.Drawing.Size(292, 29);
            this.CBSucursal.TabIndex = 6;
            this.CBSucursal.SelectedIndexChanged += new System.EventHandler(this.CBSucursal_SelectedIndexChanged);
            // 
            // LblPrecioUnitario
            // 
            this.LblPrecioUnitario.AutoSize = true;
            this.LblPrecioUnitario.Location = new System.Drawing.Point(185, 132);
            this.LblPrecioUnitario.Name = "LblPrecioUnitario";
            this.LblPrecioUnitario.Size = new System.Drawing.Size(30, 21);
            this.LblPrecioUnitario.TabIndex = 7;
            this.LblPrecioUnitario.Text = "PU";
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.Location = new System.Drawing.Point(484, 296);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(19, 21);
            this.LblTotal.TabIndex = 8;
            this.LblTotal.Text = "0";
            // 
            // LblSubtotal
            // 
            this.LblSubtotal.AutoSize = true;
            this.LblSubtotal.Location = new System.Drawing.Point(484, 205);
            this.LblSubtotal.Name = "LblSubtotal";
            this.LblSubtotal.Size = new System.Drawing.Size(19, 21);
            this.LblSubtotal.TabIndex = 9;
            this.LblSubtotal.Text = "0";
            // 
            // LblIVA
            // 
            this.LblIVA.AutoSize = true;
            this.LblIVA.Location = new System.Drawing.Point(484, 254);
            this.LblIVA.Name = "LblIVA";
            this.LblIVA.Size = new System.Drawing.Size(19, 21);
            this.LblIVA.TabIndex = 10;
            this.LblIVA.Text = "0";
            // 
            // LblCantidadProductos
            // 
            this.LblCantidadProductos.AutoSize = true;
            this.LblCantidadProductos.Location = new System.Drawing.Point(484, 334);
            this.LblCantidadProductos.Name = "LblCantidadProductos";
            this.LblCantidadProductos.Size = new System.Drawing.Size(19, 21);
            this.LblCantidadProductos.TabIndex = 11;
            this.LblCantidadProductos.Text = "0";
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.Enabled = false;
            this.BtnFinalizar.Location = new System.Drawing.Point(317, 486);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(86, 38);
            this.BtnFinalizar.TabIndex = 12;
            this.BtnFinalizar.Text = "Finalizar";
            this.BtnFinalizar.UseVisualStyleBackColor = true;
            this.BtnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // TBCorreo
            // 
            this.TBCorreo.Location = new System.Drawing.Point(96, 388);
            this.TBCorreo.MaxLength = 40;
            this.TBCorreo.Name = "TBCorreo";
            this.TBCorreo.Size = new System.Drawing.Size(249, 29);
            this.TBCorreo.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(644, 576);
            this.Controls.Add(this.TBCorreo);
            this.Controls.Add(this.BtnFinalizar);
            this.Controls.Add(this.LblCantidadProductos);
            this.Controls.Add(this.LblIVA);
            this.Controls.Add(this.LblSubtotal);
            this.Controls.Add(this.LblTotal);
            this.Controls.Add(this.LblPrecioUnitario);
            this.Controls.Add(this.CBSucursal);
            this.Controls.Add(this.DGVProductosFactura);
            this.Controls.Add(this.TBCantidad);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.CBProductos);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductosFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBProductos;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.TextBox TBCantidad;
        private System.Windows.Forms.DataGridView DGVProductosFactura;
        private System.Windows.Forms.ComboBox CBSucursal;
        private System.Windows.Forms.Label LblPrecioUnitario;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Label LblSubtotal;
        private System.Windows.Forms.Label LblIVA;
        private System.Windows.Forms.Label LblCantidadProductos;
        private System.Windows.Forms.Button BtnFinalizar;
        private System.Windows.Forms.TextBox TBCorreo;
    }
}

