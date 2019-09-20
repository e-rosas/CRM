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
            transaccion.DisponibilidadInternet = red.DisponibilidadInternet; //asignar la disponibilad a la transaccion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
        }


        private void LlenarListaProductos()
        {
            
            productosDisponibles.Add(new Producto() { Nombre = "Aceite", Precio = 18, Cantidad = 1 });
            productosDisponibles.Add(new Producto() { Nombre = "Aderezo", Precio = 15, Cantidad = 1 });
            productosDisponibles.Add(new Producto() { Nombre = "Avena", Precio = 12, Cantidad = 1 });
            productosDisponibles.Add(new Producto() { Nombre = "Tortillas", Precio = 17, Cantidad = 1 });
            productosDisponibles.Add(new Producto() { Nombre = "Refresco", Precio = 16, Cantidad = 1 });
            productosDisponibles.Add(new Producto() { Nombre = "Sabrita", Precio = 12, Cantidad = 1 });
            productosDisponibles.Add(new Producto() { Nombre = "Mayonessa", Precio = 20, Cantidad = 1 });
            productosDisponibles.Add(new Producto() { Nombre = "Leche", Precio = 43, Cantidad = 1 });
            productosDisponibles.Add(new Producto() { Nombre = "Yogurt", Precio = 8, Cantidad = 1 });
            productosDisponibles.Add(new Producto() { Nombre = "Chocolate", Precio = 5, Cantidad = 1 });
            productosDisponibles.Add(new Producto() { Nombre = "Galletas", Precio = 13, Cantidad = 1 });

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
            int cantidad = 0;
            //primero se debe intentar asignar lo que hay en TBCantidad a cantidad, y luego la se compara
            if (Int32.TryParse(TBCantidad.Text, out cantidad) && cantidad > 0) 
            {
                //cantidad valida
                productoSeleccionado.Cantidad = cantidad;
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
            else
            {
                MessageBox.Show("Cantidad invalida", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }

        private void CBProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Producto productoSeleccionado = (Producto)CBProductos.SelectedItem;
                TBCantidad.Text = productoSeleccionado.Cantidad.ToString();
                LblPrecioUnitario.Text = productoSeleccionado.Precio.ToString();
            }
            catch (Exception)
            {
                TBCantidad.Text = "1";
                LblPrecioUnitario.Text = "0";
            }

        }
        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            Sucursal sucursalSeleccionada = (Sucursal)CBSucursal.SelectedItem;
            facturaActual.GenerarFolio(sucursalSeleccionada.Numero);
            facturaActual.Fecha = DateTime.Now;
            facturaActual.RFC = sucursalSeleccionada.RFC;

            //Si el Textbox no esta vacio y de valor cumple con estructura de correo electronico.
            if (TBCorreo.Text != "" && transaccion.ValidarCorreo(TBCorreo.Text))
            {
                facturaActual.Correo = TBCorreo.Text;
                transaccion.NuevoPDF(facturaActual); //generacion de PDF y envio de correo
                //decision de enviar por correo o no...
                if (transaccion.DisponibilidadInternet) //envia por correo y al servidor
                {
                    string estado = transaccion.EnvioTransaccion(facturaActual);
                    MessageBox.Show(estado, "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);                 
                }
                else //agrega al archivo de facturas
                {
                    facturasPendientes.Add(facturaActual);
                    GuardarFactura(transaccion.UbicacionFacturasXML(), facturasPendientes.ToArray());
                    MessageBox.Show("Venta pendiente debido a la disponibilidad de servidor", "Venta pendiente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //despues de una venta exitosa
                facturaActual = new Factura(); //limpiando los campos
                DGVProductosFactura.DataSource = facturaActual.productos.ToList();
                LblSubtotal.Text = "";
                LblIVA.Text = "";
                LblTotal.Text = "";
                LblCantidadProductos.Text = "";
                TBCorreo.Text = "";
                //limpiar lista de productos
                productosDisponibles.Clear();
                CBProductos.DataSource = null;
                LlenarListaProductos();
                //volver a ligar con el combobox
                CBProductos.DataSource = productosDisponibles;
                CBProductos.DisplayMember = "Nombre";
                CBProductos.ValueMember = "Nombre";
                BtnFinalizar.Enabled = false;
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

    }
}
