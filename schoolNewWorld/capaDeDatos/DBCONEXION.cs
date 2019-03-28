using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace capaDeDatos
{
    class DBCONEXION
    {
        //Se hace conexion a la base de datos
        private SqlConnection Conexion = new SqlConnection("Server=LAPTOP-6V89SG2F;DataBase=DBLOGIN;Integrated Security=true");

        //Metodo para abrir la conexion de que si el estado de la base de datos esta cerrada que se abra
        public SqlConnection AbrirConnexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;

        }
        //Si la conexion de la base de datos su estado es abierto que se cierre atravez de este metodo
        public SqlConnection CerrarConnexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;

        }
    }
}
