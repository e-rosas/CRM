using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    public class Factura
    {
        public Factura()
        {
            productos = new HashSet<Producto>();
        }
        public string NoFolio { get; set; }
        public string RFC { get; set; }
        public string Correo { get; set; }
        public string Fecha { get; set; }
        public string Subtotal { get; set; }
        public string IVA { get; set; }
        public string Total { get; set; }
        public string Cantidad_Productos { get; set; }

        public HashSet<Producto> productos;

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }
    }
}
