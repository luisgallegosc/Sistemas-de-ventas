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

namespace CapaPresentacion.Mantenimiento
{
    public partial class frmProducto : Form
    {
        public void limpiar()
        {
            lblIdProducto.Text = "";
            txtDenominacion.Text = "";
            txtCantidad.Text = "";
            txtPrecioUnitario.Text = "";
            txtStockInicial.Text = "";
            txtStockActual.Text = "";
            cmbCampo.SelectedIndex = -1;
            txtContenido.Text = "";
            activar_insertar();
        }
        public void activar_insertar()
        {
            btnInsertar.Enabled = true;
            btnInsertar.Visible = true;
            btnActualizar.Enabled = false;
            btnActualizar.Visible = false;
        }
        public void activar_actualizar()
        {
            btnActualizar.Enabled = true;
            btnActualizar.Visible = true;
            btnInsertar.Enabled = false;
            btnInsertar.Visible = false;
        }
        public frmProducto()
        {
            InitializeComponent();
        }
        CProducto oProducto = new CProducto();
        cUtilitarios oUtilitarios = new cUtilitarios();
        int tiempo = 500;

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            lblIdProducto.Text = oProducto.generarcodigo();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (lblIdProducto.Text.Trim() != "" && txtDenominacion.Text.Trim() != "" && txtCantidad.Text.Trim() != "" && txtPrecioUnitario.Text.Trim() != "" && txtStockInicial.Text.Trim() != "" && txtStockActual.Text.Trim() != "")
            {
                oProducto.Idproducto = lblIdProducto.Text.ToString();
                oProducto.Denominacion = txtDenominacion.Text.ToString();
                oProducto.Cantidad = int.Parse(txtCantidad.Text.ToString());
                oProducto.Stockinicial = int.Parse(txtStockInicial.Text.ToString());
                oProducto.Stockactual = int.Parse(txtStockActual.Text.ToString());
                oProducto.Preciounitario = float.Parse(txtPrecioUnitario.Text.ToString());
                oProducto.insertar();
                timerProducto.Enabled = true;
                tiempo = 500;
                dgvProducto.DataSource = oProducto.listar();
                limpiar();
            }
            else
                MessageBox.Show("Falta completar datos");
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (lblIdProducto.Text.Trim() != "" && txtDenominacion.Text.Trim() != "" && txtCantidad.Text.Trim() != "" && txtPrecioUnitario.Text.Trim() != "" && txtStockInicial.Text.Trim() != "" && txtStockActual.Text.Trim() != "")
            {
                oProducto.Idproducto = lblIdProducto.Text.ToString();
                oProducto.Denominacion = txtDenominacion.Text.ToString();
                oProducto.Cantidad = int.Parse(txtCantidad.Text.ToString());
                oProducto.Stockinicial = int.Parse(txtStockInicial.Text.ToString());
                oProducto.Stockactual = int.Parse(txtStockActual.Text.ToString());
                oProducto.Preciounitario = float.Parse(txtPrecioUnitario.Text.ToString());
                oProducto.modificar();
                timerProducto.Enabled = true;
                tiempo = 500;
                dgvProducto.DataSource = oProducto.listar();
                limpiar();
                activar_insertar();
            }
        }

        private void timerProducto_Tick(object sender, EventArgs e)
        {
            tiempo--;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string campo = cmbCampo.Text;
            string contenido = txtContenido.Text;
            if (campo.Trim() != "" && contenido != "")
                dgvProducto.DataSource = oProducto.buscar(campo, contenido);
            else
                MessageBox.Show("Faltan datos");
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (1 < dgvProducto.Rows.Count)
            {
                int r = dgvProducto.CurrentRow.Index;
                if (0 <= r && r < dgvProducto.RowCount - 1)
                {
                    oProducto.Idproducto = dgvProducto.Rows[r].Cells[0].Value.ToString();
                    oProducto.eliminar();
                    limpiar();
                    dgvProducto.DataSource = oProducto.listar();
                }
                else
                    MessageBox.Show("Error: Selecciona la fila que desee eliminar");
            }
            else
                MessageBox.Show("Error: No hay Productos");
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvProducto.DataSource = oProducto.listar();
        }
        private void dgvProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            activar_actualizar();
            int r = e.RowIndex;
            if (r < dgvProducto.RowCount - 1)
            {
                lblIdProducto.Text = dgvProducto.Rows[r].Cells[0].Value.ToString();
                txtDenominacion.Text = dgvProducto.Rows[r].Cells[1].Value.ToString();
                txtCantidad.Text = dgvProducto.Rows[r].Cells[2].Value.ToString();
                txtPrecioUnitario.Text = dgvProducto.Rows[r].Cells[3].Value.ToString();
                txtStockInicial.Text = dgvProducto.Rows[r].Cells[4].Value.ToString();
                txtStockActual.Text = dgvProducto.Rows[r].Cells[5].Value.ToString();
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnListar_Click_1(object sender, EventArgs e)
        {
            dgvProducto.DataSource = oProducto.listar();
        }
    }
}
