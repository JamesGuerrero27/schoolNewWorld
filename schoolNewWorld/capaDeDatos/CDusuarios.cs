using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//Librerias que se importan para mandar emails
using System.Net;
using System.Net.Mail;

namespace capaDeDatos
{
    public class CDusuarios
    {
        //Instanciamos la conexion a al base de datos
        private DBCONEXION Conexion = new DBCONEXION();
        // DataReader es una amplia categoría de objetos utilizados para leer secuencialmente datos de una fuente de datos.
        private SqlDataReader leer;
        //Crearemos las variables que se usaran para igual datos de los nombre de las columnas de la DB
        private String Email, nombreCompleto, Contraseña, Usuario;
        private String Mensaje;
        private SqlCommand Comando = new SqlCommand();
        //Creamos el metodo recuperar Contraseña
        public String RecuperarContraseña(string user)
        {
            //Abrimos conexion a la base de datos
            Comando.Connection = Conexion.AbrirConnexion();
            //Hacemos la consulta de que si el usuario existe en la base de datos
            Comando.CommandText = "Select * from MAESTROS where [user]='" + user + "'";
            leer = Comando.ExecuteReader();
            if (leer.Read() == true)
            {
                Email = leer["Email"].ToString();
                nombreCompleto = leer["nombreCompleto"].ToString();
                Contraseña = leer["password"].ToString();
                EnviarEmail();
                Mensaje = "Estimado " + nombreCompleto + ", Se ha enviado su Contraseña a su correo: " + Email + " verifique su bandeja de entrada";
                leer.Close();

            }
            else
            {
                Mensaje = "No existen datos";
            }
            return Mensaje;
        }

        public void EnviarEmail()
        {
            //Correo
            MailMessage Correo = new MailMessage();
            Correo.From = new MailAddress("jamessteve.jg@gmail.com");
            Correo.To.Add(Email);
            Correo.Subject = ("Recuperar contraseña");
            Correo.Body = "Hola, " + nombreCompleto + " Usted solicito recuperar contraseña\n Su contraseña es: " + Contraseña + " etc...";
            Correo.Priority = MailPriority.Normal;
            //SMPT
            SmtpClient ServerMail = new SmtpClient();
            ServerMail.Credentials = new NetworkCredential("jamessteve.jg@gmail.com", "Jamessteve");
            ServerMail.Host = "smtp.gmail.com";
            ServerMail.Port = 587;
            ServerMail.EnableSsl = true;
            try
            {
                ServerMail.Send(Correo);

            }
            catch (Exception)
            {
                Correo.Dispose();

            }
        }

        public SqlDataReader iniciarSesion(string user, string pass)
        {
            //Creamos la procendencia que se hace desde la base de datos y abrimos conexion desde la base de datos
            SqlCommand comando = new SqlCommand("SPLOGIN", Conexion.AbrirConnexion());
            comando.Connection = Conexion.AbrirConnexion();
            //Lo que nos dice que estamos usando tipo procedencia
            comando.CommandType = CommandType.StoredProcedure;
            //Le mandamos los parametros que creamos de la procedencia en la base de datos
            comando.Parameters.AddWithValue("@Usuario", user);
            comando.Parameters.AddWithValue("@Contraseña", pass);
            //Aqui terminar los datos que usamos para la procedencia
            leer = comando.ExecuteReader();
            return leer;
        }
    }
}
