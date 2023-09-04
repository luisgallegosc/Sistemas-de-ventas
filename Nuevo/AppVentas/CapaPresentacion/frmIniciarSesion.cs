using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace CapaPresentacion
{
    public partial class frmIniciarSesion : Form
    {
        public void limpiar_d()
        {
            txtUsuario.Text = "";
            txtContrasena.Text = "";
        }
        public frmIniciarSesion()
        {
            InitializeComponent();
        }
        int intentos = 3;
        CUsuario oUsuario = new CUsuario();
        CEmpleado oEmpleado = new CEmpleado();
        cUtilitarios oUtilitarios = new cUtilitarios();
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;
            string idempleado = "";
            string nombre = "";
            contrasena = oUtilitarios.ObtenerMD5(contrasena);
            string cargo = oUsuario.cargo(usuario, contrasena, idempleado, nombre);
            if(cargo == "No")
            {
                intentos--;
                limpiar_d();
                lblIntentos.Text = "Le quedan " + intentos.ToString() + " intentos";
                if(intentos == 0)
                {
                    Application.Exit();
                }
            }
            else
            {
                frmPrincipal frmPadre = this.MdiParent as frmPrincipal;
                frmPadre.ponerU(usuario);
                if (cargo == "superadministrador")
                {
                    frmPadre.habilitar_super();

                }
                else if (cargo == "administrador")
                {
                    frmPadre.habilitar_administrador();
                }
                else
                    frmPadre.habilitar_vendedor();
                Close();
                intentos = 3;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            string correo = txtUsuario.Text;

            CUsuario usuario = new CUsuario();
            byte[] imagenBytes = usuario.ObtenerImagenPorCorreo(correo);

            if (imagenBytes != null)
            {
                using (MemoryStream ms = new MemoryStream(imagenBytes))
                {
                    pbImagen.Image = Image.FromStream(ms);
                }
            }
            else
            {
                string rutaImagenPredeterminada = @"C:\Users\benito\OneDrive\Escritorio\UNSAAC\desarrollo de software\guiaFinaal\Nuevo\AppVentas\CapaPresentacion\Imagenes\silueta.jpg";
                pbImagen.Image = Image.FromFile(rutaImagenPredeterminada);
            }
        }
    }
}
