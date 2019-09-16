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
        private List<Producto> productosDisponibles = new List<Producto>();
        private List<Sucursal> sucursales = new List<Sucursal>();
        private List<Factura> facturasPendientes = new List<Factura>();
        public Form1()
        {
            InitializeComponent();
            red.RegistrarObservador(this); //registrando como observador a la forma
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
            bindingSource.DataSource = productosDisponibles;
            CBProductos.DataSource = bindingSource;
            CBProductos.DisplayMember = "Nombre";
            CBProductos.ValueMember = "Nombre";

            CBSucursal.DataSource = sucursales;
            CBSucursal.DisplayMember = "Nombre_Sucursal";
            CBSucursal.ValueMember = "Nombre_Sucursal";
            
        }

        private void LlenarListaProductos()
        {
            Producto p1 = new Producto();
            p1.Nombre = "Gatos";
            p1.Precio = 15;
            p1.Cantidad = 7;
            productosDisponibles.Add(p1);
            productosDisponibles.Add(new Producto() { Nombre ="PARACETAMOL", Precio = 25, Cantidad = 1 });
            productosDisponibles.Add(new Producto() { Nombre = "REFRESCO", Precio = 15, Cantidad = 1 });
            productosDisponibles.Add(new Producto() { Nombre = "CHOCOLATE", Precio = 10, Cantidad = 1 });
            productosDisponibles.Add(new Producto() { Nombre = "CARGADOR", Precio = 250, Cantidad = 1 });
        }
        private void LlenarListaSucursales()
        {
            sucursales.Add(new Sucursal() { Nombre_Sucursal = "SUCURSAL DE LA LUZ", Numero = "13",RFC="SEMK961223"});
            sucursales.Add(new Sucursal() { Nombre_Sucursal = "SUCURSAL DEL VALLE", Numero = "22",RFC="ROSE970717"});
        }

        private void GuardarFactura(string archivo, Factura[] facturas)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Factura[]));
            TextWriter writer = new StreamWriter(archivo);
            serializer.Serialize(writer, facturas);
            writer.Close();
        }

        private void LeerFacturas(string archivo)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Factura[]));
            Factura[] facturasLeidas;
            using (FileStream fs = new FileStream(archivo, FileMode.Open))
            {
                facturasLeidas = (Factura[])serializer.Deserialize(fs);
            }
            foreach(Factura factura in facturasLeidas)
            {
                MessageBox.Show(factura.NoFolio);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Producto productoSeleccionado = (Producto)CBProductos.SelectedItem;           
            productoSeleccionado.Cantidad = Convert.ToInt32(TBCantidad.Text);
            productoSeleccionado.CalcularTotal();

            //agregar el producto a la lista de productos de factura
            factura.AgregarProducto(productoSeleccionado);
            DGVProductosFactura.DataSource = factura.productos.ToList(); //vincula la lista de productos de la factura con el datagridview
            factura.CalcularSubtotal(); //calcula todo
            //Actualizar labels 
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


        private void CBSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            Sucursal sucursalSeleccionada = (Sucursal)CBSucursal.SelectedItem;
            factura.GenerarFolio(sucursalSeleccionada.Numero);
            factura.Fecha = DateTime.Today;
            factura.RFC = sucursalSeleccionada.RFC;
            factura.Correo = TBCantidad.Text;
            facturasPendientes.Add(factura);
            factura = new Factura(); //limpiando los campos
            DGVProductosFactura.DataSource = factura.productos.ToList();
            LblSubtotal.Text = "";
            LblIVA.Text = "";
            LblTotal.Text = "";
            LblCantidadProductos.Text = "";
        }

        private void BtnGuardarF_Click(object sender, EventArgs e)
        {
            GuardarFactura("facturas.xml", facturasPendientes.ToArray());
        }

        private void BtnLeerF_Click(object sender, EventArgs e)
        {
            LeerFacturas("facturas.xml");
        }
    }
}
