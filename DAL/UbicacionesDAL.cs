using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BLL;

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

        public void Agregar() { }

        public void Eliminar() { }

        public void Modificar() { }
        //Señeccionar los registros de la tablla mediante un SELECT
        public DataTable Listar() 
        {
            SqlCommand cmdComando = new SqlCommand();
            //Setencia SQL para traer todos los registros de la tabla "Direcciones"
            cmdComando.CommandText = "SELECT * FROM Direcciones";
            //Tipo de comando, ya sea texto, SP, etc.
            cmdComando.CommandType= CommandType.Text;

            DataTable TablaResultante = oConexion.EjecutarSetenciaSQL(cmdComando);

            return TablaResultante;
        }
    }
}
