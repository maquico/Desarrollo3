using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Lab03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)

            {
                //SQL (conexion, comando, reader y transaccion)
                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand($"SP_InsertarFallecido", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = null;
                SqlTransaction transaction = null;
                Console.WriteLine($"--- ESTADO CONEXION: {conexion.State} ---\n\n");

                //INSTANCIAS DE CLASES
                Fallecido fallecido = new Fallecido();
                Resumen resumen = new Resumen();

                //PIDO DATOS INICIALES DEL CLIENTE PARA VALIDAR SI EXISTE
                Console.WriteLine($"\n\n--- DATOS FALLECIDO ---\n\n");
                Console.WriteLine("Tipo Documento: ");
                fallecido.TipoDocumento = int.Parse(Console.ReadLine());
                Console.WriteLine("Documento: ");
                fallecido.Documento = Console.ReadLine();
                Console.WriteLine("Nombre: ");
                fallecido.Nombres = Console.ReadLine();
                Console.WriteLine("Apellidos: ");
                fallecido.Apellidos = Console.ReadLine();
                Console.WriteLine("Sexo: ");
                fallecido.Sexo = Console.ReadLine();
                Console.WriteLine("Fecha nacimiento: ");
                string fechaNac = Console.ReadLine();
                fallecido.FechaNacimiento = DateTime.Parse(fechaNac);
                fallecido.Estado = 0;
                Console.WriteLine("Pais: ");
                fallecido.Pais = Console.ReadLine();
                Console.WriteLine("Ciudad: ");
                fallecido.Ciudad = Console.ReadLine();
                

               
               

                //DATOS DEL MOVIMIENTO O TRANSACCION
                Console.WriteLine($"\n\n--- DATOS RESUMEN ---\n\n");
                resumen.Pais = fallecido.Pais;
                resumen.Ciudad = fallecido.Ciudad;

                Console.WriteLine($"Pais: {fallecido.Pais}");
                Console.WriteLine($"Ciudad: {fallecido.Ciudad}");
                comando.Parameters.Clear();
                //comando.CommandText = "SP_GetResumen";
                //comando.Parameters.AddWithValue("@Ciudad", resumen.Ciudad);
                //comando.Parameters.AddWithValue("@Pais", resumen.Pais);
                //reader = comando.ExecuteReader();//Ejecuto el reader asociado al procedure SP_GetClientes
                //if (reader.Read())
                //{
                //    String variable = (reader["CantidadMujeres"].ToString());
                //    resumen.CantidadMujeres = int.Parse(variable);
                //    variable = (reader["CantidadHombres"].ToString());
                //    resumen.CantidadHombres = int.Parse(variable);
                //    Console.WriteLine($"Cantidad Hombres: {resumen.CantidadHombres}");
                //    Console.WriteLine($"Cantidad Mujeres: {resumen.CantidadMujeres}");
                //    Console.WriteLine($"Fecha de ingreso: {reader["FechaIngreso"].ToString()}");
                //}
             
                try
                {
                    transaction = conexion.BeginTransaction();
                    comando.Transaction = transaction;
                    //Insertar FALLECIDO
                    comando.Parameters.Clear();
                    comando.CommandText = "SP_InsertarFallecido";
                    comando.Parameters.AddWithValue("@Nombres", fallecido.Nombres);
                    comando.Parameters.AddWithValue("@Apellidos", fallecido.Apellidos);
                    comando.Parameters.AddWithValue("@TipoDocumento", fallecido.TipoDocumento);
                    comando.Parameters.AddWithValue("@Documento", fallecido.Documento);
                    comando.Parameters.AddWithValue("@FechaNacimiento", fallecido.FechaNacimiento);
                    comando.Parameters.AddWithValue("@Sexo", fallecido.Sexo);
                    comando.Parameters.AddWithValue("@Estado", fallecido.Estado);
                    comando.Parameters.AddWithValue("@Pais", fallecido.Pais);
                    comando.Parameters.AddWithValue("@Ciudad", fallecido.Ciudad);
                    comando.ExecuteNonQuery();

                    //RESUMEN
                    comando.Parameters.Clear();
                    comando.CommandText = "SP_UpsertResumen";
                    comando.Parameters.AddWithValue("@Pais", resumen.Pais);
                    comando.Parameters.AddWithValue("@Ciudad", resumen.Ciudad);
                    comando.Parameters.AddWithValue("@Sexo", fallecido.Sexo);

                    comando.ExecuteNonQuery();
                    //throw new Exception("BOOM!");
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
