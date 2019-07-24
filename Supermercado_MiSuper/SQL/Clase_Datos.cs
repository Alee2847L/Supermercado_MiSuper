using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Supermercado_MiSuper.SQL
{
    class Clase_Datos
    {
        private string usuario;
        private string pass;
        private int sec;
        private DataTable tabla;
        //recuperar correo
        private DataTable tablacorreo;
        private string nombreempleado;
        private int mc;
        private string usuariocorreo;
        //fin
        private string ns;
        private string nomemp;
        private string nomempleado;
        private string apellido;
        private string fechaingreso;
        private string puesto;
        private string estado;
        private string estado1;
        private string sexo;
        private string telefono;
        private string direccion;
        private string correo;
        private string nombreusu;
        private string password;
        private string nivelusu;
        //Datos del cliente
        private int idecliente;
        private string nomclien;
        private string apeclient;
        private string idclien;
        private string estadoclien;
        private int compras;
        private string sexoclien;
        private string teleclien;
        private string dirclitn;
        private string correclein;

        //DATOS DEL PROVEEDOR
        private string nombreprovee;
        private string telefonoprovee;
        private string celularprovee;
        private string direccionprovee;
        private string descripprovee;
        private string estadoprovee;
        private string correoprovee;

        //DATOS PRODUCTO
        private int idprod;
        private string nombreprod;
        private string precio;
        DataTable tablaproductos;

        public string Ns { get => ns; set => ns = value; }


        Clase_Conectar con = new Clase_Conectar();
        SqlCommand cmd;
        SqlDataAdapter adaptador;
        SqlDataReader dr;

        public string Usuario { get => usuario; set => usuario = value; }
        public string Pass { get => pass; set => pass = value; }
        public int Sec { get => sec; set => sec = value; }
        public string Nomemp { get => nomemp; set => nomemp = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Fechaingreso { get => fechaingreso; set => fechaingreso = value; }
        public string Puesto { get => puesto; set => puesto = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Nomempleado { get => nomempleado; set => nomempleado = value; }
        public string Nombreusu { get => nombreusu; set => nombreusu = value; }
        public string Password { get => password; set => password = value; }
        public string Nivelusu { get => nivelusu; set => nivelusu = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Estado1 { get => estado1; set => estado1 = value; }
        // DATOS DEL CLIENTE
        public string Nomclien { get => nomclien; set => nomclien = value; }
        public string Apeclient { get => apeclient; set => apeclient = value; }
        public string Idclien { get => idclien; set => idclien = value; }
        public string Estadoclien { get => estadoclien; set => estadoclien = value; }
        public int Compras { get => compras; set => compras = value; }
        public string Sexoclien { get => sexoclien; set => sexoclien = value; }
        public string Teleclien { get => teleclien; set => teleclien = value; }
        public string Dirclitn { get => dirclitn; set => dirclitn = value; }
        public string Correclein { get => correclein; set => correclein = value; }
        public string Nombreempleado { get => nombreempleado; set => nombreempleado = value; }
        public int Mc { get => mc; set => mc = value; }
        public string Usuariocorreo { get => usuariocorreo; set => usuariocorreo = value; }
        public string Nombreprovee { get => nombreprovee; set => nombreprovee = value; }
        public string Telefonoprovee { get => telefonoprovee; set => telefonoprovee = value; }
        public string Celularprovee { get => celularprovee; set => celularprovee = value; }
        public string Direccionprovee { get => direccionprovee; set => direccionprovee = value; }
        public string Descripprovee { get => descripprovee; set => descripprovee = value; }
        public string Estadoprovee { get => estadoprovee; set => estadoprovee = value; }
        public string Correoprovee { get => correoprovee; set => correoprovee = value; }
        public int Idecliente { get => idecliente; set => idecliente = value; }
        public int Idprod { get => idprod; set => idprod = value; }
        public string Nombreprod { get => nombreprod; set => nombreprod = value; }
        public string Precio { get => precio; set => precio = value; }

        public Clase_Datos()
        {
            usuario = "";
            pass = "";
            sec = 0;
            tabla = new DataTable();
            tablacorreo = new DataTable();
            tablaproductos = new DataTable();
            nombreempleado = "";
            mc = 0;

        }

        public void logearse()
        {
            try
            {
                con.Abrirconexion();
                if (con.Estado == 1)
                {
                    tabla.Reset();
                    SqlDataAdapter adaptador = new SqlDataAdapter(string.Format("select * from PERSONA.Usuario where nombreUsuario='{0}' and passwordUsuario='{1}'", Usuario, Pass), con.Conexion);
                    adaptador.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        Sec = 1;
                        Ns = tabla.Rows[0][4].ToString();
                        estado = tabla.Rows[0][3].ToString();
                        ClaseUser.IdEmpleado = Convert.ToInt32(tabla.Rows[0][0]);
                        ClaseUser.Id = Convert.ToInt32(tabla.Rows[0][0]);
                        ClaseUser.Nombre = tabla.Rows[0][1].ToString();
                        ClaseUser.Nivel = tabla.Rows[0][4].ToString();
                    }
                    else
                    {
                        Sec = 0;
                        MessageBox.Show("incorect password or incorect user");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void recuperarcontrasena()
        {
            try
            {
                con.Abrirconexion();
                if(con.Estado==1)
                {
                    tabla.Reset();
                    SqlDataAdapter adp = new SqlDataAdapter(string.Format("select * from PERSONA.Empleado where nombreEmpleado='{0}'", Nombreempleado), con.Conexion);
                    adp.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        Mc = 1;
                        ClaseUser.Nombrecorreo = tabla.Rows[0][1].ToString();
                        ClaseUser.Correo = tabla.Rows[0][9].ToString();

                        if (ClaseUser.Correo!="")
                        {
                            tablacorreo.Reset();
                            SqlDataAdapter apd = new SqlDataAdapter(string.Format("select * from PERSONA.Usuario where nombreUsuario='{0}'", Nombreempleado), con.Conexion);
                            apd.Fill(tablacorreo);
                            {
                                ClaseUser.Contracorreo = tablacorreo.Rows[0][2].ToString();
                            }
                        }
                    }
                    else
                    {
                        mc = 0;
                        MessageBox.Show("usuario no valido");
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }
        public void buscarempleado()
        {
            try
            {
                con.Abrirconexion();
                if (con.Estado == 1)
                {
                    tabla.Reset();
                    SqlDataAdapter adaptador = new SqlDataAdapter(string.Format("select * from PERSONA.Empleado where nombreEmpleado='{0}'", Nomemp), con.Conexion);
                    adaptador.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        Sec = 1;
                        Nomempleado = tabla.Rows[0][1].ToString();
                        Apellido = tabla.Rows[0][2].ToString();
                        Fechaingreso = tabla.Rows[0][3].ToString();
                        Puesto = tabla.Rows[0][4].ToString();
                        Estado = tabla.Rows[0][5].ToString();
                        Sexo = tabla.Rows[0][6].ToString();
                        Telefono = tabla.Rows[0][7].ToString();
                        Direccion = tabla.Rows[0][8].ToString();
                        Correo = tabla.Rows[0][9].ToString();
                        ClaseUser.IdEmpleado = Convert.ToInt32(tabla.Rows[0][0]);
                    }
                    else
                    {
                        Sec = 0;
                        MessageBox.Show("Empleado no encontrado");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void buscarproveedor()
        {
            try
            {
                con.Abrirconexion();
                if (con.Estado == 1)
                {
                    tabla.Reset();
                    SqlDataAdapter adaptador = new SqlDataAdapter(string.Format("select * from PRODUCTO.Proveedor where nombreProveedor='{0}'", Nombreprovee), con.Conexion);
                    adaptador.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        Sec = 1;
                        Nombreprovee = tabla.Rows[0][1].ToString();
                        Telefonoprovee = tabla.Rows[0][2].ToString();
                        Celularprovee = tabla.Rows[0][3].ToString();
                        Direccionprovee = tabla.Rows[0][4].ToString();
                        Descripprovee = tabla.Rows[0][5].ToString();
                        Estadoprovee = tabla.Rows[0][6].ToString();
                        Correoprovee = tabla.Rows[0][7].ToString();
                    }
                    else
                    {
                        Sec = 0;
                        MessageBox.Show("Empleado no encontrado");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void buscarusuario()
        {
            try
            {
                con.Abrirconexion();
                if (con.Estado == 1)
                {
                    tabla.Reset();
                    SqlDataAdapter adaptador = new SqlDataAdapter(string.Format("select * from PERSONA.Usuario where nombreUsuario='{0}'", Nomemp), con.Conexion);
                    adaptador.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        Sec = 1;
                        nombreusu = tabla.Rows[0][1].ToString();
                        password = tabla.Rows[0][2].ToString();
                        Estado1 = tabla.Rows[0][3].ToString();
                        nivelusu = tabla.Rows[0][4].ToString();
                        ClaseUser.IdEmpleado = Convert.ToInt32(tabla.Rows[0][0]);
                    }
                    else
                    {
                        Sec = 0;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void buscarcliente()
        {
            try
            {
                con.Abrirconexion();
                if (con.Estado == 1)
                {
                    tabla.Reset();
                    SqlDataAdapter adaptador = new SqlDataAdapter(string.Format("select * from PERSONA.Cliente where nombreCliente='{0}'", Nomclien), con.Conexion);
                    adaptador.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        Sec = 1;
                        ClaseUser.Idecliente = Convert.ToInt32(tabla.Rows[0][0]);
                        ClaseUser.Nombrecliente = tabla.Rows[0][1].ToString();
                        Nomclien = tabla.Rows[0][1].ToString();
                        Apeclient = tabla.Rows[0][2].ToString();
                        Idclien = tabla.Rows[0][3].ToString();
                        Estadoclien = tabla.Rows[0][4].ToString();
                        //Compras = Convert.ToInt32(tabla.Rows[0][5].ToString());
                        Sexoclien = tabla.Rows[0][6].ToString();
                        Teleclien = tabla.Rows[0][7].ToString();
                        Dirclitn = tabla.Rows[0][8].ToString();
                        Correclein = tabla.Rows[0][9].ToString();
                        ClaseUser.IdEmpleado = Convert.ToInt32(tabla.Rows[0][0]);
                    }
                    else
                    {
                        Sec = 0;
                        MessageBox.Show("Cliente no encontrado");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void cargarDatos(DataGridView dtv)
        {
            try
            {
                con.Abrirconexion();
                if (con.Estado == 1)
                {
                    tabla.Reset();
                    adaptador = new SqlDataAdapter("select * from PRODUCTO.Producto", con.Conexion);
                    tabla = new DataTable();
                    adaptador.Fill(tabla);

                    dtv.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        public void cargarEmpleado(DataGridView dtv)
        {
            try
            {
                con.Abrirconexion();
                if (con.Estado == 1)
                {
                    tabla.Reset();
                    adaptador = new SqlDataAdapter("select * from PERSONA.Cliente", con.Conexion);
                    tabla = new DataTable();
                    adaptador.Fill(tabla);

                    dtv.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        public void cargardetallefactura(DataGridView dtv)
        {
            try
            {
                con.Abrirconexion();
                if (con.Estado == 1)
                {
                    tabla.Reset();
                    adaptador = new SqlDataAdapter("select * from REGISTRO.DetalleFactura", con.Conexion);
                    tabla = new DataTable();
                    adaptador.Fill(tabla);

                    dtv.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}

