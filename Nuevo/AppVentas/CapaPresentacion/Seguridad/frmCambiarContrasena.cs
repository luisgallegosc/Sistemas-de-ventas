using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace CapaPresentacion.Seguridad
{
    public partial class frmCambiarContrasena : Form
    {
        public void limpiar()
        {
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            txtNuevaContrasena.Text = "";
        }
        public frmCambiarContrasena()
        {
            InitializeComponent();
        }
        CUsuario oUsuario = new CUsuario();
        cUtilitarios oUtilitarios = new cUtilitarios();

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;
            string nuevacontrasena = txtNuevaContrasena.Text;
            contrasena = oUtilitarios.ObtenerMD5(contrasena);
            nuevacontrasena = oUtilitarios.ObtenerMD5(nuevacontrasena);
            if (oUsuario.existeUsuario(usuario, contrasena)){
                oUsuario.cambiarContrasena(usuario, nuevacontrasena);
                MessageBox.Show("Proceso existoso");
            }
            else
            {
                MessageBox.Show("El usuario no existe");
            }
            limpiar();
        }
    }
}
