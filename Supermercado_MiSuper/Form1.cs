using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Supermercado_MiSuper.Usuarios;
using Supermercado_MiSuper.formularios;
using Supermercado_MiSuper.SQL;


namespace Supermercado_MiSuper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wparam, int lparam);

        private void btnslide_Click(object sender, EventArgs e)
        {
            if (menu.Width == 250) { menu.Width = 70;
                pbxmini.Visible = true;
            }
            else { menu.Width = 250;
                pbxmini.Visible = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void barratitulo_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            login frm = new login();
            if (e.KeyCode == Keys.F5)
            {
                frm.ShowDialog();
                if (ClaseUser.Nivel=="empleado")
                {
                    btnempleado.Visible = false;
                    btnproveedor.Visible = false;
                    btnpuntodeventa.Visible = true;
                    btnproductos.Visible = false;
                    btncliente.Visible = false;

                }
                else
                {
                    btnempleado.Visible = true;
                    btnproveedor.Visible = true;
                    btnpuntodeventa.Visible = false;
                    btnproductos.Visible = true;
                    btncliente.Visible = true;
                }
                lbluser.Text = ClaseUser.Nombre.ToString();
                lblnivel.Text = ClaseUser.Nivel.ToString();
            }

            
        }
        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.contenedor.Controls.Count > 0)
                this.contenedor.Controls.RemoveAt(0);

            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.contenedor.Controls.Add(fh);
            this.contenedor.Tag = fh;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           AbrirFormInPanel(new Empleado());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            login log = new login();
            log.ShowDialog();
            if (ClaseUser.Nivel=="empleado")
            {
                btnempleado.Visible = false;
                btnproveedor.Visible = false;
                btnpuntodeventa.Visible = true;
                btnproductos.Visible = false;
                btncliente.Visible = false;
            }
            else
            {
                btnempleado.Visible = true;
                btnproveedor.Visible = true;
                btnpuntodeventa.Visible = false;
                btnproductos.Visible = true;
                btncliente.Visible = true;
            }
            lbluser.Text = ClaseUser.Nombre.ToString();
            lblnivel.Text = ClaseUser.Nivel.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("h:mm:ss");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            login frm = new login();
            frm.ShowDialog();
            if (ClaseUser.Nivel == "empleado")
            {
                btnempleado.Visible = false;
                btnproveedor.Visible = false;
                btnpuntodeventa.Visible = true;
                btnproductos.Visible = false;
                btncliente.Visible = false;
                
            }
            else
            {
                btnempleado.Visible = true;
                btnproveedor.Visible = true;
                btnpuntodeventa.Visible = false;
                btnproductos.Visible = true;
                btncliente.Visible = true;
                

            }
            lbluser.Text = ClaseUser.Nombre.ToString();
            lblnivel.Text = ClaseUser.Nivel.ToString();
        }

        private void Btncliente_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Cliente());
        }

        private void Btnproductos_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Producto());
        }

        private void Btnproveedor_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Proveedor());
        }

        private void Contenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btnpuntodeventa_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Compras());
        }
    }
}
