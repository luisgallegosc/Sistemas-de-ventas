using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica; // Asegúrate de tener esta referencia

namespace CapaPresentacion.Procesos
{
    public partial class frmAnularVenta : Form
    {
        public frmAnularVenta()
        {
            InitializeComponent();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            string tipoComprobante = cmbTipoDocumento.Text; 
            string numeroComprobante = txtNro.Text; 
            string tipoOperacion = cmbTipo.Text;
            cAnular anulacion = new cAnular();
            anulacion.AnularComprobante(tipoComprobante,tipoOperacion, numeroComprobante);

            MessageBox.Show("Comprobante anulado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
