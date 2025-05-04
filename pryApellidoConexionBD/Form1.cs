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
    public partial class Form1 : Form
    {

        Form2 formContactos = new Form2();
        public Form1()
        {
            InitializeComponent();
            formContactos.Show();
        }

        private void btnConexion_Click(object sender, EventArgs e)
        {
            
            ClsConexion conexionBD = new ClsConexion();

            try
            {
                SqlConnection conexion = conexionBD.Conectar();
                MessageBox.Show("✅ Conexión exitosa a la base de datos.");
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al conectar: " + ex.Message);
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            ClsConexion conexionBD = new ClsConexion();

            try
            {
                using (SqlConnection connection = conexionBD.Conectar())
                {
                    string query = "SELECT Nombre FROM Productos";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Items.Add(($"{reader["Nombre"]}"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error: " + ex.Message);
            }
        }
    }
}
