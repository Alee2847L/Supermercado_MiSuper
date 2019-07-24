using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supermercado_MiSuper.SQL;

namespace Supermercado_MiSuper.Usuarios
{
    public partial class login : Form
    {
        Clase_Conectar conect = new Clase_Conectar();
        Clase_Datos dat = new Clase_Datos();
        private string correocopia;
        public login()
        {
            InitializeComponent();
            btnentrar.Focus();
            correocopia = "aleebryanmayorga@gmail.com";
        }

        private void btnentrar_Click(object sender, EventArgs e)
        {
            dat.Usuario = txtusuario.Text;
            dat.Pass = txtpass.Text;
            dat.logearse();
            if (dat.Sec == 1)
            {
                if (dat.Ns == "administrador" && dat.Estado == "ACTIVO/A")
                {
                    this.Close();
                }
                if (dat.Ns == "empleado" && dat.Estado == "ACTIVO/A")
                {
                    this.Close();
                }
                if (dat.Estado == "INACTIVO/A")
                {
                    MessageBox.Show("Lo sentimos su cuenta ha sido desactivada");
                }
            }
            else
            {
                MessageBox.Show("error al conectar");
            }
        }

        private void Txtusuario_Enter(object sender, EventArgs e)
        {
            if (txtusuario.Text == "USUARIO")
            {
                txtusuario.Text = "";
            }
        }

        private void Txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "CONTRASEÑA")
            {
                txtpass.Text = "";
            }
        }

        private void Txtusuario_Leave(object sender, EventArgs e)
        {
            if (txtusuario.Text=="")
            {
                txtusuario.Text = "USUARIO";
            }
        }

        private void Txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text=="")
            {
                txtpass.Text = "CONTRASEÑA";
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            btnentrar.Focus();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(txtusuario.Text!="")
            {
                dat.Nombreempleado = txtusuario.Text;
                dat.recuperarcontrasena();
                if(dat.Mc==1)
                {
                    MailMessage mmsg = new MailMessage();
                    mmsg.From = new MailAddress("bryanaleemeza@gmail.com");
                    mmsg.To.Add(ClaseUser.Correo);
                    mmsg.Subject="Recuperacion de correo";
                    mmsg.Body = ClaseUser.Contracorreo;
                    mmsg.IsBodyHtml = false;
                    mmsg.Priority = MailPriority.Normal;
                    mmsg.Bcc.Add(correocopia);
                    

                    //credenciales
                    SmtpClient cliente = new SmtpClient();
                    cliente.Host = "smtp.gmail.com";
                    cliente.Port = 587;
                    cliente.Credentials = new System.Net.NetworkCredential("bryanaleemeza@gmail.com", "");
                    cliente.EnableSsl = true;
                    

                    //cliente.Credentials = new System.Net.NetworkCredential("aleebryanmayorga@gmail.com", "Always0318199900806");
                    //cliente.Port =587;
                    //cliente.EnableSsl = true;
                    //cliente.Host = "mail.gmail.com";

                    try
                    {
                        cliente.Send(mmsg);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show(e.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un usuario");
                txtusuario.Focus();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text != "")
            {
                dat.Nombreempleado = txtusuario.Text;
                dat.recuperarcontrasena();
                if (dat.Mc == 1)
                {
                    MailMessage mmsg = new MailMessage();
                    mmsg.From = new MailAddress("bryanaleemeza@gmail.com");
                    mmsg.To.Add(ClaseUser.Correo);
                    mmsg.Subject = "Recuperacion de correo";
                    mmsg.Body = ClaseUser.Contracorreo;
                    mmsg.IsBodyHtml = false;
                    mmsg.Priority = MailPriority.Normal;
                    mmsg.Bcc.Add(correocopia);


                    //credenciales
                    SmtpClient cliente = new SmtpClient();
                    cliente.Host = "smtp.gmail.com";
                    cliente.Port = 465;
                    cliente.Credentials = new System.Net.NetworkCredential("bryanaleemeza@gmail.com", "Diosesamor0318");
                    cliente.EnableSsl = true;
                    cliente.Send(mmsg);

                    //cliente.Credentials = new System.Net.NetworkCredential("aleebryanmayorga@gmail.com", "");
                    //cliente.Port =587;
                    //cliente.EnableSsl = true;
                    //cliente.Host = "mail.gmail.com";

                    //try
                    //{
                    //    cliente.Send(mmsg);
                    //}
                    //catch (Exception)
                    //{

                    //    MessageBox.Show(e.ToString());
                    //}
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un usuario");
                txtusuario.Focus();
            }
        }
    }
}
