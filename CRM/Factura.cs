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
        public DateTime Fecha { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public int Cantidad_Productos { get; set; }

        public HashSet<Producto> productos;

        public void AgregarProducto(Producto producto)
        {
            if (productos.Add(producto) == false)
            {
                productos.Remove(producto);
                productos.Add(producto);
            }
        }

        public void CalcularSubtotal()
        {
            Subtotal = 0;
            Cantidad_Productos = 0;
            foreach(Producto p in productos)
            {
                Subtotal = Subtotal + p.Total;
                Cantidad_Productos = Cantidad_Productos + p.Cantidad;
            }
            IVA = Math.Round(Subtotal * (decimal)0.08,2);
            Total = IVA + Subtotal;
        }

        public void GenerarFolio(string NumeroSucursal)
        {
            Random r = new Random();            
            NoFolio = NumeroSucursal + r.Next(1000, 9999999).ToString();
        }
    }
}
