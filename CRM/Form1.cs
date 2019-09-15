using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace CRM
{
    public partial class Form1 : Form, Observador
    {
        private Red red = new Red();
        private Factura factura = new Factura();
        private List<Producto> productos = new List<Producto>();
        private List<Sucursal> sucursales = new List<Sucursal>();
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
            LlenarListaSucursales();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = productos;
            CBProductos.DataSource = bindingSource;
            CBProductos.DisplayMember = "Nombre";
            CBProductos.ValueMember = "Nombre";

            CBSucursal.DataSource = sucursales;
            CBSucursal.DisplayMember = "Nombre";
            CBSucursal.ValueMember = "Nombre";
            
        }

        private void LlenarListaProductos()
        {
            productos.Add(new Producto() { Nombre ="PARACETAMOL", Precio = 25,Cantidad = 1 });
            productos.Add(new Producto() { Nombre = "REFRESCO", Precio = 15, Cantidad = 1 });
            productos.Add(new Producto() { Nombre = "CHOCOLATE", Precio = 10, Cantidad = 1 });
            productos.Add(new Producto() { Nombre = "CARGADOR", Precio = 250, Cantidad = 1 });
        }
        private void LlenarListaSucursales()
        {
            sucursales.Add(new Sucursal() { Nombre = "SUCURSAL DE LA LUZ", Numero = "13" });
            sucursales.Add(new Sucursal() { Nombre = "SUCURSAL DEL VALLE", Numero = "22" });
        }
        private void CrearProducto(string filename,Producto[] productos)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Producto[]));
            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, productos);
            writer.Close();
        }

        private void LeerProductos(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Producto[]));
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                Producto[] productosLeidos = (Producto[])serializer.Deserialize(fs);
                productos = productosLeidos.ToList<Producto>();
            }
                
            
            DGVProductosFactura.DataSource = productos;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Producto productoSeleccionado = (Producto)CBProductos.SelectedItem;           
            productoSeleccionado.Cantidad = Convert.ToInt32(TBCantidad.Text);
            productoSeleccionado.CalcularTotal();
            factura.AgregarProducto(productoSeleccionado);
            DGVProductosFactura.DataSource = factura.productos.ToList();
            factura.CalcularSubtotal();
            LblSubtotal.Text = factura.Subtotal.ToString();
            LblIVA.Text = factura.IVA.ToString();
            LblTotal.Text = factura.Total.ToString();
            LblCantidadProductos.Text = factura.Cantidad_Productos.ToString();
        }

        private void CBProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producto productoSeleccionado = (Producto)CBProductos.SelectedItem;
            TBCantidad.Text = productoSeleccionado.Cantidad.ToString();
            LblPrecioUnitario.Text = productoSeleccionado.Precio.ToString();

        }

        private void BtnSerializar_Click(object sender, EventArgs e)
        {
            CrearProducto("‪productos.xml", productos.ToArray());
        }

        private void BtnDeserializar_Click(object sender, EventArgs e)
        {
            LeerProductos("‪productos.xml");
        }

        private void CBSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            Sucursal sucursal = (Sucursal)CBSucursal.SelectedItem;
            factura.GenerarFolio(sucursal.Numero);
            factura.Fecha = DateTime.Today;
        }
    }
}
