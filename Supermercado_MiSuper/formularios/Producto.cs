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
using Supermercado_MiSuper.SQL;

namespace Supermercado_MiSuper.formularios
{
    public partial class Producto : Form
    {

        Clase_Conectar conexion = new Clase_Conectar();
        Clase_Datos dat = new Clase_Datos();
        private DataTable tabla;
        public Producto()
        {
            InitializeComponent();
            tabla = new DataTable();
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btnguardar_Click(object sender, EventArgs e)
        {
             if (txtidprovee.Text != "")
            {
                try
                {
                    conexion.Abrirconexion();
                    if (conexion.Estado == 1)
                    {

                        string query = string.Format("AGREGARPRODUCTO");
                        SqlCommand comando = new SqlCommand(query, conexion.Conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        using (adaptador)
                        {
                            comando.Parameters.AddWithValue("@empleado", ClaseUser.IdEmpleado);
                            comando.Parameters.AddWithValue("@idProveedor", txtidprovee.Text);
                            comando.Parameters.AddWithValue("@idCategoriaProducto", txtidcat.Text);
                            comando.Parameters.AddWithValue("@nombreProducto", txtnombreprod.Text);
                            comando.Parameters.AddWithValue("@stock", txtsto.Text);
                            comando.Parameters.AddWithValue("@precio", txtprecio.Text);
                            comando.Parameters.AddWithValue("@marca", txtmarca.Text);
                            comando.Parameters.AddWithValue("@fechaCaducidad", txtfecha.Text);
                            comando.ExecuteNonQuery();
                            MessageBox.Show(" Datos Insertado");
                        }

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(" Datos No Insertado" + ex.Message);
                }
            }
        }

        private void Btnactuali_Click(object sender, EventArgs e)
        {
            if (txtnombreprod.Text != "")
            {

                try
                {
                    conexion.Abrirconexion();

                    if (conexion.Estado == 1)
                    {

                        string query = string.Format("ACTUALIZARPRODUCTO");
                        SqlCommand comando = new SqlCommand(query, conexion.Conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        using (adaptador)
                        {
                            comando.Parameters.AddWithValue("@Empleado", ClaseUser.IdEmpleado);
                            comando.Parameters.AddWithValue("@estado", txtestado.Text);
                            comando.Parameters.AddWithValue("@idProveedor", txtidprovee.Text);
                            comando.Parameters.AddWithValue("@idCategoriaProducto", txtidcat.Text);
                            comando.Parameters.AddWithValue("@nombreProducto", txtnombreprod.Text);
                            comando.Parameters.AddWithValue("@stock", txtsto.Text);
                            comando.Parameters.AddWithValue("@precio", txtprecio.Text);
                            comando.Parameters.AddWithValue("@marca", txtmarca.Text);
                            comando.Parameters.AddWithValue("@fechaCaducidad", txtfecha.Text);
                            comando.ExecuteNonQuery();
                            MessageBox.Show(" Datos Actualizados");
                        }

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(" Datos No Actualizados" + ex.Message);
                }
            }
        }

        private void Btneliminar_Click(object sender, EventArgs e)
        {
            if (txtnombreprod.Text != "")
            {
                try
                {
                    conexion.Abrirconexion();
                    if (conexion.Estado == 1)
                    {

                        string query = string.Format("ELIMINARPRODUCTO");
                        SqlCommand comando = new SqlCommand(query, conexion.Conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        using (adaptador)
                        {
                            comando.Parameters.AddWithValue("@Empleado", ClaseUser.IdEmpleado);
                            comando.Parameters.AddWithValue("@nombre", txtnombreprod.Text);
                            comando.ExecuteNonQuery();
                            MessageBox.Show(" Datos Eliminados");
                        }

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(" Datos No Eliminados" + ex.Message);
                }
            }
        }

        private void Btnactualizar_Click(object sender, EventArgs e)
        {
            txtestado.Text = "ACTIVO/A";
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {
            if (txtnombreprod.Text == "")
            {
                MessageBox.Show("Busque por nombre de cliente");
                txtnombreprod.Focus();
            }
            else if (txtnombreprod.Text != "")
            {
                try
                {
                    conexion.Abrirconexion();
                    if (conexion.Estado == 1)
                    {
                        tabla.Reset();
                        SqlDataAdapter adaptador = new SqlDataAdapter(string.Format("select * from PRODUCTO.Producto where nombreProducto='{0}'", txtnombreprod.Text), conexion.Conexion);
                        adaptador.Fill(tabla);
                        if (tabla.Rows.Count > 0)
                        {
                            txtidprovee.Text = tabla.Rows[0][1].ToString();
                            txtidcat.Text = tabla.Rows[0][2].ToString();
                            txtnombreprod.Text = tabla.Rows[0][3].ToString();
                            txtestado.Text = tabla.Rows[0][4].ToString();
                            txtsto.Text = tabla.Rows[0][5].ToString();
                            txtprecio.Text = tabla.Rows[0][6].ToString();
                            txtmarca.Text = tabla.Rows[0][7].ToString();
                            txtfecha.Text = tabla.Rows[0][8].ToString();
                            ClaseUser.IdEmpleado = Convert.ToInt32(tabla.Rows[0][0]);
                            btnguardar.Enabled = false;
                        }
                        else
                        {
                            
                            MessageBox.Show("Empleado no encontrado");
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            }

        private void Pblimpiar_Click(object sender, EventArgs e)
        {
            txtnombreprod.Text = "";
            txtidcat.Text = "";
            txtidprovee.Text = "";
            txtestado.Text = "";
            txtsto.Text = "";
            txtprecio.Text = "";
            txtestado.Text = "";
            txtmarca.Text = "";
            txtfecha.Text = "";
            btnguardar.Enabled = true;
            txtnombreprod.Focus();
        }
    }
    
}
