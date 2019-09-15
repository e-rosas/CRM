using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRM
{
    public partial class Form1 : Form, Observador
    {
        private Red red = new Red();
        private Factura factura = new Factura();
        private List<Producto> productos = new List<Producto>();
        
        public Form1()
        {
            InitializeComponent();
            red.RegistrarObservador(this);
        }

        public void Actualizar()
        {
            MessageBox.Show("Cambio disponibilidad"+red.Disponibilidad.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarListaProductos();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = productos;
            CBProductos.DataSource = bindingSource;
            CBProductos.DisplayMember = "Nombre";
            CBProductos.ValueMember = "Nombre";
        }

        private void LlenarListaProductos()
        {
            productos.Add(new Producto("PARACETAMOL", 25, 1));
            productos.Add(new Producto("REFRESCO", 15, 10));
            productos.Add(new Producto("CARGADOR", 250, 1));
            productos.Add(new Producto("CHOCOLARE", 18, 1));
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            factura.AgregarProducto((Producto)CBProductos.SelectedItem);
            MessageBox.Show(factura.productos.Count.ToString());
            DGVProductosFactura.DataSource = factura.productos.ToList();
        }

        private void CBProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producto productoSeleccionado = (Producto)CBProductos.SelectedItem;
            TBCantidad.Text = productoSeleccionado.Cantidad.ToString();
        }
    }
}
