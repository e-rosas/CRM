using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CRM
{
    public class Transaccion : Observador
    {
        private Subject red;
        Conexion conexion = new Conexion();
        public bool DisponibilidadRed;
        public Transaccion(Subject subject) {
            red = subject;
            red.RegistrarObservador(this);
            CambiarStringConexion();
        }
      
        public void Actualizar(bool disponiblidad)
        {
            DisponibilidadRed = disponiblidad;
            CambioDisponibilidad();
        }

        //Asigna a la variable conexionString el valores de conexion
        public void CambiarStringConexion()
        {
            conexion.conexionString = "Data Source=" + Properties.Settings.Default.Servidor + "; Initial Catalog=Transacciones; User id=AdminTransaccion; Password=root";
        }
        public bool EnvioTransaccion(Factura factura)
        {
            try
            {
               conexion.NuevaTransaccion(factura); //al servidor
               return true;
            }
            catch (Exception)
            {
               return false;  //MessageBox.Show("Error de conexion al servidor!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void CambioDisponibilidad() //maneja el cambio de disponibilidad
        {
            string archivoFacturas = UbicacionFacturas();
            if (DisponibilidadRed && File.Exists(archivoFacturas))
            {
                //si hay conexion y el archivo existe,  Leer documento facturas.xml, si hay facturas pendientes , enviarlas
                LeerFacturas(archivoFacturas);
                //limpiar archivo
                File.Delete(archivoFacturas);
            }
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
            if (facturasLeidas.Length > 0)
            {
                foreach (Factura factura in facturasLeidas)
                {
                    EnvioTransaccion(factura);
                    NuevoPDF(factura); //generacion de PDF  y enviar por correo
                }
            }

        }
        public string UbicacionFacturas()
        {
            if (Directory.Exists(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Facturas"))) //verificar que existe la carpeta Facturas
            {
                //crealo
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Facturas"));
            }
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Facturas", "facturas.xml");
            return path;
        }
        public void NuevoPDF(Factura factura)
        {
            Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
            MemoryStream ubicacionEnMemoria = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, ubicacionEnMemoria);
            pdfDoc.Open();
            pdfDoc.Add(new Paragraph("Numero de folio: " + factura.NoFolio + "           " + factura.Fecha.ToShortDateString()));
            pdfDoc.Add(new Paragraph("RFC: " + factura.RFC));
            foreach (Producto producto in factura.productos)
            {
                pdfDoc.Add(new Paragraph(
                      "Producto: " + producto.Nombre
                    + " Precio unitario: " + producto.Precio
                    + " Cantidad : " + producto.Cantidad
                    + " Total: " + producto.Total));
            }
            pdfDoc.Add(new Paragraph("Subtotal: " + factura.Subtotal + " IVA: " + factura.IVA + " Total :" + factura.Total + " Cantidad productos: " + factura.Cantidad_Productos));
            writer.CloseStream = false;
            pdfDoc.Close();
            ubicacionEnMemoria.Position = 0;
            EnviarCorreo(factura, ubicacionEnMemoria);
        }

        public bool ValidarCorreo(string correo)
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

        public void EnviarCorreo(Factura factura, MemoryStream ubicacionEnMemoria)
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
             try
             {
                 client.Send(message);
             }
             catch (Exception)
             {
                    //MessageBox.Show("Error de envio!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }
    }
}
