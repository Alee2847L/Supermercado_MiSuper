﻿using System;
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
    public partial class Compras : Form
    {
        Clase_Conectar conexion = new Clase_Conectar();
        Clase_Datos dat = new Clase_Datos();
        DataTable tabla;

        public Compras()
        {
            InitializeComponent();
            tabla = new DataTable();
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
                dat.Nomclien = txtnombre.Text;
                dat.buscarcliente();
                if (dat.Sec == 1)
                {
                    txtide.Text = ClaseUser.Id.ToString();
                    txtnombre.Text = ClaseUser.Nombrecliente;
                }
            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Compras_Load(object sender, EventArgs e)
        {
            if (txtide.Text == "") { dat.cargarEmpleado(dgvproductos); }
            else
            {
                dat.cargarDatos(dgvproductos);
            }
        }

        private void FillByToolStripButton_Click(object sender, EventArgs e)
        {
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        { 
        }

        private void Dgvproductos_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void Dgvproductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Txtcodigo_Enter(object sender, EventArgs e)
        {
            dat.cargarDatos(dgvproductos);
        }

        private void Btnagregar_Click(object sender, EventArgs e)
        {
            //CREAR LAFACTURA
            if (txtcodigo.Text != "")
            {
                if (ClaseUser.Idfactura != 0)
                {
                    try
                    {
                        conexion.Abrirconexion();
                        if (conexion.Estado == 1)
                        {

                            string query = string.Format("AGREGARFACTURA");
                            SqlCommand comando = new SqlCommand(query, conexion.Conexion);
                            comando.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                            using (adaptador)
                            {
                                comando.Parameters.AddWithValue("@Empleado", ClaseUser.Id);
                                comando.Parameters.AddWithValue("@IdCliente", ClaseUser.Idecliente);
                                comando.ExecuteNonQuery();


                                MessageBox.Show(" Datos Insertado  ");
                            }

                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(" Datos No Insertado" + ex.Message);
                    }

                    ///////////////////////////////////////////////
                    //////////////////////////////////////////////
                    //BUSCAR LA FACTURA PARA ASIGNAR EL IDFACTURA
                    try
                    {
                        conexion.Abrirconexion();
                        if (conexion.Estado == 1)
                        {
                            tabla.Reset();
                            SqlDataAdapter adaptador = new SqlDataAdapter(string.Format("select * from REGISTRO.Factura where idCliente='{0}' and idEmpleado='{1}'", ClaseUser.Idecliente, ClaseUser.Id), conexion.Conexion);
                            adaptador.Fill(tabla);
                            if (tabla.Rows.Count > 0)
                            {

                                ClaseUser.Idfactura = Convert.ToInt32(tabla.Rows[0][1]);
                                MessageBox.Show("{0}", ClaseUser.Idfactura.ToString());
                            }
                            else
                            {
                                MessageBox.Show("factura no encontrada");
                            }
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

                

                ////////////////////////////////////////////////
                //////////////////////////////////////////////
                //calculo 

                //txttotal.Text = Convert.ToString((Convert.ToInt32(txtcantidad.Text)* Convert.ToInt32(txtprecio.Text)));
                //////////////////////////////////////////////
                //////////////////////////////////////////////
                //GUARDAR DETALLE FACTURA
                if (txtnombreprod.Text != "")
                {
                    try
                    {
                        conexion.Abrirconexion();
                        if (conexion.Estado == 1)
                        {

                            string query = string.Format("AGREGARDETALLEFACTURA");
                            SqlCommand comando = new SqlCommand(query, conexion.Conexion);
                            comando.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                            using (adaptador)
                            {
                                comando.Parameters.AddWithValue("@EMPLEADO", ClaseUser.IdEmpleado);
                                comando.Parameters.AddWithValue("@ID_PRODUCTO", txtcodigo.Text);
                                comando.Parameters.AddWithValue("@IDFACTURA", ClaseUser.Idfactura);
                                comando.Parameters.AddWithValue("@CANTIDAD", txtcantidad.Text);
                                comando.Parameters.AddWithValue("@TOTAL", txttotal.Text);
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

                txtcodigo.Text = "";
                txtcantidad.Text = "";
                txtnombreprod.Text = "";
                txttotal.Text = "";
                txtprecio.Text = "";
                txtcodigo.Focus();
                dat.cargardetallefactura(dgvfactura);
            }
        }

        private void Dgvproductos_DoubleClick(object sender, EventArgs e)
        {

        }

        private void Dgvproductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
                //dat.cargarDatos(dgvproductos);
                //var row = (sender as DataGridView).CurrentRow;
                txtcodigo.Text = this.dgvproductos.CurrentRow.Cells[0].Value.ToString();
                txtnombreprod.Text = this.dgvproductos.CurrentRow.Cells[3].Value.ToString();
                txtprecio.Text = this.dgvproductos.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
