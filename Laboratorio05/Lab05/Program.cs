using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
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
                SqlCommand comando = new SqlCommand($"SP_UpsertGuerra", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = null;
                SqlTransaction transaction = null;
                Console.WriteLine($"--- ESTADO CONEXION: {conexion.State} ---\n\n");

                //INSTANCIAS DE CLASES

                Guerra guerra = new Guerra();
                Evento evento = new Evento();

                Console.WriteLine($"\n\n--- DATOS GUERRA ---\n\n");
                Console.WriteLine("Codigo Guerra: ");
                guerra.codigoGuerra = int.Parse(Console.ReadLine());
                Console.WriteLine("Pais 1: ");
                guerra.pais1 = Console.ReadLine();
                Console.WriteLine("Pais 2: ");
                guerra.pais2 = Console.ReadLine();
                Console.WriteLine("Fecha inicio: ");
                string fechaInicio = Console.ReadLine();
                guerra.fechaInicio = DateTime.Parse(fechaInicio);
                Console.WriteLine("Fecha fin: ");
                string fechaFin = Console.ReadLine();
                guerra.fechaFin = DateTime.Parse(fechaFin);
                Console.WriteLine("Pais ganador: ");
                guerra.paisGanador = Console.ReadLine();
                Console.WriteLine("Cantidad muertos: ");
                guerra.cantidadMuertos = int.Parse(Console.ReadLine());
                Console.WriteLine("Cantidad presos: ");
                guerra.cantidadPresos = int.Parse(Console.ReadLine());
                Console.WriteLine("Perdida Financiera: ");
                guerra.perdidaFinanciera = int.Parse(Console.ReadLine());
                Console.WriteLine("Estado: ");
                guerra.estadoGuerra = int.Parse(Console.ReadLine());
                Console.WriteLine("Heridos:  ");
                guerra.heridos= int.Parse(Console.ReadLine());


                Console.WriteLine($"\n\n--- DATOS EVENTO ---\n\n");
                evento.codigoGuerra = guerra.codigoGuerra;
                Console.WriteLine("Tipo evento: ");
                evento.tipoEvento = int.Parse(Console.ReadLine());
                Console.WriteLine("Descripcion: ");
                evento.descripcion = Console.ReadLine();
                Console.WriteLine("Fecha evento ");
                string fechaEvento = Console.ReadLine();
                evento.fechaEvento = DateTime.Parse(fechaEvento);
                Console.WriteLine("Cantidad de muertos:  ");
                evento.cantidadMuertos = int.Parse(Console.ReadLine());
                Console.WriteLine("Heridos:  ");
                evento.cantidadHeridos = int.Parse(Console.ReadLine());

                try
                {
                    transaction = conexion.BeginTransaction();
                    comando.Transaction = transaction;
                    comando.Parameters.AddWithValue("@CodigoGuerra", guerra.codigoGuerra);
                    comando.Parameters.AddWithValue("@Pais1", guerra.pais1);
                    comando.Parameters.AddWithValue("@Pais2", guerra.pais2);
                    comando.Parameters.AddWithValue("@FechaInicio", guerra.fechaInicio);
                    comando.Parameters.AddWithValue("@FechaFin", guerra.fechaFin);
                    comando.Parameters.AddWithValue("@PaisGanador", guerra.paisGanador);
                    comando.Parameters.AddWithValue("@CantidadMuertos", guerra.cantidadMuertos);
                    comando.Parameters.AddWithValue("@CantidadPresos", guerra.cantidadPresos);
                    comando.Parameters.AddWithValue("@PerdidaFinanciera", guerra.perdidaFinanciera);
                    comando.Parameters.AddWithValue("@EstadoGuerra", guerra.estadoGuerra);
                    comando.Parameters.AddWithValue("@Heridos", guerra.heridos);
                    comando.Parameters.AddWithValue("@MuertosEvento", evento.cantidadMuertos);
                    comando.Parameters.AddWithValue("@HeridosEvento", evento.cantidadHeridos);
                    comando.ExecuteNonQuery();

                    comando.Parameters.Clear();
                    comando.CommandText = "SP_InsertEvento";
                    comando.Parameters.AddWithValue("@CodigoGuerra", evento.codigoGuerra);
                    comando.Parameters.AddWithValue("@TipoEvento", evento.tipoEvento);
                    comando.Parameters.AddWithValue("@Descripcion", evento.descripcion);
                    comando.Parameters.AddWithValue("@FechaEvento", evento.fechaEvento);
                    comando.Parameters.AddWithValue("@CantidadMuertos", evento.cantidadMuertos);
                    comando.Parameters.AddWithValue("@CantidadHeridos", evento.cantidadHeridos);
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
