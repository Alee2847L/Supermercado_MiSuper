using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Supermercado_MiSuper.SQL;

namespace Supermercado_MiSuper.formularios
{
    public partial class Cliente : Form
    {
        Clase_Conectar conexion = new Clase_Conectar();
        Clase_Datos dat = new Clase_Datos();
        public Cliente()
        {
            InitializeComponent();
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pblimpiar_Click(object sender, EventArgs e)
        {
            txtnombreCliente.Text = "";
            txtapellidocliente.Text = "";
            txtidentidaddelcliente.Text = "";
            txttelefono.Text = "";
            txtcorreocliente.Text = "";
            txtdireccion.Text = "";
            txtsexo.Text = "";
            txtvecescompra.Text = "";
            txtestado.Text = "";
            btnguardar.Enabled = true;
            txtnombreCliente.Focus();
        }

        private void Btnguardar_Click(object sender, EventArgs e)
        {
            if (txtnombreCliente.Text != "")
            {
                try
                {
                    conexion.Abrirconexion();
                    if (conexion.Estado == 1)
                    {

                        string query = string.Format("AGREGARCLIENTE");
                        SqlCommand comando = new SqlCommand(query, conexion.Conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        using (adaptador)
                        {
                            comando.Parameters.AddWithValue("@empleado", ClaseUser.IdEmpleado);
                            comando.Parameters.AddWithValue("@nombreCliente", txtnombreCliente.Text);
                            comando.Parameters.AddWithValue("@apellidoCliente", txtapellidocliente.Text);
                            comando.Parameters.AddWithValue("@identidad", txtidentidaddelcliente.Text);
                            comando.Parameters.AddWithValue("@sexo", txtsexo.Text);
                            comando.Parameters.AddWithValue("@telefono", txttelefono.Text);
                            comando.Parameters.AddWithValue("@direccion", txtdireccion.Text);
                            comando.Parameters.AddWithValue("@correoCliente", txtcorreocliente.Text);
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
            if (txtnombreCliente.Text != "")
            {

                try
                {
                    conexion.Abrirconexion();

                    if (conexion.Estado == 1)
                    {

                        string query = string.Format("ACTUALIZARCLIENTE");
                        SqlCommand comando = new SqlCommand(query, conexion.Conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        using (adaptador)
                        {
                            comando.Parameters.AddWithValue("@Empleado", ClaseUser.IdEmpleado);
                            comando.Parameters.AddWithValue("@nombreCliente", txtnombreCliente.Text);
                            comando.Parameters.AddWithValue("@apellidoCliente", txtapellidocliente.Text);
                            comando.Parameters.AddWithValue("@identidad", txtidentidaddelcliente.Text);
                            comando.Parameters.AddWithValue("@estadoCliente", txtestado.Text);
                            comando.Parameters.AddWithValue("@vecesCompra", txtvecescompra.Text);
                            comando.Parameters.AddWithValue("@sexo", txtsexo.Text);
                            comando.Parameters.AddWithValue("@telefono", txttelefono.Text);
                            comando.Parameters.AddWithValue("@direccion", txtdireccion.Text);
                            comando.Parameters.AddWithValue("@correoCliente", txtcorreocliente.Text);
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
            if (txtnombreCliente.Text != "")
            {
                try
                {
                    conexion.Abrirconexion();
                    if (conexion.Estado == 1)
                    {

                        string query = string.Format("ELIMINARCLIENTE");
                        SqlCommand comando = new SqlCommand(query, conexion.Conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        using (adaptador)
                        {
                            comando.Parameters.AddWithValue("@Empleado", ClaseUser.IdEmpleado);
                            comando.Parameters.AddWithValue("@nombreCliente", txtnombreCliente.Text);
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
            if (txtnombreCliente.Text == "")
            {
                MessageBox.Show("Busque por nombre de cliente");
                txtnombreCliente.Focus();
            }
            else if (txtnombreCliente.Text != "")
            {
                btnguardar.Enabled = false;
                dat.Nomclien = txtnombreCliente.Text;
                dat.buscarcliente();
                if (dat.Sec == 1)
                {
                    txtapellidocliente.Text = dat.Apeclient;
                    txtidentidaddelcliente.Text = dat.Idclien;
                    txtestado.Text = dat.Estadoclien;
                    txtvecescompra.Text = dat.Compras.ToString();
                    txtsexo.Text = dat.Sexoclien;
                    txttelefono.Text = dat.Teleclien;
                    txtdireccion.Text = dat.Dirclitn;
                    txtcorreocliente.Text = dat.Correclein;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            Compras compras = new Compras();
            compras.txtidemp.Text = ClaseUser.Id.ToString();
            compras.txtide.Text = ClaseUser.Idecliente.ToString();
            compras.txtnombre.Text = ClaseUser.Nombrecliente;
            compras.gbdatos.Enabled = false;
            compras.ShowDialog();
        }
    }
}
