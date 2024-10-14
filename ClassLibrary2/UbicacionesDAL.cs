using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using BLL;
using System.Data.SqlTypes;
using System.Data.Sql;

namespace DAL
{
    public class UbicacionesDAL
    {
        SQLDBHelper oConexion;
        //Inicializar la conexion con la BD (Constructor)
        public UbicacionesDAL()
        {
            oConexion = new SQLDBHelper();
        }

        public bool Agregar(UbicacionesBLL OubicacionesBLL)
        {
            SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "INSERT INTO Direcciones (Ubicacion, Latitud, longitud) VALUES (@Ubicacion, @Latitud, @longitud)";
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = OubicacionesBLL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = OubicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = OubicacionesBLL.Longitud;

            return oConexion.EjecutarComandoSQL(cmdComando);
        }

        public void Eliminar() { }

        public void Modificar() { }
        //Señeccionar los registros de la tablla mediante un SELECT
        public DataTable Listar()
        {
            SqlCommand cmdComando = new SqlCommand();
            //Setencia SQL para traer todos los registros de la tabla "Direcciones"
            cmdComando.CommandText = "SELECT * FROM Direcciones";
            //Tipo de comando, ya sea texto, SP, etc.
            cmdComando.CommandType = CommandType.Text;

            DataTable TablaResultante = oConexion.EjecutarSetenciaSQL(cmdComando);

            return TablaResultante;
        }
    }
}
