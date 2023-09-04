using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaLogica
{
    public class CVenta
    {
        // Datos y mensajes
        cDatos oDatos = new cDatosSQL();
        public string Mensaje;
        public string GenerarCodigoComprobante()
        {
            DataRow oFila = oDatos.TraerDataRow("uspGenerarCodigoComprobante");
            return oFila["codigo"].ToString();
        }
        public string GenerarNroComprobanteC()
        {
            DataRow oFila = oDatos.TraerDataRow("uspGenerarNumeroComprobante");
            return oFila["codigo"].ToString();
        }
        public string InsertarComprobante(string idcomprobante, string tipoComprobante, DateTime fechaEmision, decimal monto, string montoLetras, bool estado, string tipoproceso, string idEmpleado, string idCliente,object idproveedor)
        {
            DataRow oFila = oDatos.TraerDataRow("uspInsertarComprobante", idcomprobante, tipoComprobante, fechaEmision, monto, montoLetras, estado, tipoproceso, idEmpleado, idCliente,idproveedor);
            Mensaje = oFila["mensaje"].ToString();
            return oFila["IdComprobante"].ToString();
        }

        public void InsertarDetalleComprobante(string idComprobante, string idProducto, int cantidad, decimal precioUnitario)
        {
            oDatos.Ejecutar("uspInsertarDetalleComprobante", idComprobante, idProducto, cantidad, precioUnitario);
        }

    }
}
