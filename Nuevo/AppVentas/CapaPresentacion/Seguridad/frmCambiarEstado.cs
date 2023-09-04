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
    public partial class frmCambiarEstado : Form
    {
        public frmCambiarEstado()
        {
            InitializeComponent();
            dgvUsuario.DataSource = oUsuario.listar();

        }
        CUsuario oUsuario = new CUsuario();
        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r < dgvUsuario.RowCount - 1)
            {
                string usuario = dgvUsuario.Rows[r].Cells[0].Value.ToString();
                oUsuario.cambiarEstado(usuario);
                dgvUsuario.DataSource = oUsuario.listar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
