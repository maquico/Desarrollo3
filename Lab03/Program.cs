using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                SqlCommand comando = new SqlCommand($"SP_GetCliente", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = null;
                SqlTransaction transaction = null;
                Console.WriteLine($"--- ESTADO CONEXION: {conexion.State} ---\n\n");

                //INSTANCIAS DE CLASES
                Cliente cliente = new Cliente();
                Transaccion transaccion = new Transaccion();

                //PIDO DATOS INICIALES DEL CLIENTE PARA VALIDAR SI EXISTE
                Console.WriteLine($"--- DATOS CLIENTE ---\n\n");
                Console.WriteLine("Tipo de documento: ");
                cliente.TipoDocumento = int.Parse(Console.ReadLine());
                Console.WriteLine("Documento:");
                cliente.Documento = Console.ReadLine();
                comando.Parameters.AddWithValue("@TipoDocumento", cliente.TipoDocumento);
                comando.Parameters.AddWithValue("@Documento", cliente.Documento);

                reader = comando.ExecuteReader(); //Ejecuto el reader asociado al procedure SP_GetClientes

                if (reader.Read())
                {
                    cliente.Nombres = reader["Nombres"].ToString();
                    Console.WriteLine($"Nombres: {cliente.Nombres}");

                    cliente.Apellidos = reader["Apellidos"].ToString();
                    Console.WriteLine($"Apellidos: {cliente.Apellidos}");

                    cliente.FechaNacimiento = (DateTime)reader["FechaNacimiento"];
                    Console.WriteLine($"Fecha de nacimiento del cliente: {cliente.FechaNacimiento.ToShortDateString()}");

                    cliente.Estado = (int)reader["Estado"];
                    Console.WriteLine($"Estado del cliente: {cliente.Estado}");

                    cliente.Comentario = reader["Comentario"].ToString();
                    Console.WriteLine($"Comentario del cliente: {cliente.Comentario}");

                    cliente.Sexo = reader["Sexo"].ToString();
                    Console.WriteLine($"Sexo del cliente: {cliente.Sexo}");

                    cliente.Balance = (decimal)reader["Balance"];
                    Console.WriteLine($"Balance del cliente: {cliente.Balance}");
                }
                else
                {
                    Console.WriteLine("Nombre:");
                    cliente.Nombres = Console.ReadLine();
                    Console.WriteLine("Apellidos:");
                    cliente.Apellidos = Console.ReadLine();
                    Console.WriteLine("Sexo:");
                    cliente.Sexo = Console.ReadLine();
                    Console.WriteLine("Fecha nacimiento:");
                    string fechaNac = Console.ReadLine();
                    cliente.FechaNacimiento = DateTime.Parse(fechaNac);
                    cliente.Estado = 0;
                    Console.WriteLine("Comentario: ");
                    cliente.Comentario = Console.ReadLine();
                    Console.WriteLine("Balance: ");
                    cliente.Balance = decimal.Parse(Console.ReadLine());
                }

                reader.Close();

                //DATOS DEL MOVIMIENTO O TRANSACCION
                Console.WriteLine($"\n\n--- DATOS MOVIMIENTO ---\n\n");
                Console.WriteLine("Monto: ");
                transaccion.monto = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Debito o Credito (db o cr): ");
                transaccion.debitoCredito = Console.ReadLine();
                Console.WriteLine("Tipo de transaccion: ");
                transaccion.tipoTransaccion = int.Parse(Console.ReadLine());

                transaction = conexion.BeginTransaction();
                comando.Transaction = transaction;

                try
                {
                    //Insertar cliente
                    comando.Parameters.Clear();
                    comando.CommandText = "SP_UpsertCliente";
                    comando.Parameters.AddWithValue("@Comentario", cliente.Comentario);
                    comando.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                    comando.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                    comando.Parameters.AddWithValue("@TipoDocumento", cliente.TipoDocumento);
                    comando.Parameters.AddWithValue("@Documento", cliente.Documento);
                    comando.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                    comando.Parameters.AddWithValue("@Sexo", cliente.Sexo);
                    comando.Parameters.AddWithValue("@Balance", cliente.Balance);
                    comando.Parameters.AddWithValue("@TipoTransaccion", transaccion.tipoTransaccion);
                    comando.Parameters.AddWithValue("@Monto", transaccion.monto);
                    comando.ExecuteNonQuery();

                    //TRANSACCION
                    comando.Parameters.Clear();
                    comando.CommandText = "SP_InsertarTransaccion";
                    comando.Parameters.AddWithValue("@TipoDocumento", cliente.TipoDocumento);
                    comando.Parameters.AddWithValue("@Documento", cliente.Documento);
                    comando.Parameters.AddWithValue("@Monto", transaccion.monto);
                    comando.Parameters.AddWithValue("@Descripcion", cliente.Comentario);
                    comando.Parameters.AddWithValue("@TipoTransaccion", transaccion.tipoTransaccion);
                    comando.Parameters.AddWithValue("@DebitoCredito", transaccion.debitoCredito);
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
