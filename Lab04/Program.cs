using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Lab04
{
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            while (true)
            {
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand($"SP_UpsertFeligreses", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = null;
                SqlTransaction transaction = null;
                Console.WriteLine($"--- ESTADO CONEXION: {conexion.State} ---\n\n");

                //INSTANCIAS DE CLASES
                
                Feligreses feligres = new Feligreses();
                Evento evento = new Evento();

                Console.WriteLine($"\n\n--- DATOS FELIGRES ---\n\n");
                Console.WriteLine("Tipo Documento: ");
                feligres.tipodocumento = int.Parse(Console.ReadLine());
                Console.WriteLine("Documento: ");
                feligres.documento = Console.ReadLine();
                Console.WriteLine("Nombre: ");
                feligres.nombres = Console.ReadLine();
                Console.WriteLine("Apellidos: ");
                feligres.apellidos = Console.ReadLine();
                Console.WriteLine("Sexo: ");
                feligres.sexo = Console.ReadLine();
                Console.WriteLine("Fecha nacimiento: ");
                string fechaNac = Console.ReadLine();
                feligres.fechaNacimiento = DateTime.Parse(fechaNac);
                Console.WriteLine("Fecha ultima confesion: ");
                string fechaNac2 = Console.ReadLine();
                feligres.fechaUltimaConfesion = DateTime.Parse(fechaNac2);
                Console.WriteLine("Estado civil: ");
                feligres.estadoCivil = int.Parse(Console.ReadLine());
                Console.WriteLine("Diezma?: ");
                feligres.diezma = int.Parse(Console.ReadLine());
                Console.WriteLine("Pertenece a comunidad?: ");
                feligres.perteneceAcomunidad = int.Parse(Console.ReadLine());
                Console.WriteLine("Ultima visita?: ");
                string fechaNac3 = Console.ReadLine();
                feligres.ultimaVisitaIglesia = DateTime.Parse(fechaNac3);
                //Console.WriteLine("MORTALE?: ");
                //int mortales = int.Parse(Console.ReadLine());
                //Console.WriteLine("VENIALE?: ");
                //int veniale = int.Parse(Console.ReadLine());
                //Console.WriteLine("PENITENCIA?: ");
                //int penitencia = int.Parse(Console.ReadLine());
                //DATOS DEL MOVIMIENTO O TRANSACCION
                Console.WriteLine($"\n\n--- DATOS EVENTO ---\n\n");
                evento.TipoDocumento= feligres.tipodocumento;
                evento.Documento = feligres.documento;
                Console.WriteLine("tipo evento: ");
                evento.TipoEvento = int.Parse(Console.ReadLine());
                Console.WriteLine("nota: ");
                evento.Nota = Console.ReadLine();
                Console.WriteLine("decripcion: ");
                evento.Descripcion = Console.ReadLine();
                
                try
                {
                    transaction = conexion.BeginTransaction();
                    comando.Transaction = transaction;
                    comando.Parameters.AddWithValue("@nombre", feligres.nombres);
                    comando.Parameters.AddWithValue("@apellido", feligres.apellidos);
                    comando.Parameters.AddWithValue("@tipodocumento", feligres.tipodocumento);
                    comando.Parameters.AddWithValue("@documento", feligres.documento);
                    comando.Parameters.AddWithValue("@fechanacimiento", feligres.fechaNacimiento);
                    comando.Parameters.AddWithValue("@sexo", feligres.sexo);
                    comando.Parameters.AddWithValue("@estadocivil", feligres.estadoCivil);
                    comando.Parameters.AddWithValue("@fechaultimaconfesion", feligres.fechaUltimaConfesion);
                    comando.Parameters.AddWithValue("@diezma", feligres.diezma);
                    comando.Parameters.AddWithValue("@perteneceacomunidad", feligres.perteneceAcomunidad);
                    comando.Parameters.AddWithValue("@ultimavisitaiglesia", feligres.ultimaVisitaIglesia);
                    comando.Parameters.AddWithValue("@tipoevento", evento.TipoEvento);
                    //comando.Parameters.AddWithValue("@cantidadpecadosmortales", mortales);
                    //comando.Parameters.AddWithValue("@cantidadpecadosmveniales", veniale);
                    //comando.Parameters.AddWithValue("@penitencias", mortales);
                    comando.ExecuteNonQuery();

                    comando.Parameters.Clear();
                    comando.CommandText = "SP_InsertEvento";
                    comando.Parameters.AddWithValue("@tipodocumento", evento.TipoDocumento);
                    comando.Parameters.AddWithValue("@documento", evento.Documento);
                    comando.Parameters.AddWithValue("@tipoevento", evento.TipoEvento);
                    comando.Parameters.AddWithValue("@nota",evento.Nota);
                    comando.Parameters.AddWithValue("@descripcion", evento.Descripcion);
                    comando.ExecuteNonQuery();
          
                    transaction.Commit();
                    log.Info("se registro bien, jevi");
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    log.Error("error palomo");
                    throw;
                }
            }
        }
    }
}
