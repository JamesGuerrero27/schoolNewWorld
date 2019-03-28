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
using System.Data.SqlClient;
using capaDeNegocios;

namespace capaDePresentacion
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }
        // Declaraciones del API 
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = string.Empty;
                txtUser.ForeColor = Color.LightGray;

            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == string.Empty)
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.DimGray;

            }

        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = string.Empty;
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;

            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == string.Empty)
            {
                txtPass.Text = "Contraseña";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnMaestro user = new cnMaestro();
            SqlDataReader Loguear;
            user.Usuario = txtUser.Text;
            user.Contraseña = txtPass.Text;
            if (user.Usuario == txtUser.Text)
            {
                errorUsuario.Visible = false;

                if (user.Contraseña == txtPass.Text)
                {
                    errorContraseña.Visible = false;


                    Loguear = user.IniciarSesion();
                    if (Loguear.Read() == true)
                    {
                        this.Hide();
                        formPrincipal principal = new formPrincipal();
                        principal.Show();

                    }
                    else
                    {
                        errorLogin.Text = "Usuario o Contraseña invalidad, intente de nuevo";
                        errorLogin.Visible = true;
                        txtPass.Text = "";
                        txtPass_Leave(null, e);
                        txtUser.Focus();


                    }
                }
                else
                {
                    errorContraseña.Text = user.Contraseña;
                    errorContraseña.Visible = true;
                }
            }
            else
                errorUsuario.Text = user.Usuario;
            errorUsuario.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            recuperarContraseña recuperar = new recuperarContraseña();
            recuperar.ShowDialog();
        }

        private void formLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
