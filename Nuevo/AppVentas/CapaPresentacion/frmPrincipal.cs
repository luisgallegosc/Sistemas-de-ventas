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
using CapaPresentacion.Mantenimiento;
using CapaPresentacion.Procesos;
using CapaPresentacion.Reportes;

namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            actualizarFecha();
            actualizarHora();
            limpiarU();
            desabilitar();
            frmIniciarSesion frmChild1 = new frmIniciarSesion();
            frmChild1.MdiParent = this;
            frmChild1.Show();
        }
        CUsuario oUsuario = new CUsuario();
        public void habilitar_super()
        {
            tsmConsultas.Enabled = true; tsmConsultas.Visible = true;
            tsmMantenimiento.Enabled = true; tsmMantenimiento.Visible = true;
            tsmProcesos.Enabled = true; tsmProcesos.Visible = true;
            tsmSeguridad.Enabled = true; tsmSeguridad.Visible = true;
            tsmSalir.Enabled = true; tsmSalir.Visible = true;
        }
        public void habilitar_administrador()
        {
            tsmConsultas.Enabled = true; tsmConsultas.Visible = true;
            tsmMantenimiento.Enabled = true; tsmMantenimiento.Visible = true;
            tsmSeguridad.Enabled = true; tsmSeguridad.Visible = true;
            tsmSalir.Enabled = true; tsmSalir.Visible = true;
        }
        public void habilitar_vendedor()
        {
            tsmProcesos.Enabled = true; tsmProcesos.Visible = true;
            tsmMantenimiento.Enabled = true; tsmMantenimiento.Visible = true;
        }
        public void desabilitar()
        {
            tsmConsultas.Enabled = false; tsmConsultas.Visible = false;
            tsmMantenimiento.Enabled = false; tsmMantenimiento.Visible = false;
            tsmProcesos.Enabled = false; tsmProcesos.Visible = false;
            tsmSeguridad.Enabled = false; tsmSeguridad.Visible = false;
            tsmSalir.Enabled = false; tsmSalir.Visible = false;
        }
        public void ponerU(string s)
        {
            tsslNombreUsuario.Text = s;
        }
        public void limpiarU()
        {
            tsslNombreUsuario.Text = "Nombre del usuario";
        }
        public void actualizarFecha()
        {
            tsslFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        public void actualizarHora()
        {
            tsslHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void tsmiMEmpleado_Click(object sender, EventArgs e)
        {
            Mantenimiento.frmEmpleado frmChild2 = new Mantenimiento.frmEmpleado();
            frmChild2.MdiParent = this;
            frmChild2.Show();
        }

        private void tsmiSSi_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiMCliente_Click(object sender, EventArgs e)
        {
            Mantenimiento.frmCliente frmChild3 = new Mantenimiento.frmCliente();
            frmChild3.MdiParent = this;
            frmChild3.Show();
        }

        private void tsmiMProducto_Click(object sender, EventArgs e)
        {
            Mantenimiento.frmProducto frmChild4 = new Mantenimiento.frmProducto();
            frmChild4.MdiParent = this;
            frmChild4.Show();
        }

        private void tsmiSCambiarContrasena_Click(object sender, EventArgs e)
        {
            Seguridad.frmCambiarContrasena frmChild5 = new Seguridad.frmCambiarContrasena();
            frmChild5.MdiParent = this;
            frmChild5.Show();
        }

        private void tsmiCambiarEstado_Click(object sender, EventArgs e)
        {
            Seguridad.frmCambiarEstado frmChild6 = new Seguridad.frmCambiarEstado();
            frmChild6.MdiParent = this;
            frmChild6.Show();
        }

        private void tsmiSNo_Click(object sender, EventArgs e)
        {
            tsmiSNo.DropDown.Close();
        }

        private void tsmiMReiniciar_Click(object sender, EventArgs e)
        {
            foreach (Form formHijo in this.MdiChildren)
            {
                formHijo.Close();
            }
            desabilitar();
            limpiarU();
            frmIniciarSesion frmChild1 = new frmIniciarSesion();
            frmChild1.MdiParent = this;
            frmChild1.Show();
        }

        private void tsmiVentas_Click(object sender, EventArgs e)
        {
            Procesos.frmVenta frmChild7 = new Procesos.frmVenta();
            frmChild7.MdiParent = this;
            frmChild7.lblIdEmpleado.Text = oUsuario.idEmpleado(tsslNombreUsuario.Text);
            frmChild7.lblNombreEmpleado.Text = oUsuario.nombreEmpleado(tsslNombreUsuario.Text);
            frmChild7.Show();
        }

        private void anularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAnularVenta frmChild = new frmAnularVenta(); 
            frmChild.MdiParent = this; 
            frmChild.Show(); 
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompras frmChild = new frmCompras(); 
            frmChild.MdiParent = this;
            frmChild.lblIdEmpleado.Text = oUsuario.idEmpleado(tsslNombreUsuario.Text);
            frmChild.lblNombreEmpleado.Text = oUsuario.nombreEmpleado(tsslNombreUsuario.Text);
            frmChild.Show(); 
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProvedor frmChild = new frmProvedor();
            frmChild.MdiParent = this;
            frmChild.Show();
        }

        private void kardexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKardex frmChild = new frmKardex();
            frmChild.MdiParent = this;
            frmChild.Show();
        }

        private void ventasDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentadelDia frmChild = new frmVentadelDia();
            frmChild.MdiParent = this;
            frmChild.Show();
        }
    }
}
