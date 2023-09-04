using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using CapaPresentacion.Consultas;

namespace CapaPresentacion.Procesos
{
    public partial class frmCompras : Form
    {
        private CCompra oCompra;
        public DataGridView dgvProductoVenta;
        private DataTable productos;
        public frmCompras()
        {
            InitializeComponent();
            dgvCompra.AllowUserToAddRows = false;

        }
        cProveedor oUsuario = new cProveedor();
        cProveedor oCliente = new cProveedor();


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            oCompra = new CCompra();

            string nuevoCodigo = oCompra.GenerarCodigoComprobanteC();
            lblIdComprobante.Text = nuevoCodigo;
            string nuevonumero = oCompra.GenerarNroComprobanteC();
            lblNroComprobante.Text = nuevonumero;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string tipoComprobante = lblTipoComprobante.Text;
            string nroComprobante = lblNroComprobante.Text;
            DateTime fechaEmision = DateTime.Now;

            decimal monto = totalDecimal;
            string montoLetras = "";
            bool estado = false; 
            string idEmpleado = lblIdEmpleado.Text;
            string idProveedor = lblIdProvedorC.Text; 
            string tipoproceso = "compra";
            object idcliente = DBNull.Value;
            string idComprobante = lblIdComprobante.Text;
            oCompra.InsertarComprobanteC(idComprobante, tipoComprobante, nroComprobante, fechaEmision, monto, montoLetras, estado, tipoproceso, idEmpleado, idcliente, idProveedor);

            if (!string.IsNullOrEmpty(idComprobante))
            {
                MessageBox.Show("Comprobante insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ahora insertar los detalles de la compra
                foreach (DataGridViewRow fila in dgvCompra.Rows)
                {
                    string idProducto = fila.Cells["IdProducto"].Value.ToString();
                    int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    decimal precioUnitario = Convert.ToDecimal(fila.Cells["PrecioUnitario"].Value);

                    // Insertar detalle del comprobante
                    oCompra.InsertarDetalleComprobanteC(idComprobante, idProducto, cantidad, precioUnitario);
                }

                // Limpiar el DataGridView de detalles de compra
                dgvCompra.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Error al insertar el comprobante.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmBuscarProducto buscarProductoForm = new frmBuscarProducto();
            buscarProductoForm.ProductoAgregado += BuscarProductoForm_ProductoAgregado;
            buscarProductoForm.ShowDialog();
        }
        private void BuscarProductoForm_ProductoAgregado(object sender, frmBuscarProducto.ProductoAgregadoEventArgs e)
        {

            dgvCompra.Rows.Add(e.IdProducto, e.PrecioUnitario, e.Cantidad);
        }



        private decimal totalDecimal = 0;

        private void RecalcularTotal()
        {
            decimal subtotal = 0;

            if (dgvCompra.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvCompra.Rows)
                {
                    if (row.Cells["PrecioUnitario"].Value != null && row.Cells["Cantidad"].Value != null)
                    {
                        decimal precioUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value);
                        int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                        decimal subtotalProducto = precioUnitario * cantidad;
                        subtotal += subtotalProducto;
                    }
                }
            }

            decimal igv = subtotal * 0.16M; // Calcular el 16% de IGV
            totalDecimal = subtotal + igv;

            lblSubTotal.Text = subtotal.ToString("C"); // Formatear como moneda
            lblIGV.Text = igv.ToString("C"); // Formatear como moneda
            lblTotal.Text = totalDecimal.ToString("C"); // Formatear y mostrar el total como moneda
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            string ruc = txtRuc.Text;
            string idproveedor = "", nombre = "", email = "", direccion = "", tipoComprobante = "";


            if (oCliente.esProveedorRUC(ruc, ref idproveedor, ref nombre, ref email, ref direccion))
            {
                tipoComprobante = "Factura"; // Tipo de comprobante para RUC
                lblIdProvedorC.Text = idproveedor;
                lblrazonSocial.Text = nombre;
                lblEmail.Text = email;
                lblDireccion.Text = direccion;
            }

            lblTipoComprobante.Text = tipoComprobante;
        }

        private void dgvCompra_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            RecalcularTotal();
        }

        private void dgvCompra_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            RecalcularTotal();
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            // Configurar las columnas del DataGridView dgvVenta
            dgvCompra.AutoGenerateColumns = false;

            // Agregar las columnas necesarias
            dgvCompra.Columns.Add("IdProducto", "ID Producto");
            dgvCompra.Columns.Add("PrecioUnitario", "Precio Unitario");
            dgvCompra.Columns.Add("Cantidad", "Cantidad");  // Cambiar el orden según tus necesidades


            // Actualizar el total
            RecalcularTotal();

            productos = new DataTable();
        }
    }
}
