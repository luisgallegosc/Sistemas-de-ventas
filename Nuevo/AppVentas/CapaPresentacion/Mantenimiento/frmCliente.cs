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
    public partial class frmCliente : Form
    {
        public void limpiar()
        {
            lblIdCliente.Text = "";
            txtNombre.Text = "";
            txtDNI.Text = "";
            txtEmail.Text = "";
            txtDireccion.Text = "";
            txtRuc.Text = "";
            cmbCampo.SelectedIndex = -1;
            txtContenido.Text = "";
            dtpFechaNacimiento.Value = DateTime.Today;
            pcbImagen.Image = Image.FromFile("C:\\Users\\benito\\OneDrive\\Escritorio\\UNSAAC\\desarrollo de software\\guiaFinaal\\Nuevo\\AppVentas\\CapaPresentacion\\Imagenes\\silueta.jpg");
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
        public frmCliente()
        {
            InitializeComponent();
        }
        CCliente oCliente = new CCliente();
        cUtilitarios oUtilitarios = new cUtilitarios();
        int tiempo = 500;


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            lblIdCliente.Text = oCliente.generarcodigo();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (lblIdCliente.Text.Trim() != "" && txtNombre.Text.Trim() != "" && txtDNI.Text.Trim() != "" && txtEmail.Text.Trim() != ""
                && txtDireccion.Text.Trim() != "" && txtRuc.Text.Trim() != "" && dtpFechaNacimiento.Value != DateTime.Today)
            {
                oCliente.Idcliente = lblIdCliente.Text.ToString();
                oCliente.Nombre = txtNombre.Text.ToString();
                oCliente.Dni = txtDNI.Text.ToString();
                oCliente.Email = txtEmail.Text.ToString();
                oCliente.Direccion = txtDireccion.Text.ToString();
                oCliente.Ruc = txtRuc.Text.ToString();
                oCliente.Foto = oUtilitarios.Image2Bytes(pcbImagen.Image);
                oCliente.Fechanacimiento = dtpFechaNacimiento.Value;
                oCliente.insertar();
                timerCliente.Enabled = true;
                tiempo = 500;
                dgvCliente.DataSource = oCliente.listar();
                limpiar();
            }
            else
                MessageBox.Show("Falta completar datos");
        }

        private void timerCliente_Tick(object sender, EventArgs e)
        {
            tiempo--;
            
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivo de imagen|*.jpg;*.jpeg;*.png;*.gif";
                openFileDialog.Title = "Seleccionar una imagen";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string rutaImagen = openFileDialog.FileName;
                        pcbImagen.Image = Image.FromFile(rutaImagen);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar la imagen " + ex.Message, "Error");
                    }
                }
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string campo = cmbCampo.Text;
            string contenido = txtContenido.Text;
            if (campo.Trim() != "" && contenido != "")
                dgvCliente.DataSource = oCliente.buscar(campo, contenido);
            else
                MessageBox.Show("Faltan datos");
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (1 < dgvCliente.Rows.Count)
            {
                int r = dgvCliente.CurrentRow.Index;
                if (0 <= r && r < dgvCliente.RowCount - 1)
                {
                    oCliente.Idcliente = dgvCliente.Rows[r].Cells[0].Value.ToString();
                    oCliente.eliminar();
                    limpiar();
                    dgvCliente.DataSource = oCliente.listar();
                }
                else
                    MessageBox.Show("Error: Selecciona la fila que desee eliminar");
            }
            else
                MessageBox.Show("Error: No hay Clientes");
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvCliente.DataSource = oCliente.listar();
        }

        private void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            activar_actualizar();
            int r = e.RowIndex;
            if (r < dgvCliente.RowCount - 1)
            {
                lblIdCliente.Text = dgvCliente.Rows[r].Cells[0].Value.ToString();
                txtNombre.Text = dgvCliente.Rows[r].Cells[1].Value.ToString();
                txtDNI.Text = dgvCliente.Rows[r].Cells[2].Value.ToString();
                txtRuc.Text = dgvCliente.Rows[r].Cells[3].Value.ToString();
                txtEmail.Text = dgvCliente.Rows[r].Cells[4].Value.ToString();
                txtDireccion.Text = dgvCliente.Rows[r].Cells[5].Value.ToString();
                dtpFechaNacimiento.Value = DateTime.Parse(dgvCliente.Rows[r].Cells[6].Value.ToString());
                pcbImagen.Image = oUtilitarios.Bytes2Image(oCliente.imagen(lblIdCliente.Text));
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (lblIdCliente.Text.Trim() != "" && txtNombre.Text.Trim() != "" && txtDNI.Text.Trim() != "" && txtEmail.Text.Trim() != ""
                && txtDireccion.Text.Trim() != "" && txtRuc.Text.Trim() != "" && dtpFechaNacimiento.Value != DateTime.Today)
            {
                oCliente.Idcliente = lblIdCliente.Text.ToString();
                oCliente.Nombre = txtNombre.Text.ToString();
                oCliente.Dni = txtDNI.Text.ToString();
                oCliente.Email = txtEmail.Text.ToString();
                oCliente.Direccion = txtDireccion.Text.ToString();
                oCliente.Foto = oUtilitarios.Image2Bytes(pcbImagen.Image);
                oCliente.Fechanacimiento = dtpFechaNacimiento.Value;
                oCliente.Ruc = txtRuc.Text.ToString();
                oCliente.modificar();
                timerCliente.Enabled = true;
                tiempo = 500;
                dgvCliente.DataSource = oCliente.listar();
                limpiar();
                activar_insertar();
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
