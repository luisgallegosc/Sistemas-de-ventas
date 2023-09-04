using CapaDatos;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class cProveedor
    {
        // Atributos
        string IdProveedor;
        string razonSocial;
        string RUC;
        string direccion;
        string telefono;
        string email;
        DateTime fechaInscripcion;
        bool estado;

        public string idProveedor { get => IdProveedor; set => IdProveedor = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public string Ruc { get => RUC; set => RUC = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public DateTime FechaInscripcion { get => fechaInscripcion; set => fechaInscripcion = value; }
        public bool Estado { get => estado; set => estado = value; }

        // Datos y mensajes
        cDatos oDatos = new cDatosSQL();
        public string Mensaje;

        public bool Insertar()
        {
            DataRow oFila = oDatos.TraerDataRow("uspInsertarProveedor", IdProveedor, razonSocial, RUC, direccion, telefono, email, fechaInscripcion, estado);
            Mensaje = oFila["mensaje"].ToString();
            byte coderror = Convert.ToByte(oFila["codError"]);
            return coderror == 1;
        }

        public bool Modificar()
        {
            DataRow oFila = oDatos.TraerDataRow("uspActualizarProveedor", IdProveedor, razonSocial, RUC, direccion, telefono, email, fechaInscripcion, estado);
            Mensaje = oFila["mensaje"].ToString();
            byte coderror = Convert.ToByte(oFila["codError"]);
            return coderror == 1;
        }

        public bool Eliminar()
        {
            DataRow oFila = oDatos.TraerDataRow("uspEliminarProveedor", IdProveedor);
            Mensaje = oFila["mensaje"].ToString();
            byte coderror = Convert.ToByte(oFila["coderror"]);
            return coderror == 1;
        }

        public DataTable Listar()
        {
            return oDatos.TraerDataTable("uspListarProveedor");
        }

        public DataTable Buscar(string campo, string contenido)
        {
            return oDatos.TraerDataTable("uspBuscarProveedor", campo, contenido);
        }

        public string Generarcodigo()
        {
            DataRow oFila = oDatos.TraerDataRow("uspGenerarCodigoProveedor");
            return oFila["codigo"].ToString();
        }
        public bool esProveedorRUC(string ruc, ref string idproveedor, ref string razonSocial, ref string email, ref string direccion)
        {
            DataRow oFila = oDatos.TraerDataRow("uspBuscarRUCProveedor", ruc);
            idproveedor = oFila["idproveedor"].ToString();
            razonSocial = oFila["razonSocial"].ToString();
            email = oFila["email"].ToString();
            direccion = oFila["direccion"].ToString();
            byte coderror = Convert.ToByte(oFila["coderror"]);
            return coderror == 1;
        }

    }
}
