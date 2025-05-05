using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryApellidoConexionBD
{
    public class ClsConexion
    {
        private string cadenaConexion = "Server=localhost;Database=Comercio;Trusted_Connection=True;";

        public SqlConnection Conectar()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();
            return conexion;
        }

        public void InsertarProducto(string nombre, string descripcion, decimal precio, int stock, int categoriaId)
        {
            using (SqlConnection conn = Conectar())
            {
                string query = @"INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, CategoriaId)
                             VALUES (@nombre, @descripcion, @precio, @stock, @categoriaId)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@categoriaId", categoriaId);

                
                // ejecuta la consulta
                cmd.ExecuteNonQuery();

            }
        }
    }
}
