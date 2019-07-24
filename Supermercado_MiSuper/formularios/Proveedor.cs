using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supermercado_MiSuper.SQL;
using System.Data.SqlClient;

namespace Supermercado_MiSuper.formularios
{
    public partial class Proveedor : Form
    {
        Clase_Conectar conexion = new Clase_Conectar();
        Clase_Datos dat = new Clase_Datos();
        public Proveedor()
        {
            InitializeComponent();
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btnactualizar_Click(object sender, EventArgs e)
        {
            txtestado.Text= "ACTIVO/A";
        }

        private void Pblimpiar_Click(object sender, EventArgs e)
        {
            txtnombre.Text = "";
            txttelefono.Text = "";
            txtcelular.Text = "";
            txtdireccion.Text = "";
            txtestado.Text = "";
            txtcorreo.Text = "";
            txtdescrip.Text = "";
            btnguardar.Enabled = true;
            txtnombre.Focus();
        }

        private void Btnguardar_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text != "")
            {
                try
                {
                    conexion.Abrirconexion();
                    if (conexion.Estado == 1)
                    {

                        string query = string.Format("AGREGARPROVEEDOR");
                        SqlCommand comando = new SqlCommand(query, conexion.Conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        using (adaptador)
                        {
                            comando.Parameters.AddWithValue("@empleado", ClaseUser.IdEmpleado);
                            comando.Parameters.AddWithValue("@nombreProveedor", txtnombre.Text);
                            comando.Parameters.AddWithValue("@telefonoProveedor", txttelefono.Text);
                            comando.Parameters.AddWithValue("@celularproveedor", txtcelular.Text);
                            comando.Parameters.AddWithValue("@direccionProveedor", txtdireccion.Text);
                            comando.Parameters.AddWithValue("@descripcionProveedor", txtdescrip.Text);
                            comando.Parameters.AddWithValue("@correoProveedor", txtcorreo.Text);
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
            if (txtnombre.Text != "")
            {

                try
                {
                    conexion.Abrirconexion();

                    if (conexion.Estado == 1)
                    {

                        string query = string.Format("ACTUALIZARPROVEEDOR");
                        SqlCommand comando = new SqlCommand(query, conexion.Conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        using (adaptador)
                        {
                            comando.Parameters.AddWithValue("@empleado", ClaseUser.IdEmpleado);
                            comando.Parameters.AddWithValue("@nombreProveedor", txtnombre.Text);
                            comando.Parameters.AddWithValue("@telefonoProveedor", txttelefono.Text);
                            comando.Parameters.AddWithValue("@celularproveedor", txtcelular.Text);
                            comando.Parameters.AddWithValue("@direccionProveedor", txtdireccion.Text);
                            comando.Parameters.AddWithValue("@descripcionProveedor", txtdescrip.Text);
                            comando.Parameters.AddWithValue("@estado", txtestado.Text);
                            comando.Parameters.AddWithValue("@correoProveedor", txtcorreo.Text);
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
            if (txtnombre.Text != "")
            {
                try
                {
                    conexion.Abrirconexion();
                    if (conexion.Estado == 1)
                    {

                        string query = string.Format("ELIMINARPROVEEDOR");
                        SqlCommand comando = new SqlCommand(query, conexion.Conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        using (adaptador)
                        {
                            comando.Parameters.AddWithValue("@Empleado", ClaseUser.IdEmpleado);
                            comando.Parameters.AddWithValue("@nombre", txtnombre.Text);
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

        private void Btnbuscar_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                MessageBox.Show("Busque por nombre de cliente");
                txtnombre.Focus();
            }
            else if (txtnombre.Text != "")
            {
                btnguardar.Enabled = false;
                dat.Nombreprovee = txtnombre.Text;
                dat.buscarproveedor();
                if (dat.Sec == 1)
                {
                    txtnombre.Text = dat.Nombreprovee;
                    txttelefono.Text = dat.Telefonoprovee;
                    txtcelular.Text = dat.Celularprovee;
                    txtdireccion.Text = dat.Direccionprovee;
                    txtdescrip.Text = dat.Descripprovee;
                    txtestado.Text = dat.Estadoprovee;
                    txtcorreo.Text = dat.Correoprovee;
                }
            }
        }
    }
}
