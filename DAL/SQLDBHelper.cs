using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SQLDBHelper
    {
        DataTable Tabla;
        SqlConnection strConexion = new SqlConnection("Data source=LAPTOP-T2I8CH00; Initial Catalog=BDUbicaciones; Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public bool EjecutarComandoSQL(SqlCommand strSQLCommand)
        {
            //Insertar, Modificar, Borrar
            bool Respuesta = true;

            cmd = strSQLCommand;
            cmd.Connection = strConexion;
            strConexion.Open();
            Respuesta = (cmd.ExecuteNonQuery() <= 0) ? false : true;
            strConexion.Close();
            return Respuesta;
        }

        public DataTable EjecutarSetenciaSQL(SqlCommand strSQLCommand)
        {
            //Seleccionar datos de la Bd

            cmd = strSQLCommand;
            cmd.Connection=strConexion;
            strConexion.Open();
            Tabla=new DataTable();
            Tabla.Load(cmd.ExecuteReader());
            strConexion.Close();
            return Tabla;
        }
    }
}