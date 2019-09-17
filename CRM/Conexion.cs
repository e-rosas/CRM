using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRM
{
    public class Conexion
    {
        //Variable que puede tomar diferentes valores de conexion
        public string conexionString;
        SqlConnection conexion;

        //Permite utilizar procedimiento de creacion de una nueva transaccion (INSERT)
        public void NuevaTransaccion(Factura factura)
        {     
            //Una vez usada la conexion se vuelve a cerrar.
            using(conexion = new SqlConnection(conexionString))
            {   //Abre procedimiento y conexion
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("CreacionDeTransaccion", conexion))
                {
                    //Se ingresa el valor de los objetos a los parametros procedimentales de la BD.
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@NoFolio", factura.NoFolio));
                    comando.Parameters.Add(new SqlParameter("@RFC", factura.RFC));
                    comando.Parameters.Add(new SqlParameter("@Correo", factura.Correo));
                    comando.Parameters.Add(new SqlParameter("@Fecha", factura.Fecha));
                    comando.Parameters.Add(new SqlParameter("@Subtotal", factura.Subtotal));
                    comando.Parameters.Add(new SqlParameter("@IVA", factura.IVA));
                    comando.Parameters.Add(new SqlParameter("@Total", factura.Total));
                    comando.Parameters.Add(new SqlParameter("@Cantidad_Producto", factura.Cantidad_Productos));
                    comando.ExecuteNonQuery();                   
                }
                conexion.Close();
            }                      
        }

        //Permite introducir el valor de la columna que filtrara la informacion en la tabla Transacciones
        public DataTable VerTransacciones(string filtro)
        {
            //Una vez usada la conexion (usuario) se volvera a cerrar
            using(conexion = new SqlConnection(conexionString))
            {   // Abre procedimiento y Conexion
                using(SqlCommand comando = new SqlCommand("FiltroDeTransaccion", conexion))
                {   //Proporciona el valor de x columna a el parametro procedimental filtro
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@filtro", filtro));
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable transacciones = new DataTable();
                    adaptador.Fill(transacciones);
                    return transacciones; 
                }
            }
            
        }
    }
}
