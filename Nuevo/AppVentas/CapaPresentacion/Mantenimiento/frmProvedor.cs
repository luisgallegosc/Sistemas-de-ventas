using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Mantenimiento
{
    public partial class frmProvedor : Form
    {
        public frmProvedor()
        {
            InitializeComponent();
        }

        cProveedor oProveedor = new cProveedor();
        cUtilitarios oUtilitarios = new cUtilitarios();
        int tiempo = 500;

        private void Limpiar()
        {
            lblIdProveedor.Text = "";
            txtRazonSocial.Text = "";
            txtRUCprovedor.Text = "";
            txtDireccionProvedor.Text = "";
            txtTelefono.Text = "";
            txtEmailProvedor.Text = "";
            dtpFechaInscripcion.Value = DateTime.Today;
            ActivarInsertar();
        }

        private void ActivarInsertar()
        {
            btnInsertar.Enabled = true;
            btnInsertar.Visible = true;
            btnActualizar.Enabled = false;
            btnActualizar.Visible = false;
        }
        public void ActivarActualizar()
        {
            btnActualizar.Enabled = true;
            btnActualizar.Visible = true;
            btnInsertar.Enabled = false;
            btnInsertar.Visible = false;
        }



        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            lblIdProveedor.Text = oProveedor.Generarcodigo();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (lblIdProveedor.Text.Trim() != "" && txtRazonSocial.Text.Trim() != "" && txtRUCprovedor.Text.Trim() != ""
                && txtDireccionProvedor.Text.Trim() != "" && txtTelefono.Text.Trim() != "" && txtEmailProvedor.Text.Trim() != ""
                && dtpFechaInscripcion.Value != DateTime.Today)
            {
                oProveedor.idProveedor = lblIdProveedor.Text.ToString();
                oProveedor.RazonSocial = txtRazonSocial.Text.ToString();
                oProveedor.Ruc = txtRUCprovedor.Text.ToString();
                oProveedor.Direccion = txtDireccionProvedor.Text.ToString();
                oProveedor.Telefono = txtTelefono.Text.ToString();
                oProveedor.Email = txtEmailProvedor.Text.ToString();
                oProveedor.FechaInscripcion = dtpFechaInscripcion.Value;

                oProveedor.Insertar();
                timerProveedor.Enabled = true;
                tiempo = 500;
                dgvProveedor.DataSource = oProveedor.Listar();
                Limpiar();
            }
            else
                MessageBox.Show("Falta completar datos");
        }

        private void timerProveedor_Tick_1(object sender, EventArgs e)
        {
            tiempo--;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (1 < dgvProveedor.Rows.Count)
            {
                int r = dgvProveedor.CurrentRow.Index;
                if (0 <= r && r < dgvProveedor.RowCount - 1)
                {
                    oProveedor.idProveedor = dgvProveedor.Rows[r].Cells[0].Value.ToString();
                    oProveedor.Eliminar();
                    Limpiar();
                    dgvProveedor.DataSource = oProveedor.Listar();
                }
                else
                    MessageBox.Show("Error: Selecciona la fila que desee eliminar");
            }
            else
                MessageBox.Show("Error: No hay Proveedores");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string campo = cmbCampo.Text;
            string contenido = txtContenido.Text;
            if (campo.Trim() != "" && contenido != "")
                dgvProveedor.DataSource = oProveedor.Buscar(campo, contenido);
            else
                MessageBox.Show("Faltan datos");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvProveedor.DataSource = oProveedor.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (lblIdProveedor.Text.Trim() != "" && txtRazonSocial.Text.Trim() != "" && txtRUCprovedor.Text.Trim() != ""
                && txtDireccionProvedor.Text.Trim() != "" && txtTelefono.Text.Trim() != "" && txtEmailProvedor.Text.Trim() != "" && dtpFechaInscripcion.Value != DateTime.Today)
            {
                oProveedor.idProveedor = lblIdProveedor.Text.ToString();
                oProveedor.RazonSocial = txtRazonSocial.Text.ToString();
                oProveedor.Ruc = txtRUCprovedor.Text.ToString();
                oProveedor.Direccion = txtDireccionProvedor.Text.ToString();
                oProveedor.Telefono = txtTelefono.Text.ToString();
                oProveedor.Email = txtEmailProvedor.Text.ToString();
                oProveedor.FechaInscripcion = dtpFechaInscripcion.Value;
                oProveedor.Modificar();
                timerProveedor.Enabled = true;
                tiempo = 500;
                dgvProveedor.DataSource = oProveedor.Listar();
                Limpiar();
                ActivarInsertar();
            }
        }

        private void dgvProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ActivarActualizar();
            int r = e.RowIndex;
            if (r < dgvProveedor.RowCount - 1)
            {
                lblIdProveedor.Text = dgvProveedor.Rows[r].Cells[0].Value.ToString();
                txtRazonSocial.Text = dgvProveedor.Rows[r].Cells[1].Value.ToString();
                txtRUCprovedor.Text = dgvProveedor.Rows[r].Cells[2].Value.ToString();
                txtDireccionProvedor.Text = dgvProveedor.Rows[r].Cells[3].Value.ToString();
                txtTelefono.Text = dgvProveedor.Rows[r].Cells[4].Value.ToString();
                txtEmailProvedor.Text = dgvProveedor.Rows[r].Cells[5].Value.ToString();
                dtpFechaInscripcion.Value = DateTime.Parse(dgvProveedor.Rows[r].Cells[6].Value.ToString());
            }
        }

    }
}
