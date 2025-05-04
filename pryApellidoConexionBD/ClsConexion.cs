using System;
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
    }
}
