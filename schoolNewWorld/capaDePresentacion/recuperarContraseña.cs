using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaDeNegocios;

namespace capaDePresentacion
{
    public partial class recuperarContraseña : Form
    {
        public recuperarContraseña()
        {
            InitializeComponent();
        }
        cnMaestro maestro = new cnMaestro();

        private void button1_Click(object sender, EventArgs e)
        {

            txtMensaje.Text = maestro.recuPass(txtUsuario.Text);
        }

       
    }
}
