using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Net.NetworkInformation;


//I <3 TS

namespace CRM
{
    public partial class FormCliente : Form
    {
        private Red red = new Red(); //al crearse se prueba la disponibilidad de la red
        private Factura facturaActual = new Factura();       
        private List<Producto> productosDisponibles = new List<Producto>();
        private List<Sucursal> sucursales = new List<Sucursal>();
        private List<Factura> facturasPendientes = new List<Factura>();
        private Transaccion transaccion;
        public FormCliente()
        {
            InitializeComponent();
            transaccion = new Transaccion(red);
            transaccion.DisponibilidadRed = red.Disponibilidad; //asignar la disponibilad a la transaccion
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            TBDireccion.Text = Properties.Settings.Default.Servidor;
            RevisarFacturasPendientes();
            LlenarListaProductos();
            LlenarListaSucursales();
            DGVProductosFactura.DataSource = facturaActual.productos.ToList();

            CBProductos.DataSource = productosDisponibles;
            CBProductos.DisplayMember = "Nombre";
            CBProductos.ValueMember = "Nombre";

            CBSucursal.DataSource = sucursales;
            CBSucursal.DisplayMember = "Nombre_Sucursal";
            CBSucursal.ValueMember = "Nombre_Sucursal";

            NetworkChange.NetworkAvailabilityChanged += CambioDisponibilidad;
            //new world order 
        }

        private void CambioDisponibilidad(object sender, NetworkAvailabilityEventArgs e)
        {
            MessageBox.Show("cambio de red");

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
            sucursales.Add(new Sucursal() { Nombre_Sucursal = "SUCURSAL DE LA LUZ", Numero = "13",RFC="FTGT675487"});
            sucursales.Add(new Sucursal() { Nombre_Sucursal = "SUCURSAL DEL VALLE", Numero = "22",RFC="HTYJ657865"});
        }

        //Guarda las facturas en el archivo XML
        private void GuardarFactura(string archivo, Factura[] facturas)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Factura[])); //tipo arreglo de Facturas
            TextWriter writer = new StreamWriter(archivo);
            serializer.Serialize(writer, facturas);
            writer.Close();
        }       

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Producto productoSeleccionado = (Producto)CBProductos.SelectedItem;
            if(TBCantidad.Text == "0" || TBCantidad.Text == "")
            {
                //cantidad invalida
                MessageBox.Show("Cantidad invalida","Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                productoSeleccionado.Cantidad = Convert.ToInt32(TBCantidad.Text);
                productoSeleccionado.CalcularTotal();

                //agregar el producto a la lista de productos de factura
                facturaActual.AgregarProducto(productoSeleccionado);
                DGVProductosFactura.DataSource = facturaActual.productos.ToList(); //vincula la lista de productos de la factura con el datagridview
                facturaActual.CalcularSubtotal(); //calcula todo
                                            //Actualizar labels 
                LblSubtotal.Text = facturaActual.Subtotal.ToString();
                LblIVA.Text = facturaActual.IVA.ToString();
                LblTotal.Text = facturaActual.Total.ToString();
                LblCantidadProductos.Text = facturaActual.Cantidad_Productos.ToString();
                BtnFinalizar.Enabled = true;
            }           
        }

        private void CBProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producto productoSeleccionado = (Producto)CBProductos.SelectedItem;
            TBCantidad.Text = productoSeleccionado.Cantidad.ToString();
            LblPrecioUnitario.Text = productoSeleccionado.Precio.ToString();

        }
        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            Sucursal sucursalSeleccionada = (Sucursal)CBSucursal.SelectedItem;
            facturaActual.GenerarFolio(sucursalSeleccionada.Numero);
            facturaActual.Fecha = DateTime.Now;
            facturaActual.RFC = sucursalSeleccionada.RFC;
            if (TBCorreo.Text != "" && transaccion.ValidarCorreo(TBCorreo.Text))
            {
                facturaActual.Correo = TBCorreo.Text;
                if (transaccion.DisponibilidadRed) //envia por correo y al servidor
                {
                    transaccion.EnvioTransaccion(facturaActual);
                    transaccion.NuevoPDF(facturaActual); //generacion de PDF y envio de correo
                    MessageBox.Show("Venta exitosa y fue enviada!", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                }
                else //agrega al archivo de facturas
                {
                    facturasPendientes.Add(facturaActual);
                    GuardarFactura(transaccion.UbicacionFacturas(), facturasPendientes.ToArray());
                    MessageBox.Show("Venta pendiente debido a la disponibilidad de red", "Venta pendiente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                facturaActual = new Factura(); //limpiando los campos
                DGVProductosFactura.DataSource = facturaActual.productos.ToList();
                LblSubtotal.Text = "";
                LblIVA.Text = "";
                LblTotal.Text = "";
                LblCantidadProductos.Text = "";
                TBCorreo.Text = "";
            }
            else
            {
                MessageBox.Show("Correo invalido", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void RevisarFacturasPendientes()
        {
            try
            {
                transaccion.CambioDisponibilidad();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de conexion al servidor!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TBCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void BTAceptar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Servidor = TBDireccion.Text;
            Properties.Settings.Default.Save();
            transaccion.CambiarStringConexion();
            MessageBox.Show("Configuracion exitosa!", "Configuracion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
