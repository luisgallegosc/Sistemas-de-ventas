using CapaDatos;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CProducto
    {
        string idproducto;
        string denominacion;
        int cantidad;
        float preciounitario;
        int stockinicial;
        int stockactual;

        public string Idproducto { get => idproducto; set => idproducto = value; }
        public string Denominacion { get => denominacion; set => denominacion = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public float Preciounitario { get => preciounitario; set => preciounitario = value; }
        public int Stockinicial { get => stockinicial; set => stockinicial = value; }
        public int Stockactual { get => stockactual; set => stockactual = value; }
        // Datos y mensajes
        cDatos oDatos = new cDatosSQL();
        public string Mensaje;

        public bool insertar()
        {
            DataRow oFila = oDatos.TraerDataRow("uspInsertarProducto", idproducto, denominacion, cantidad, preciounitario, stockinicial, stockactual);
            Mensaje = oFila["mensaje"].ToString();
            byte coderror = Convert.ToByte(oFila["codError"]);
            return coderror == 1;
        }
        public bool modificar()
        {
            DataRow oFila = oDatos.TraerDataRow("uspActualizarProducto", idproducto, denominacion, cantidad, preciounitario, stockinicial, stockactual);
            Mensaje = oFila["mensaje"].ToString();
            byte coderror = Convert.ToByte(oFila["codError"]);
            return coderror == 1;
        }
        public bool eliminar()
        {
            DataRow oFila = oDatos.TraerDataRow("uspEliminarProducto", idproducto);
            Mensaje = oFila["mensaje"].ToString();
            byte coderror = Convert.ToByte(oFila["coderror"]);
            return coderror == 1;
        }
        public DataTable listar()
        {
            return oDatos.TraerDataTable("uspListarProducto");
        }
        public DataTable buscar(string campo, string contenido)
        {
            return oDatos.TraerDataTable("uspBuscarProducto", campo, contenido);
        }
        public string generarcodigo()
        {
            DataRow oFila = oDatos.TraerDataRow("uspGenerarCodigoProducto");
            return oFila["codigo"].ToString();
        }
        public DataTable MostrarKardex(string idProducto)
        {
            return oDatos.TraerDataTable("uspKardexProducto", idProducto);
        }
    }
}
    