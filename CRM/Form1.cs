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
            productos.Add(new Producto() { Nombre ="PARACETAMOL", Precio = 25,Cantidad = 1 });
            productos.Add(new Producto() { Nombre = "REFRESCO", Precio = 15, Cantidad = 1 });
            productos.Add(new Producto() { Nombre = "CHOCOLATE", Precio = 10, Cantidad = 1 });
            productos.Add(new Producto() { Nombre = "CARGADOR", Precio = 250, Cantidad = 1 });
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
            factura.AgregarProducto(productoSeleccionado);
            MessageBox.Show(factura.productos.Count.ToString());
            DGVProductosFactura.DataSource = factura.productos.ToList();
        }

        private void CBProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producto productoSeleccionado = (Producto)CBProductos.SelectedItem;
            TBCantidad.Text = productoSeleccionado.Cantidad.ToString();
        }

        private void BtnSerializar_Click(object sender, EventArgs e)
        {
            CrearProducto("‪productos.xml", productos.ToArray());
        }

        private void BtnDeserializar_Click(object sender, EventArgs e)
        {
            LeerProductos("‪productos.xml");
        }
    }
}
