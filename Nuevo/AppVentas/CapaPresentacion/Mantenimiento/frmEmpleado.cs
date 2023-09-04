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
    public partial class frmEmpleado : Form
    {
        public void limpiar()
        {
            cmbCargo.SelectedIndex = -1;
            cmbCampo.SelectedIndex = -1;
            txtContenido.Text = "";
            txtDireccion.Text = "";
            txtDNI.Text = "";
            txtEmail.Text = "";
            lblIdEmpleado.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
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
        public frmEmpleado()
        {
            InitializeComponent();
        }
        CEmpleado oEmpleado = new CEmpleado();
        cUtilitarios oUtilitarios = new cUtilitarios();
        int tiempo = 500;
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            lblIdEmpleado.Text = oEmpleado.generarcodigo();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (lblIdEmpleado.Text.Trim() != "" && txtNombre.Text.Trim() != "" && txtDNI.Text.Trim() != "" && txtEmail.Text.Trim() != ""
                && txtDireccion.Text.Trim() != "" && txtTelefono.Text.Trim() != "" && cmbCargo.Text != "" && dtpFechaNacimiento.Value != DateTime.Today)
            {
                oEmpleado.Idempleado = lblIdEmpleado.Text.ToString();
                oEmpleado.Nombre = txtNombre.Text.ToString();
                oEmpleado.Dni = txtDNI.Text.ToString();
                oEmpleado.Email = txtEmail.Text.ToString();
                oEmpleado.Direccion = txtDireccion.Text.ToString();
                oEmpleado.Telefono = txtTelefono.Text.ToString();
                oEmpleado.Cargo = cmbCargo.Text.ToString();
                oEmpleado.Foto = oUtilitarios.Image2Bytes(pcbImagen.Image);
                oEmpleado.Fechanacimiento = dtpFechaNacimiento.Value;
                oEmpleado.insertar();
                timerEmpleado.Enabled = true;

                tiempo = 500;
                dgvEmpleado.DataSource = oEmpleado.listar();
                limpiar();
            }
            else
                MessageBox.Show("Falta completar datos");
            
        }

        private void timerEmpleado_Tick(object sender, EventArgs e)
        {
            tiempo--;
            
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivo de imagen|*.jpg;*.jpeg;*.png;*.gif";
                openFileDialog.Title = "Seleccionar una imagen";
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string rutaImagen = openFileDialog.FileName;
                        pcbImagen.Image = Image.FromFile(rutaImagen);
                    }
                    catch(Exception ex)
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
                dgvEmpleado.DataSource = oEmpleado.buscar(campo, contenido);
            else
                MessageBox.Show("Faltan datos");
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (1 < dgvEmpleado.Rows.Count)
            {
                int r = dgvEmpleado.CurrentRow.Index;
                if (0 <= r && r < dgvEmpleado.RowCount - 1)
                {
                    oEmpleado.Idempleado = dgvEmpleado.Rows[r].Cells[0].Value.ToString();
                    oEmpleado.eliminar();
                    limpiar();
                    dgvEmpleado.DataSource = oEmpleado.listar();
                }
                else
                    MessageBox.Show("Error: Selecciona la fila que desee eliminar");
            }
            else
                MessageBox.Show("Error: No hay empleados");
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvEmpleado.DataSource = oEmpleado.listar();
        }

        private void dgvEmpleado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            activar_actualizar();
            int r = e.RowIndex;
            if(r < dgvEmpleado.RowCount - 1)
            {
                lblIdEmpleado.Text = dgvEmpleado.Rows[r].Cells[0].Value.ToString();
                txtNombre.Text = dgvEmpleado.Rows[r].Cells[1].Value.ToString();
                txtDNI.Text = dgvEmpleado.Rows[r].Cells[2].Value.ToString();
                txtEmail.Text = dgvEmpleado.Rows[r].Cells[3].Value.ToString();
                txtDireccion.Text = dgvEmpleado.Rows[r].Cells[4].Value.ToString();
                txtTelefono.Text = dgvEmpleado.Rows[r].Cells[5].Value.ToString();
                dtpFechaNacimiento.Value = DateTime.Parse(dgvEmpleado.Rows[r].Cells[7].Value.ToString());
                cmbCargo.Text = dgvEmpleado.Rows[r].Cells[6].Value.ToString();
                pcbImagen.Image = oUtilitarios.Bytes2Image(oEmpleado.imagen(lblIdEmpleado.Text));
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (lblIdEmpleado.Text.Trim() != "" && txtNombre.Text.Trim() != "" && txtDNI.Text.Trim() != "" && txtEmail.Text.Trim() != ""
                && txtDireccion.Text.Trim() != "" && txtTelefono.Text.Trim() != "" && cmbCargo.Text != "Seleccione" && dtpFechaNacimiento.Value != DateTime.Today)
            {
                oEmpleado.Idempleado = lblIdEmpleado.Text.ToString();
                oEmpleado.Nombre = txtNombre.Text.ToString();
                oEmpleado.Dni = txtDNI.Text.ToString();
                oEmpleado.Email = txtEmail.Text.ToString();
                oEmpleado.Direccion = txtDireccion.Text.ToString();
                oEmpleado.Telefono = txtTelefono.Text.ToString();
                oEmpleado.Cargo = cmbCargo.Text.ToString();
                oEmpleado.Foto = oUtilitarios.Image2Bytes(pcbImagen.Image);
                oEmpleado.Fechanacimiento = dtpFechaNacimiento.Value;
                oEmpleado.modificar();
                timerEmpleado.Enabled = true;

                tiempo = 500;
                dgvEmpleado.DataSource = oEmpleado.listar();
                limpiar();
                activar_insertar();
            }
        }
    }
}
