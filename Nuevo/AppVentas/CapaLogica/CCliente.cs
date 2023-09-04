using CapaDatos;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CCliente
    {
        //Atributos
        string idcliente;
        string nombre;
        string tipocliente;
        string dni;
        string ruc;
        string email;
        string direccion;
        string telefono;
        byte[] foto;
        DateTime fechanacimiento;
        public string Idcliente { get => idcliente; set => idcliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Tipocliente { get => tipocliente; set => tipocliente = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Ruc { get => ruc; set => ruc = value; }
        public string Email { get => email; set => email = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public byte[] Foto { get => foto; set => foto = value; }
        public DateTime Fechanacimiento { get => fechanacimiento; set => fechanacimiento = value; }
        // Datos y mensajes
        cDatos oDatos = new cDatosSQL();
        public string Mensaje;

        public bool insertar()
        {
            DataRow oFila = oDatos.TraerDataRow("uspInsertarCliente", idcliente, nombre, "-", dni, ruc, email, direccion, foto, fechanacimiento);
            Mensaje = oFila["mensaje"].ToString();
            byte coderror = Convert.ToByte(oFila["codError"]);
            return coderror == 1;
        }
        public bool modificar()
        {
            DataRow oFila = oDatos.TraerDataRow("uspActualizarCliente", idcliente, nombre, "-", dni, ruc, email, direccion, foto, fechanacimiento);
            Mensaje = oFila["mensaje"].ToString();
            byte coderror = Convert.ToByte(oFila["codError"]);
            return coderror == 1;
        }
        public bool eliminar()
        {
            DataRow oFila = oDatos.TraerDataRow("uspEliminarCliente", idcliente);
            Mensaje = oFila["mensaje"].ToString();
            byte coderror = Convert.ToByte(oFila["coderror"]);
            return coderror == 1;
        }
        public DataTable listar()
        {
            return oDatos.TraerDataTable("uspListarCliente");
        }
        public DataTable buscar(string campo, string contenido)
        {
            return oDatos.TraerDataTable("uspBuscarCliente", campo, contenido);
        }
        public string generarcodigo()
        {
            DataRow oFila = oDatos.TraerDataRow("uspGenerarCodigoCliente");
            return oFila["codigo"].ToString();
        }
        public byte[] imagen(string idcliente)
        {
            DataRow oFila = oDatos.TraerDataRow("uspImagenCliente", idcliente);
            return (byte[])oFila["imagen"];
        }
        public bool esClienteDNI(string dni, ref string idcliente, ref string nombre, ref string email, ref string direccion)
        {
            DataRow oFila = oDatos.TraerDataRow("uspBuscarDNICliente", dni);
            idcliente = oFila["idcliente"].ToString();
            nombre = oFila["nombre"].ToString();
            email = oFila["email"].ToString();
            direccion = oFila["direccion"].ToString();
            byte coderror = Convert.ToByte(oFila["coderror"]);
            return coderror == 1;
        }
        public bool esClienteRUC(string ruc, ref string idcliente, ref string nombre, ref string email, ref string direccion)
        {
            DataRow oFila = oDatos.TraerDataRow("uspBuscarRUCCliente", ruc);
            idcliente = oFila["idcliente"].ToString();
            nombre = oFila["nombre"].ToString();
            email = oFila["email"].ToString();
            direccion = oFila["direccion"].ToString();
            byte coderror = Convert.ToByte(oFila["coderror"]);
            return coderror == 1;
        }
    }
}
