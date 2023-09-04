using CapaDatos;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CEmpleado
    {
        //Atributos
        string idempleado;
        string nombre;
        string dni;
        string email;
        string direccion;
        string telefono;
        string cargo;
        byte[] foto;
        DateTime fechanacimiento;

        // Metodos get y set
        public string Idempleado { get => idempleado; set => idempleado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Email { get => email; set => email = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public byte[] Foto { get => foto; set => foto = value; }
        public DateTime Fechanacimiento { get => fechanacimiento; set => fechanacimiento = value; }

        // Datos y mensajes
        cDatos oDatos = new cDatosSQL();
        public string Mensaje;
        public bool insertar()
        {
            DataRow oFila = oDatos.TraerDataRow("uspInsertarEmpleado", idempleado, nombre, dni, email, direccion, telefono, cargo, foto, fechanacimiento);
            Mensaje = oFila["mensaje"].ToString();
            byte coderror = Convert.ToByte(oFila["codError"]);
            return coderror == 1;
        }
        public bool modificar()
        {
            DataRow oFila = oDatos.TraerDataRow("uspActualizarEmpleado", idempleado, nombre, dni, email, direccion, telefono, cargo, foto, fechanacimiento);
            Mensaje = oFila["mensaje"].ToString();
            byte coderror = Convert.ToByte(oFila["coderror"]);
            return coderror == 1;
        }
        public bool eliminar()
        {
            DataRow oFila = oDatos.TraerDataRow("uspEliminarEmpleado", idempleado);
            Mensaje = oFila["mensaje"].ToString();
            byte coderror = Convert.ToByte(oFila["coderror"]);
            return coderror == 1;
        }
        public DataTable listar()
        {
            return oDatos.TraerDataTable("uspListarEmpleado");
        }
        public DataTable buscar(string campo, string contenido)
        {
            return oDatos.TraerDataTable("uspBuscarEmpleado", campo, contenido);
        }
        public string generarcodigo()
        {
            DataRow oFila = oDatos.TraerDataRow("uspGenerarCodigoEmpleado");
            return oFila["codigo"].ToString();
        }
        public byte[] imagen(string idempleado)
        {
            DataRow oFila = oDatos.TraerDataRow("uspImagenEmpleado", idempleado);
            return (byte[])oFila["imagen"];
        }
    }
}
