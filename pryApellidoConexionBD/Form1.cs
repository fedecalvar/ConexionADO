using System;
using System.Collections;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            ClsConexion conexion = new ClsConexion();

            using (SqlConnection conn = conexion.Conectar())
            {
                string query = "SELECT Id, Nombre FROM Categorias";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboCategoria.DataSource = dt;
                cboCategoria.DisplayMember = "Nombre";
                cboCategoria.ValueMember = "Id";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            decimal precio = Convert.ToDecimal(txtPrecio.Text);
            int stock = Convert.ToInt32(txtStock.Text);
            int categoriaId = Convert.ToInt32(cboCategoria.SelectedValue);

            ClsConexion conexion = new ClsConexion();
            conexion.InsertarProducto(nombre, descripcion, precio, stock, categoriaId);

            MessageBox.Show("✅ Producto agregado con éxito.");
        }












        /*private void btnConexion_Click(object sender, EventArgs e)
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
        }*/
    }
}
