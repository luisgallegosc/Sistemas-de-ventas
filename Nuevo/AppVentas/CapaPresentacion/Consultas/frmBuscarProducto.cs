using CapaLogica;
using CapaPresentacion.Procesos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Consultas
{
    public partial class frmBuscarProducto : Form
    {
        CProducto oProducto = new CProducto();

        public frmBuscarProducto()
        {
            InitializeComponent();

        }
        private void frmBuscarProducto_Load(object sender, EventArgs e)
        {
            // Cargar y mostrar la lista de productos en el DataGridView
            dgvProductos.DataSource = oProducto.listar();
        }
        public event EventHandler<ProductoAgregadoEventArgs> ProductoAgregado;


        public class ProductoAgregadoEventArgs : EventArgs
        {
            public string IdProducto { get; }
            public float PrecioUnitario { get; }
            public int Cantidad { get; }

            public ProductoAgregadoEventArgs(string idProducto, float precioUnitario, int cantidad)
            {
                IdProducto = idProducto;
                PrecioUnitario = precioUnitario;
                Cantidad = cantidad;
            }
        }
        protected virtual void OnProductoAgregado(string idProducto, float precioUnitario, int cantidad)
        {
            ProductoAgregado?.Invoke(this, new ProductoAgregadoEventArgs(idProducto, precioUnitario, cantidad));
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                string idProducto = dgvProductos.SelectedRows[0].Cells["IdProducto"].Value.ToString();
                float precioUnitario = float.Parse(dgvProductos.SelectedRows[0].Cells["PrecioUnitario"].Value.ToString());
                int cantidad = (int)nudCantidad.Value;

                OnProductoAgregado(idProducto, precioUnitario, cantidad);

                MessageBox.Show("Producto agregado correctamente.");
            }
            else
            {
                MessageBox.Show("Selecciona un producto de la lista.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string campo = cmbCampo.Text;
            string contenido = txtContenido.Text;

            if (!string.IsNullOrEmpty(campo) && !string.IsNullOrEmpty(contenido))
            {
                BuscarProductos(campo, contenido);
            }
            else
            {
                MessageBox.Show("Faltan datos para la búsqueda.");
            }
        }
        private void BuscarProductos(string campo, string contenido)
        {
            dgvProductos.DataSource = oProducto.buscar(campo, contenido);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
