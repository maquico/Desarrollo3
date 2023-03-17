using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Lab06Web
{
    /// <summary>
    /// Descripción breve de servicio_lab6
    /// </summary>
    [WebService(Namespace = "http://intec.edu.do/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    
    public class servicio_lab6 : System.Web.Services.WebService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]

        public Respuesta RegistrarVerdugoIndicio(Verdugo verdugo, Indicios indicio)
        {
            SqlConnection conexion = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Angel\\source\\repos\\Desarrollo3\\Lab06Web\\App_Data\\db_lab06.mdf;Integrated Security=True");
            conexion.Open();
            SqlCommand comando = new SqlCommand($"SP_InsertVerdugo", conexion);
            SqlTransaction transaction = null;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            Respuesta respuesta = new Respuesta();
            
            try
            {
                transaction = conexion.BeginTransaction();
                comando.Transaction = transaction;
                comando.Parameters.AddWithValue("@TipoDocumento", verdugo.TipoDocumento);
                comando.Parameters.AddWithValue("@Documento", verdugo.Documento);
                comando.Parameters.AddWithValue("@Nombres", verdugo.Nombres);
                comando.Parameters.AddWithValue("@Apellidos", verdugo.Apellidos);
                comando.Parameters.AddWithValue("@FechaNacimiento", verdugo.FechaNacimiento);
                comando.Parameters.AddWithValue("@FechaEvento", verdugo.FechaEvento);
                comando.Parameters.AddWithValue("@CantidadHijos", verdugo.CantidadHijos);
                comando.Parameters.AddWithValue("@Vivo", verdugo.Vivo);
                comando.Parameters.AddWithValue("@Preso", verdugo.Preso);
                comando.ExecuteNonQuery();

                comando.Parameters.Clear();
                comando.CommandText = "SP_InsertIndicios";
                comando.Parameters.AddWithValue("@TipoDocumento", indicio.TipoDocumento);
                comando.Parameters.AddWithValue("@Documento", indicio.Documento);
                comando.Parameters.AddWithValue("@Descripcion", indicio.Descripcion);
                comando.ExecuteNonQuery();
                transaction.Commit();
                respuesta.Mensaje = "Se completo la transaccion en el web service\n";
                log.Info("log en web service exitoso");
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.Mensaje = "Error en transaccion en el web service\n";
                log.Error("error en log web service");
                throw;
            }
            return respuesta;
        }
    }
}
