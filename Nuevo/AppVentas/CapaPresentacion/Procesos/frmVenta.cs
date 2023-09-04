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
    public partial class frmVenta : Form
    {
        private CVenta oVenta;
        public DataGridView dgvProductoVenta;
        private DataTable productos;
        public frmVenta()
        {
            InitializeComponent();
            dgvVenta.AllowUserToAddRows = false;

        }
        CUsuario oUsuario = new CUsuario();
        CCliente oCliente = new CCliente();




        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            string dni = txtDNI.Text;
            string idcliente = "", nombre = "", email = "", direccion = "", tipoComprobante = "";

            // Verificar si es un cliente por DNI
            if (oCliente.esClienteDNI(dni, ref idcliente, ref nombre, ref email, ref direccion))
            {
                tipoComprobante = "Boleta"; // Tipo de comprobante para DNI
                lblIdProvedor.Text = idcliente;
                lblNombre.Text = nombre;
                lblEmail.Text = email;
                lblDireccion.Text = direccion;
            }

            lblTipoComprobante.Text = tipoComprobante;
        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            string ruc = txtRuc.Text;
            string idcliente = "", nombre = "", email = "", direccion = "", tipoComprobante = "";

            // Verificar si es un cliente por RUC
            if (oCliente.esClienteRUC(ruc, ref idcliente, ref nombre, ref email, ref direccion))
            {
                tipoComprobante = "Factura"; // Tipo de comprobante para RUC
                lblIdProvedor.Text = idcliente;
                lblNombre.Text = nombre;
                lblEmail.Text = email;
                lblDireccion.Text = direccion;
            }

            lblTipoComprobante.Text = tipoComprobante;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            oVenta = new CVenta();

            string nuevoCodigo = oVenta.GenerarCodigoComprobante();
            lblIdComprobante.Text = nuevoCodigo;
            string nuevonumero = oVenta.GenerarNroComprobanteC();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string tipoComprobante = lblTipoComprobante.Text;
            DateTime fechaEmision = DateTime.Now;

            decimal monto = totalDecimal;
            string montoLetras = ""; // Debes tener un label correspondiente
            bool estado = false; // Puedes ajustar esto según sea necesario
            string idEmpleado = lblIdEmpleado.Text;
            string idCliente = lblIdProvedor.Text;
            string tipoproceso = "venta";
            object idproveedor = DBNull.Value;
            // Llamar a la función InsertarComprobante con los valores recolectados
            string idComprobante = lblIdComprobante.Text;
            oVenta.InsertarComprobante(idComprobante,tipoComprobante, fechaEmision, monto, montoLetras, estado, tipoproceso, idEmpleado, idCliente, idproveedor);

            if (!string.IsNullOrEmpty(idComprobante))
            {
                MessageBox.Show("Comprobante insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ahora insertar los detalles de la venta
                foreach (DataGridViewRow fila in dgvVenta.Rows)
                {
                    string idProducto = fila.Cells["IdProducto"].Value.ToString();
                    int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    decimal precioUnitario = Convert.ToDecimal(fila.Cells["PrecioUnitario"].Value);

                    // Insertar detalle del comprobante
                    oVenta.InsertarDetalleComprobante(idComprobante, idProducto, cantidad, precioUnitario);
                }

                // Limpiar el DataGridView de detalles de venta
                dgvVenta.Rows.Clear();
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
            // Agregar los datos del producto al DataGridView de frmVenta
            // Por ejemplo:
            dgvVenta.Rows.Add(e.IdProducto, e.PrecioUnitario, e.Cantidad);
        }

        private void frmVenta_Load_1(object sender, EventArgs e)
        {
            // Configurar las columnas del DataGridView dgvVenta
            dgvVenta.AutoGenerateColumns = false;

            // Agregar las columnas necesarias
            dgvVenta.Columns.Add("IdProducto", "ID Producto");
            dgvVenta.Columns.Add("PrecioUnitario", "Precio Unitario");
            dgvVenta.Columns.Add("Cantidad", "Cantidad");  // Cambiar el orden según tus necesidades


            // Actualizar el total
            RecalcularTotal();

            productos = new DataTable();
        }




        private decimal totalDecimal = 0;

        private void RecalcularTotal()
        {
            decimal subtotal = 0;

            if (dgvVenta.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvVenta.Rows)
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



        private void dgvVenta_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            RecalcularTotal();
        }

        private void dgvVenta_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            RecalcularTotal();
        }
    }
}
