using System;
using System.Data;
using CapaDatos;

namespace CapaLogica
{
    public class CReportes
    {
        cDatos oDatos = new cDatosSQL();

        public DataTable ObtenerVentasPorEmpleadoYFecha(string idEmpleado, DateTime fecha)
        {
            // Llamada al procedimiento almacenado que obtiene las ventas por empleado y fecha
            return oDatos.TraerDataTable("uspObtenerVentasPorEmpleadoYFecha", idEmpleado, fecha);
        }

    }
}
