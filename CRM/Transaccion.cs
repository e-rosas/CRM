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
        public bool DisponibilidadServidor;
        public bool DisponibilidadInternet;
        public Transaccion(Subject subject) {
            red = subject;
            red.RegistrarObservador(this);
            CambiarStringConexion();
        }
      
        public void Actualizar(bool disponiblidad, bool DisponibilidadInternet)
        {
            DisponibilidadServidor = disponiblidad;
            this.DisponibilidadInternet = DisponibilidadInternet;
            CambioDisponibilidad();
        }

        //Asigna a la variable conexionString los  valores de conexion
        public void CambiarStringConexion()
        {
            conexion.conexionString = "Server=tcp:desktop.database.windows.net,1433;Initial Catalog=Transacciones;Persist Security Info=False;" +
                "User ID=adminTransaccion;Password=root1234!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            //conexion.conexionString = "Data Source=" + Properties.Settings.Default.Servidor + "; Initial Catalog=Transacciones; User id=AdminTransaccion; Password=root";
        }
        public string EnvioTransaccion(Factura factura)
        {          
            try
            {
                conexion.NuevaTransaccion(factura); //al servidor
                return "Venta exitosa y fue enviada!";
            }
            catch (Exception)
            {
               return "Venta no enviada al servidor!";  //MessageBox.Show("Error de conexion al servidor!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void CambioDisponibilidad() //maneja el cambio de disponibilidad
        {
            string archivoFacturas = UbicacionFacturasXML();

            if (DisponibilidadServidor && File.Exists(archivoFacturas))
            {
                //si hay conexion y el archivo existe,  Leer documento facturas.xml, si hay facturas pendientes , enviarlas
                LeerFacturasXML(archivoFacturas);
                //limpiar archivo
                File.Delete(archivoFacturas);
            }
        }
        //Procesa la informacion del XML y los guarda en arreglo de facturasleidas
        private void LeerFacturasXML(string archivo)
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
                    string ubicacionPDF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Facturas", "factura" + factura.NoFolio + ".pdf");
                    if (DisponibilidadInternet)
                    {
                        EnviarCorreo(factura.Correo, ubicacionPDF);
                    }
                    //NuevoPDF(factura); //generacion de PDF  y enviar por correo

                }
            }

        }
        public string UbicacionFacturasXML()
        {
         
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Facturas", "facturas.xml");
            return path;
        }

        //Crea PDF en ubicacion MyDocuments/Facturas
        public void NuevoPDF(Factura factura)
        {   //Se asigna ruta "MyDocuments", ubica carpeta factura,se guarda bajo el nombre factura+NoFolio
            string ubicacionPDF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Facturas", "factura"+factura.NoFolio+".pdf");
            //Abre ubicacion de ruta y genera PDF
            using (FileStream stream = new FileStream(ubicacionPDF, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                //MemoryStream ubicacionEnMemoria = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
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
            }
 
            //Se envia correo de factura si esta registrada en el servidor
            if (DisponibilidadInternet && DisponibilidadServidor)
            {
                EnviarCorreo(factura.Correo, ubicacionPDF); 
            }
            
        }

        public bool ValidarCorreo(string correo)
        {
            try
            {
                //Instancia a la clase MailAddress de libreria, recibe como valor un string
                MailAddress m = new MailAddress(correo);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public void EnviarCorreo(string correo, string ubicacionPDF)
        {
             MailMessage message = new MailMessage();
             message.From = new MailAddress("practicapatos@gmail.com");
             message.To.Add(correo);
             message.Subject = "Este es un PDF C: ..";
             message.Body = "Contenido del PDF ";
             //Agrega al correo un archivo PDF para enviar.4
             message.Attachments.Add(new Attachment(ubicacionPDF));
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
