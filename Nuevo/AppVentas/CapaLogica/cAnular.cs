using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class cAnular
    {
        cDatos oDatos = new cDatosSQL();
        public void AnularComprobante(string tipoComprobante, string tipoOperacion,string numeroComprobante)
        {
            oDatos.Ejecutar("uspAnularComprobante", tipoComprobante, tipoOperacion , numeroComprobante);
        }
    }
}
