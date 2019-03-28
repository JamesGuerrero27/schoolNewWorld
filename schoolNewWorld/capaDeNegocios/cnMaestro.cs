using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using capaDeDatos;

namespace capaDeNegocios
{
    public class cnMaestro
    {
        private CDusuarios users = new CDusuarios();
        private string _Usuario;
        private string _Contraseña;

        public string Usuario
        {
            set
            {
                if (value == "Usuario")
                {
                    _Usuario = "No ha ingresado usuario correctamente";

                }
                else { _Usuario = value; }


            }
            get { return _Usuario; }
        }
        public String Contraseña
        {
            set
            {
                if (value == "Contraseña")

                {
                    _Contraseña = "No se ha ingresado contraseña correctamente";

                }
                else { _Contraseña = value; }
            }
            get { return _Contraseña; }
        }

        public cnMaestro()
        { }
        public SqlDataReader IniciarSesion()
        {
            SqlDataReader Loguear;
            Loguear = users.iniciarSesion(Usuario, Contraseña);
            return Loguear;
        }
        public string recuPass (string user)
        {
            string mensaje;
            mensaje = users.RecuperarContraseña(user);
            return mensaje; 
        }
    }
}
