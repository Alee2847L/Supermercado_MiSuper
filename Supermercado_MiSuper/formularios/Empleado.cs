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
    public partial class Empleado : Form
    {
        Clase_Conectar conexion = new Clase_Conectar();
        Clase_Datos dat = new Clase_Datos();
        string usufin;
        public Empleado()
        {
            InitializeComponent();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pblimpiar_Click(object sender, EventArgs e)
        {
            txtnomemple.Text = "";
            txtapellido.Text = "";
            txtconfirmusu.Text = "";
            txtcontrausu.Text = "";
            txtcorreo.Text = "";
            txtdirec.Text = "";
            txtestado.Text = "";
            txtestadousu.Text = "";
            txtfecha.Text = "";
            txtnomusu.Text = "";
            cmbsex.Text = "";
            cmbtupousu.Text = "";
            txtPuesto.Text = "";
            txttelefono.Text = "";
            gbusuario.Enabled = false;
            btnact.Enabled = false;
            btnusuario.Enabled = true;
            btnguardar.Enabled = true;
            txtnomemple.Focus();
        }

        private void Btnactualizar_Click(object sender, EventArgs e)
        {
            txtestado.Text = "ACTIVO/A";
        }

        private void Btnact2_Click(object sender, EventArgs e)
        {
            txtestadousu.Text = "ACTIVO/A";
        }

        private void Btnguardar_Click(object sender, EventArgs e)
        {
            if (txtnomemple.Text != "")
            {
                try
                {
                    conexion.Abrirconexion();
                    if (conexion.Estado == 1)
                    {

                        string query = string.Format("AGREGAREMPLEADO");
                        SqlCommand comando = new SqlCommand(query, conexion.Conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        using (adaptador)
                        {
                            comando.Parameters.AddWithValue("@nombreEmpleado", txtnomemple.Text);
                            comando.Parameters.AddWithValue("@apellidoEmpleado", txtapellido.Text);
                            comando.Parameters.AddWithValue("@fechaIngreso", txtfecha.Text);
                            comando.Parameters.AddWithValue("@puesto", txtPuesto.Text);
                            comando.Parameters.AddWithValue("@sexo", cmbsex.Text);
                            comando.Parameters.AddWithValue("@telefono", txttelefono.Text);
                            comando.Parameters.AddWithValue("@direccion", txtdirec.Text);
                            comando.Parameters.AddWithValue("@correoEmpleado", txtcorreo.Text);
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
            if (txtcontrausu.Text == txtconfirmusu.Text)
            {
                usufin = txtcontrausu.Text;
            }
            else
            {
                MessageBox.Show("Contraseñas no son iguales");
                txtcontrausu.Text = "";
                txtconfirmusu.Text = "";
                txtcontrausu.Focus();
            }
            if (txtnomusu.Text != "")
            {
                try
                {
                    conexion.Abrirconexion();
                    if (conexion.Estado == 1)
                    {
                        string query = string.Format("AGREGARUSUARIO");
                        SqlCommand comando = new SqlCommand(query, conexion.Conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        using (adaptador)
                        {
                            comando.Parameters.AddWithValue("@Empleado", ClaseUser.IdEmpleado);
                            comando.Parameters.AddWithValue("@nombreUsuario", txtnomusu.Text);
                            comando.Parameters.AddWithValue("@passwordUsuario", usufin);
                            comando.Parameters.AddWithValue("@nivelUsuario", cmbtupousu.Text);
                            comando.ExecuteNonQuery();
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
            if (txtnomemple.Text != "")
            {

                try
                {
                    conexion.Abrirconexion();

                    if (conexion.Estado == 1)
                    {

                        string query = string.Format("ACTUALIZAREMPLEADO");
                        SqlCommand comando = new SqlCommand(query, conexion.Conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        using (adaptador)
                        {
                            comando.Parameters.AddWithValue("@Empleado", ClaseUser.IdEmpleado);
                            comando.Parameters.AddWithValue("@nombreEmpleado", txtnomemple.Text);
                            comando.Parameters.AddWithValue("@apellidoEmpleado", txtapellido.Text);
                            comando.Parameters.AddWithValue("@fechaIngreso", txtfecha.Text);
                            comando.Parameters.AddWithValue("@puesto", txtPuesto.Text);
                            comando.Parameters.AddWithValue("@estadoEmpleado", txtestado.Text);
                            comando.Parameters.AddWithValue("@sexo", cmbsex.Text);
                            comando.Parameters.AddWithValue("@telefono", txttelefono.Text);
                            comando.Parameters.AddWithValue("@direccion", txtdirec.Text);
                            comando.Parameters.AddWithValue("@correoEmpleado", txtcorreo.Text);
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
            if (txtcontrausu.Text == txtconfirmusu.Text)
            {
                usufin = txtcontrausu.Text;
            }
            else
            {
                MessageBox.Show("Contraseñas no son iguales");
                txtcontrausu.Text = "";
                txtconfirmusu.Text = "";
                txtcontrausu.Focus();
            }
            if (txtnomusu.Text != "")
            {
                try
                {
                    conexion.Abrirconexion();
                    if (conexion.Estado == 1)
                    {
                        string query = string.Format("ACTUALIZARUSUARIO");
                        SqlCommand comando = new SqlCommand(query, conexion.Conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        using (adaptador)
                        {
                            comando.Parameters.AddWithValue("@Empleado", ClaseUser.IdEmpleado);
                            comando.Parameters.AddWithValue("@nombreUsuario", txtnomusu.Text);
                            comando.Parameters.AddWithValue("@passwordUsuario", usufin);
                            comando.Parameters.AddWithValue("@estadoUsuario", txtestadousu.Text);
                            comando.Parameters.AddWithValue("@nivelUsuario", cmbtupousu.Text);
                            comando.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(" Datos No actualizados" + ex.Message);
                }
            }
        }

        private void Btneliminar_Click(object sender, EventArgs e)
        {
            if (txtnomemple.Text != "")
            {
                try
                {
                    conexion.Abrirconexion();
                    if (conexion.Estado == 1)
                    {

                        string query = string.Format("ELIMINAREMPLEADO");
                        SqlCommand comando = new SqlCommand(query, conexion.Conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        using (adaptador)
                        {
                            comando.Parameters.AddWithValue("@Empleado", ClaseUser.IdEmpleado);
                            comando.Parameters.AddWithValue("@nombreEmpleado", txtnomemple.Text);
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
            if (txtcontrausu.Text == txtconfirmusu.Text)
            {
                usufin = txtcontrausu.Text;
            }
            if (txtnomusu.Text != "")
            {
                try
                {
                    conexion.Abrirconexion();
                    if (conexion.Estado == 1)
                    {
                        string query = string.Format("ELIMINARUSUARIO");
                        SqlCommand comando = new SqlCommand(query, conexion.Conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        using (adaptador)
                        {
                            comando.Parameters.AddWithValue("@Empleado", ClaseUser.IdEmpleado);
                            comando.Parameters.AddWithValue("@nombreUsuario", txtnomusu.Text);
                            comando.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(" Datos No actualizados" + ex.Message);
                }
            }
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {
            if (txtnomemple.Text == "")
            {
                MessageBox.Show("Busque por nombre de empleado");
                txtnomemple.Focus();
            }
            else if (txtnomemple.Text != "")
            {
                btnusuario.Enabled = false;
                gbusuario.Enabled = false;
                btnguardar.Enabled = false;
                btnact.Enabled = true;
                dat.Nomemp = txtnomemple.Text;
                dat.buscarempleado();
                if (dat.Sec == 1)
                {
                    txtapellido.Text = dat.Apellido;
                    txtfecha.Text = dat.Fechaingreso;
                    txtPuesto.Text = dat.Puesto;
                    txtestado.Text = dat.Estado;
                    cmbsex.Text = dat.Sexo;
                    txttelefono.Text = dat.Telefono;
                    txtdirec.Text = dat.Direccion;
                    txtcorreo.Text = dat.Correo;
                    btnact.Enabled = true;
                }
                dat.Nomemp = txtnomemple.Text;
                dat.buscarusuario();
                if (dat.Sec == 1)
                {
                    txtnomusu.Text = dat.Nombreusu;
                    txtcontrausu.Text = dat.Password;
                    txtconfirmusu.Text = dat.Password;
                    cmbtupousu.Text = dat.Nivelusu;
                    txtestadousu.Text = dat.Estado1;
                }
                if (txtapellido.Text == "")
                {
                    btnguardar.Enabled = true;
                }
            }
        }

        private void Btnusuario_Click(object sender, EventArgs e)
        {
            gbusuario.Enabled = true;
            if (txtnomemple.Text != "")
            {
                txtnomusu.Enabled = false;
                txtnomusu.Text = txtnomemple.Text;
            }
        }

        private void Btnact_Click(object sender, EventArgs e)
        {
            gbusuario.Enabled = true;
            btnguardar.Enabled = true;
        }

        private void Empleado_Load(object sender, EventArgs e)
        {

        }
    }
}
