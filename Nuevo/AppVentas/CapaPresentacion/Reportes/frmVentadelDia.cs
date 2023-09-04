using System;
using System.Data;
using System.Windows.Forms;
using CapaLogica;

namespace CapaPresentacion.Reportes
{
    public partial class frmVentadelDia : Form
    {
        CReportes oReportes = new CReportes();

        public frmVentadelDia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el código del empleado y la fecha seleccionada
                string idEmpleado = txtEmpleado.Text;
                DateTime fechaSeleccionada = dateTimePicker.Value.Date;

                // Obtener las ventas del día para el empleado y la fecha seleccionada
                DataTable dtVentas = oReportes.ObtenerVentasPorEmpleadoYFecha(idEmpleado, fechaSeleccionada);

                // Mostrar los resultados en el DataGridView
                dgvVentas.DataSource = dtVentas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
