using CapaDatos;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CUsuario
    {
        //Atributos
        string usuario;
        string contrasena;
        bool estado;
        string idempleado;

        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public bool Estado { get => estado; set => estado = value; }
        public string Idempleado { get => idempleado; set => idempleado = value; }

        cDatos oDatos = new cDatosSQL();
        public string Mensaje;
        public bool existeUsuario(string usuario, string contrasena)
        {
            DataRow oFila = oDatos.TraerDataRow("uspEsUsuario", usuario, contrasena);
            byte coderror = Convert.ToByte(oFila["coderror"]);
            return coderror == 1;
        }
        public string cargo(string usuario, string contrasena, string idempleado, string nombre)
        {
            DataRow oFila = oDatos.TraerDataRow("uspEsUsuario", usuario, contrasena);
            idempleado = oFila["idempleado"].ToString();
            nombre = oFila["nombre"].ToString();
            return oFila["cargo"].ToString();
        }
        public bool cambiarContrasena(string usuario, string nuevacontrasena)
        {
            DataRow oFila = oDatos.TraerDataRow("uspActualizarContrasenaUsuario", usuario, nuevacontrasena);
            byte coderror = Convert.ToByte(oFila["coderror"]);
            return coderror == 1;
        }
        public bool cambiarEstado(string usuario)
        {
            DataRow oFila = oDatos.TraerDataRow("uspCambiarEstadoUsuario", usuario);
            byte coderror = Convert.ToByte(oFila["coderror"]);
            return coderror == 1;
        }
        public DataTable listar()
        {
            return oDatos.TraerDataTable("uspListarUsuario");
        }
        public string idEmpleado(string usuario)
        {
            DataRow oFila = oDatos.TraerDataRow("uspIdempleadoUsuario", usuario);
            return oFila["idempleado"].ToString();
        }
        public string nombreEmpleado(string usuario)
        {
            DataRow oFila = oDatos.TraerDataRow("uspNombreempleadoUsuario", usuario);
            return oFila["nombre"].ToString();
        }
        public byte[] ObtenerImagenPorCorreo(string correo)
        {
            string idempleado = idEmpleado(correo); 
            if (!string.IsNullOrEmpty(idempleado))
            {
                return imagen(idempleado); 
            }
            return null;
        }

        public byte[] imagen(string idempleado)
        {
            DataRow oFila = oDatos.TraerDataRow("uspImagenEmpleado", idempleado);

            if (oFila["imagen"] != DBNull.Value)
            {
                return (byte[])oFila["imagen"];
            }
            else
            {
                return null;
            }
        }

    }
}
