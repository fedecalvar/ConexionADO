using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryApellidoConexionBD
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // datatable por que queremos una estructura en memoria que podeamos usar para llenar una grilla
        // o recorrer con codigo
        public DataTable ConsultaContactos()
        {
            // creamos el objeto de la clase ClsConexion
            ClsConexion conexion = new ClsConexion();

            // conn variable local, local por que solo existe dentro del bloque o metodo
            using (SqlConnection conn = conexion.Conectar())
            {
                string query = "SELECT * FROM Contactos";
                
                // le pasamos la consulta y la conexion, ademas creamos el objeto sqlcommand
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    
                    // Puente entre la base de datos y el dt
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    // creamos el dt vacio. Es una tabla en memoria osea en c#
                    DataTable dt = new DataTable();


                    // Ejecuta el comando que pase por query y llena el dt
                    da.Fill(dt);

                    // ahora a esta tabla la podemos pasar por un dgv
                    return dt;
                }
            }



            // explicacion de porque usamos 2 veces el using
            // El using sirve para trabajar con recursos que consumen memoria y conexiones,
            // y se asegura de que se liberen automáticamente cuando ya no se usan
            // (como cerrar archivos, conexiones, comandos, etc.).
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvContactos.DataSource = ConsultaContactos();
        }
    }
}
