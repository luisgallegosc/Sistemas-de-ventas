using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CCompra
    {
        // Datos y mensajes
        cDatos oDatos = new cDatosSQL();
        public string Mensaje;
        public string GenerarCodigoComprobanteC()
        {
            DataRow oFila = oDatos.TraerDataRow("uspGenerarCodigoComprobante");
            return oFila["codigo"].ToString();
        }
        public string GenerarNroComprobanteC()
        {
            DataRow oFila = oDatos.TraerDataRow("uspGenerarNumeroComprobante");
            return oFila["numero"].ToString();
        }

        public string InsertarComprobanteC(string idcomprobante, string tipoComprobante, string nroComprobante, DateTime fechaEmision, decimal monto, string montoLetras, bool estado, string tipoproceso, string idEmpleado, object idCliente, string idproveedor)
        {
            DataRow oFila = oDatos.TraerDataRow("uspInsertarComprobante", idcomprobante, tipoComprobante, nroComprobante, fechaEmision, monto, montoLetras, estado, tipoproceso, idEmpleado, idCliente, idproveedor);
            Mensaje = oFila["mensaje"].ToString();
            return oFila["IdComprobante"].ToString();
        }

        public void InsertarDetalleComprobanteC(string idComprobante, string idProducto, int cantidad, decimal precioUnitario)
        {
            oDatos.Ejecutar("uspInsertarDetalleComprobante", idComprobante, idProducto, cantidad, precioUnitario);
        }
    }
}
