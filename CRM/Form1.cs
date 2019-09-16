using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Net;
using System.Net.Mail;

//I <3 TS

namespace CRM
{
    public partial class Form1 : Form, Observador
    {
        private Red red = new Red(); //al crearse se prueba la disponibilidad de la red
        private Factura factura = new Factura();       
        private List<Producto> productosDisponibles = new List<Producto>();
        private List<Sucursal> sucursales = new List<Sucursal>();
        private List<Factura> facturasPendientes = new List<Factura>();
        private bool DisponibilidadRed;
        public Form1()
        {
            InitializeComponent();
            red.RegistrarObservador(this); //registrando como observador a la forma
        }

        public void Actualizar()
        {
            MessageBox.Show("Cambio disponibilidad"+red.Disponibilidad.ToString());
            DisponibilidadRed = red.Disponibilidad;
        }

        private void LogicaRed()
        {
            if (DisponibilidadRed && File.Exists("facturas.xml"))
            {
                //si hay conexion y el archivo existe,  Leer documento facturas.xml, si hay facturas pendientes , enviarlas
                LeerFacturas("facturas.xml");
                //limpiar archivo
                File.Delete("facturas.xml");
                MessageBox.Show("Archivo eliminado");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisponibilidadRed = red.Disponibilidad;
            LogicaRed();
            LlenarListaProductos();
            LlenarListaSucursales();
            DGVProductosFactura.DataSource = factura.productos.ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = productosDisponibles;
            CBProductos.DataSource = bindingSource;
            CBProductos.DisplayMember = "Nombre";
            CBProductos.ValueMember = "Nombre";

            CBSucursal.DataSource = sucursales;
            CBSucursal.DisplayMember = "Nombre_Sucursal";
            CBSucursal.ValueMember = "Nombre_Sucursal";
         //new world order 
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

        //Procesa la informacion del XML y los guarda en arreglo de facturasleidas
        private void LeerFacturas(string archivo)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Factura[]));
            Factura[] facturasLeidas;
            using (FileStream fs = new FileStream(archivo, FileMode.Open)) //liberar el archivo 
            {
                facturasLeidas = (Factura[])serializer.Deserialize(fs);
            }
            if(facturasLeidas.Length > 0)
            {
                foreach (Factura factura in facturasLeidas)
                {
                    NuevoPDF(factura);
                }
            }
            
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
                factura.AgregarProducto(productoSeleccionado);
                DGVProductosFactura.DataSource = factura.productos.ToList(); //vincula la lista de productos de la factura con el datagridview
                factura.CalcularSubtotal(); //calcula todo
                                            //Actualizar labels 
                LblSubtotal.Text = factura.Subtotal.ToString();
                LblIVA.Text = factura.IVA.ToString();
                LblTotal.Text = factura.Total.ToString();
                LblCantidadProductos.Text = factura.Cantidad_Productos.ToString();
                BtnFinalizar.Enabled = true;
            }           
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
            if (TBCorreo.Text != "" && ValidarCorreo(TBCorreo.Text))
            {
                factura.Correo = TBCorreo.Text;
                if (DisponibilidadRed)
                {
                    NuevoPDF(factura);
                }
                else
                {
                    facturasPendientes.Add(factura);
                    GuardarFactura("facturas.xml", facturasPendientes.ToArray());
                }

                factura = new Factura(); //limpiando los campos
                DGVProductosFactura.DataSource = factura.productos.ToList();
                LblSubtotal.Text = "";
                LblIVA.Text = "";
                LblTotal.Text = "";
                LblCantidadProductos.Text = "";
                TBCorreo.Text = "";
                productosDisponibles.Clear();
                LlenarListaProductos();
            }
            else
            {
                MessageBox.Show("Correo invalido", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void NuevoPDF(Factura factura)
        {
           Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
           MemoryStream ubicacionEnMemoria = new MemoryStream();
           PdfWriter writer = PdfWriter.GetInstance(pdfDoc, ubicacionEnMemoria);
           pdfDoc.Open();
           pdfDoc.Add(new Paragraph("Numero de folio: "+  factura.NoFolio + "           " + factura.Fecha.ToShortDateString()));
           pdfDoc.Add(new Paragraph("RFC: " + factura.RFC));
           foreach (Producto producto in factura.productos)
            {
                pdfDoc.Add(new Paragraph(
                      "Producto: "+producto.Nombre 
                    + " Precio unitario: "+producto.Precio
                    + " Cantidad : "+producto.Cantidad
                    + " Total: "+producto.Total));
            }
           pdfDoc.Add(new Paragraph("Subtotal: " + factura.Subtotal+ " IVA: "+factura.IVA+ " Total :"+factura.Total+" Cantidad productos: "+factura.Cantidad_Productos));
           writer.CloseStream = false;
           pdfDoc.Close();
           ubicacionEnMemoria.Position = 0;
           EnviarCorreo(factura, ubicacionEnMemoria);
        }
        private bool ValidarCorreo(string correo)
        {
            try
            {
                MailAddress m = new MailAddress(correo);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void EnviarCorreo(Factura factura, MemoryStream ubicacionEnMemoria)
        {
            if (ValidarCorreo(factura.Correo))
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("practicapatos@gmail.com");
                message.To.Add(factura.Correo);
                message.Subject = "Este es un PDF C: ..";
                message.Body = "Contenido del PDF ";
                //Agrega al correo un archivo PDF para enviar.4
                message.Attachments.Add(new Attachment(ubicacionEnMemoria, "Factura.pdf"));
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("practicapatos@gmail.com", "Contra123"),
                    EnableSsl = true
                };
                client.Send(message);

            }
            else
            {
                MessageBox.Show("Direccion de correo no es valida.");
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
