namespace CRM
{
    partial class FormCliente
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
            this.LBSucursal = new System.Windows.Forms.Label();
            this.LBPrecio = new System.Windows.Forms.Label();
            this.LBCantidad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductosFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // CBProductos
            // 
            this.CBProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBProductos.FormattingEnabled = true;
            this.CBProductos.Location = new System.Drawing.Point(34, 134);
            this.CBProductos.Name = "CBProductos";
            this.CBProductos.Size = new System.Drawing.Size(155, 29);
            this.CBProductos.TabIndex = 0;
            this.CBProductos.SelectedIndexChanged += new System.EventHandler(this.CBProductos_SelectedIndexChanged);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(650, 136);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(86, 29);
            this.BtnAgregar.TabIndex = 2;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // TBCantidad
            // 
            this.TBCantidad.Location = new System.Drawing.Point(486, 136);
            this.TBCantidad.MaxLength = 6;
            this.TBCantidad.Name = "TBCantidad";
            this.TBCantidad.Size = new System.Drawing.Size(129, 29);
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
            this.DGVProductosFactura.Location = new System.Drawing.Point(34, 199);
            this.DGVProductosFactura.Name = "DGVProductosFactura";
            this.DGVProductosFactura.ReadOnly = true;
            this.DGVProductosFactura.RowHeadersVisible = false;
            this.DGVProductosFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVProductosFactura.Size = new System.Drawing.Size(702, 236);
            this.DGVProductosFactura.TabIndex = 3;
            // 
            // CBSucursal
            // 
            this.CBSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBSucursal.FormattingEnabled = true;
            this.CBSucursal.Location = new System.Drawing.Point(125, 68);
            this.CBSucursal.Name = "CBSucursal";
            this.CBSucursal.Size = new System.Drawing.Size(611, 29);
            this.CBSucursal.TabIndex = 6;
            // 
            // LblPrecioUnitario
            // 
            this.LblPrecioUnitario.AutoSize = true;
            this.LblPrecioUnitario.Location = new System.Drawing.Point(330, 139);
            this.LblPrecioUnitario.Name = "LblPrecioUnitario";
            this.LblPrecioUnitario.Size = new System.Drawing.Size(30, 21);
            this.LblPrecioUnitario.TabIndex = 7;
            this.LblPrecioUnitario.Text = "PU";
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.Location = new System.Drawing.Point(880, 359);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(19, 21);
            this.LblTotal.TabIndex = 8;
            this.LblTotal.Text = "0";
            // 
            // LblSubtotal
            // 
            this.LblSubtotal.AutoSize = true;
            this.LblSubtotal.Location = new System.Drawing.Point(880, 278);
            this.LblSubtotal.Name = "LblSubtotal";
            this.LblSubtotal.Size = new System.Drawing.Size(19, 21);
            this.LblSubtotal.TabIndex = 9;
            this.LblSubtotal.Text = "0";
            // 
            // LblIVA
            // 
            this.LblIVA.AutoSize = true;
            this.LblIVA.Location = new System.Drawing.Point(880, 318);
            this.LblIVA.Name = "LblIVA";
            this.LblIVA.Size = new System.Drawing.Size(19, 21);
            this.LblIVA.TabIndex = 10;
            this.LblIVA.Text = "0";
            // 
            // LblCantidadProductos
            // 
            this.LblCantidadProductos.AutoSize = true;
            this.LblCantidadProductos.Location = new System.Drawing.Point(880, 234);
            this.LblCantidadProductos.Name = "LblCantidadProductos";
            this.LblCantidadProductos.Size = new System.Drawing.Size(19, 21);
            this.LblCantidadProductos.TabIndex = 11;
            this.LblCantidadProductos.Text = "0";
            // 
            // BtnFinalizar
            // 
            this.BtnFinalizar.Enabled = false;
            this.BtnFinalizar.Location = new System.Drawing.Point(806, 460);
            this.BtnFinalizar.Name = "BtnFinalizar";
            this.BtnFinalizar.Size = new System.Drawing.Size(86, 38);
            this.BtnFinalizar.TabIndex = 12;
            this.BtnFinalizar.Text = "Finalizar";
            this.BtnFinalizar.UseVisualStyleBackColor = true;
            this.BtnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // TBCorreo
            // 
            this.TBCorreo.Location = new System.Drawing.Point(190, 466);
            this.TBCorreo.MaxLength = 40;
            this.TBCorreo.Name = "TBCorreo";
            this.TBCorreo.Size = new System.Drawing.Size(546, 29);
            this.TBCorreo.TabIndex = 14;
            // 
            // LBSucursal
            // 
            this.LBSucursal.AutoSize = true;
            this.LBSucursal.Location = new System.Drawing.Point(30, 71);
            this.LBSucursal.Name = "LBSucursal";
            this.LBSucursal.Size = new System.Drawing.Size(88, 21);
            this.LBSucursal.TabIndex = 15;
            this.LBSucursal.Text = "SUCURSAL";
            // 
            // LBPrecio
            // 
            this.LBPrecio.AutoSize = true;
            this.LBPrecio.Location = new System.Drawing.Point(254, 138);
            this.LBPrecio.Name = "LBPrecio";
            this.LBPrecio.Size = new System.Drawing.Size(70, 21);
            this.LBPrecio.TabIndex = 16;
            this.LBPrecio.Text = "PRECIO :";
            // 
            // LBCantidad
            // 
            this.LBCantidad.AutoSize = true;
            this.LBCantidad.Location = new System.Drawing.Point(391, 139);
            this.LBCantidad.Name = "LBCantidad";
            this.LBCantidad.Size = new System.Drawing.Size(89, 21);
            this.LBCantidad.TabIndex = 17;
            this.LBCantidad.Text = "CANTIDAD:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(742, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 21);
            this.label1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(758, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "Precio Unitario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(838, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 21);
            this.label3.TabIndex = 20;
            this.label3.Text = "IVA:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(802, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 21);
            this.label4.TabIndex = 21;
            this.label4.Text = "Cantidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(761, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 21);
            this.label5.TabIndex = 22;
            this.label5.Text = "Precio con IVA:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 474);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 21);
            this.label6.TabIndex = 23;
            this.label6.Text = "Correo Electronico:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(394, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 21);
            this.label7.TabIndex = 24;
            this.label7.Text = "PUNTO DE VENTA";
            // 
            // FormCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(922, 539);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBCantidad);
            this.Controls.Add(this.LBPrecio);
            this.Controls.Add(this.LBSucursal);
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
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(938, 578);
            this.MinimumSize = new System.Drawing.Size(938, 578);
            this.Name = "FormCliente";
            this.Text = "Administrador de ventas";
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
        private System.Windows.Forms.Label LBSucursal;
        private System.Windows.Forms.Label LBPrecio;
        private System.Windows.Forms.Label LBCantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

