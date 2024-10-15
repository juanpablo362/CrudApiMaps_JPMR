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

        // Eliminar un registro
        public bool Eliminar(UbicacionesBLL OubicacionesBLL) 
        {
            SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "DELETE FROM Direcciones WHERE ID = @ID";
            cmdComando.Parameters.Add("@ID", SqlDbType.Int).Value = OubicacionesBLL.ID;

            return oConexion.EjecutarComandoSQL(cmdComando);
        }

        public bool  Modificar(UbicacionesBLL oUbicacionesBLL) 
        {
            SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "UPDATE Direcciones SET Ubicacion = @Ubicacion, Latitud = @Latitud, Longitud = @Longitud WHERE ID = @ID";
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = oUbicacionesBLL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = oUbicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = oUbicacionesBLL.Longitud;

            cmdComando.Parameters.Add("@ID", SqlDbType.Int).Value = oUbicacionesBLL.ID;
            return oConexion.EjecutarComandoSQL(cmdComando);

        }
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

        public bool Limpiar()
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "Delete from Direcciones";
            cmdComando.CommandType=CommandType.Text;

            return oConexion.EjecutarComandoSQL(cmdComando);
        }
    }
}
