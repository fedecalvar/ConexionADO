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

        //Form2 formContactos = new Form2();
        public Form1()
        {
            InitializeComponent();
            //formContactos.Show();
            btnActualizar.Enabled = false;
            btnAgregar.Enabled = false;
            btnConsultar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        ClsConexion conexion = new ClsConexion();

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

            // me permite usar los metodos que estan definidos dentro de la clase, como conectar o insertarproductos
            // como en este caso
            //ClsConexion conexion = new ClsConexion();
            conexion.InsertarProducto(nombre, descripcion, precio, stock, categoriaId);

            MessageBox.Show("✅ Producto agregado con éxito.");
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //ClsConexion conexion = new ClsConexion();
            conexion.Consultar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            conexion.Actualizar(txtNuevoNombre.Text, Convert.ToDecimal(txtNuevoPrecio.Text));
            txtNuevoNombre.Clear();
            txtNuevoPrecio.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            conexion.Eliminar(txtEliminar.Text);
            txtEliminar.Clear();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            switch (txtAccion.Text)
            {
                case "1":
                    btnActualizar.Enabled = false;
                    btnAgregar.Enabled = true;
                    btnConsultar.Enabled = false;
                    btnEliminar.Enabled = false;
                    break;
                case "2":
                    btnActualizar.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnConsultar.Enabled = true;
                    btnEliminar.Enabled = false;
                    break;
                case "3":
                    btnActualizar.Enabled = true;
                    btnAgregar.Enabled = false;
                    btnConsultar.Enabled = false;
                    btnEliminar.Enabled = false;
                    break;
                case "4":
                    btnActualizar.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnConsultar.Enabled = false;
                    btnEliminar.Enabled = true;
                    break;
                default:
                    MessageBox.Show("Numero inválido");
                    btnActualizar.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnConsultar.Enabled = false;
                    btnEliminar.Enabled = false;
                    break;
            }
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
