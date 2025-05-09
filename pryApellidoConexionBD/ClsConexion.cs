using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryApellidoConexionBD
{
    public class ClsConexion
    {
        // SqlCommand es una clase de ADO.NET que sirve para ejecutar
        /*  consultas (SELECT)
            inserciones (INSERT)
            actualizaciones (UPDATE)
            borrados (DELETE)
            o procedimientos almacenados en SQL Server. 
        */
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
                Console.WriteLine("✅ Producto agregado con éxito.");
                //MessageBox.Show("✅ Producto agregado con éxito.");

            }
        }

        public void Consultar()
        {
            using (SqlConnection conn = Conectar())
            {
                string selectQuery = "SELECT P.Nombre, P.Precio, P.Stock, C.Nombre AS Categoria " +
                    "FROM Productos P JOIN Categorias C ON P.CategoriaId = C.Id";

                // pasamos consulta
                SqlCommand cmd = new SqlCommand(selectQuery, conn);

                // lector de datos
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Nombre"]} - ${reader["Precio"]} - Stock: {reader["Stock"]} - Categoría: {reader["Categoria"]}");
                    //MessageBox.Show($"{reader["Nombre"]} - ${reader["Precio"]} - Stock: {reader["Stock"]} - Categoría: {reader["Categoria"]}");
                }
                reader.Close();
            }
        }

        public void Actualizar(string nombreProducto, decimal nuevoPrecio)
        {
            using (SqlConnection conn = Conectar())
            {
                string updateQuery = "UPDATE Productos SET Precio = @precio WHERE Nombre = @nombre";

                // pasamos la consulta, SQL command 
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@precio", nuevoPrecio);
                cmd.Parameters.AddWithValue("@nombre", nombreProducto);
                cmd.ExecuteNonQuery();
                Console.WriteLine("🔄 Producto actualizado.");
                //MessageBox.Show("🔄 Producto actualizado.");
            }
        }

        public void Eliminar(string nombreEliminar)
        {
            using (SqlConnection conn = Conectar())
            {
                string deleteQuery = "DELETE FROM Productos WHERE Nombre = @nombre";
                SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@nombre", nombreEliminar);
                cmd.ExecuteNonQuery();
                Console.WriteLine("❌ Producto eliminado.");
            }
        }
    }
}
