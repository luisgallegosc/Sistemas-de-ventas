using CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Reportes
{
    public partial class frmKardex : Form
    {
        private CProducto oProducto = new CProducto(); // Instancia de la clase CProducto

        public frmKardex()
        {
            InitializeComponent();
        }

        private void frmKardex_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(producto.Text)) // Verifica si el TextBox está vacío
            {
                MessageBox.Show("Ingrese el id");
            }
            else
            {
                string idProducto = producto.Text;
                DataTable dtKardex = oProducto.MostrarKardex(idProducto); // Usar la instancia oProducto
                dgv.DataSource = dtKardex;
            }
        }
    }
}
