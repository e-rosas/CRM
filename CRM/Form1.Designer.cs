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
            this.CBProductos = new System.Windows.Forms.ComboBox();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.TBCantidad = new System.Windows.Forms.TextBox();
            this.DGVProductosFactura = new System.Windows.Forms.DataGridView();
            this.BtnSerializar = new System.Windows.Forms.Button();
            this.BtnDeserializar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductosFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // CBProductos
            // 
            this.CBProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBProductos.FormattingEnabled = true;
            this.CBProductos.Location = new System.Drawing.Point(37, 129);
            this.CBProductos.Name = "CBProductos";
            this.CBProductos.Size = new System.Drawing.Size(155, 29);
            this.CBProductos.TabIndex = 0;
            this.CBProductos.SelectedIndexChanged += new System.EventHandler(this.CBProductos_SelectedIndexChanged);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(312, 128);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(86, 29);
            this.BtnAgregar.TabIndex = 2;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // TBCantidad
            // 
            this.TBCantidad.Location = new System.Drawing.Point(216, 129);
            this.TBCantidad.Name = "TBCantidad";
            this.TBCantidad.Size = new System.Drawing.Size(68, 29);
            this.TBCantidad.TabIndex = 1;
            // 
            // DGVProductosFactura
            // 
            this.DGVProductosFactura.AllowUserToAddRows = false;
            this.DGVProductosFactura.AllowUserToDeleteRows = false;
            this.DGVProductosFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVProductosFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProductosFactura.Location = new System.Drawing.Point(109, 227);
            this.DGVProductosFactura.Name = "DGVProductosFactura";
            this.DGVProductosFactura.ReadOnly = true;
            this.DGVProductosFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVProductosFactura.Size = new System.Drawing.Size(529, 150);
            this.DGVProductosFactura.TabIndex = 3;
            // 
            // BtnSerializar
            // 
            this.BtnSerializar.Location = new System.Drawing.Point(507, 119);
            this.BtnSerializar.Name = "BtnSerializar";
            this.BtnSerializar.Size = new System.Drawing.Size(75, 38);
            this.BtnSerializar.TabIndex = 4;
            this.BtnSerializar.Text = "button1";
            this.BtnSerializar.UseVisualStyleBackColor = true;
            this.BtnSerializar.Click += new System.EventHandler(this.BtnSerializar_Click);
            // 
            // BtnDeserializar
            // 
            this.BtnDeserializar.Location = new System.Drawing.Point(663, 119);
            this.BtnDeserializar.Name = "BtnDeserializar";
            this.BtnDeserializar.Size = new System.Drawing.Size(75, 38);
            this.BtnDeserializar.TabIndex = 5;
            this.BtnDeserializar.Text = "button1";
            this.BtnDeserializar.UseVisualStyleBackColor = true;
            this.BtnDeserializar.Click += new System.EventHandler(this.BtnDeserializar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(953, 576);
            this.Controls.Add(this.BtnDeserializar);
            this.Controls.Add(this.BtnSerializar);
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
        private System.Windows.Forms.Button BtnSerializar;
        private System.Windows.Forms.Button BtnDeserializar;
    }
}

