using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//REGISTROS DE LAS PAREJAS
namespace Lab02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cont = 1;
            while (true)
            {
                Persona persona = new Persona();
                //cliente1.ID = 1;
                Console.WriteLine("--PERSONA--");
                Console.WriteLine("Tipo documento:");
                persona.tipoDocumento = int.Parse(Console.ReadLine());
                Console.WriteLine("Documento:");
                persona.documento = Console.ReadLine();
                Console.WriteLine("Nombre:");
                persona.nombres = Console.ReadLine();
                Console.WriteLine("Apellidos:");
                persona.apellidos = Console.ReadLine();
                Console.WriteLine("Sexo:");
                persona.sexo = Console.ReadLine();
                Console.WriteLine("Fecha nacimiento:");
                string fechaNac = Console.ReadLine();
                persona.fechaNacimiento = DateTime.Parse(fechaNac);
                Console.WriteLine("Estado");
                persona.estado = int.Parse(Console.ReadLine());
                Console.WriteLine("Nacionalidad:");
                persona.nacionalidad = Console.ReadLine();
                Console.WriteLine("Pais Origen:");
                persona.paisOrigen = Console.ReadLine();
                Console.WriteLine("Cantidad de parejas:");
                persona.cantidad = int.Parse(Console.ReadLine());

                SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                conexion.Open();
                Console.WriteLine(conexion.State);

                SqlCommand comando = new SqlCommand($"SP_InsertarPersona", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipoDocumento", persona.tipoDocumento);
                comando.Parameters.AddWithValue("@documento", persona.documento);
                comando.Parameters.AddWithValue("@nombres", persona.nombres);
                comando.Parameters.AddWithValue("@apellidos", persona.apellidos);
                comando.Parameters.AddWithValue("@fechaNacimiento", persona.fechaNacimiento);
                comando.Parameters.AddWithValue("@sexo", persona.sexo);
                comando.Parameters.AddWithValue("@estado", persona.estado);
                comando.Parameters.AddWithValue("@nacionalidad", persona.nacionalidad);
                comando.Parameters.AddWithValue("@paisOrigen", persona.paisOrigen);
                comando.Parameters.AddWithValue("@cantidad", persona.cantidad);
                comando.ExecuteNonQuery();

                for (int i = 0; i < persona.cantidad; i++)
                {
                    Relacion relacion = new Relacion();

                    Console.WriteLine($"\n--RELACION-- PAREJA {i+1}\n");
                    Console.WriteLine("Tipo documento:");
                    relacion.tipoDocumento = int.Parse(Console.ReadLine());
                    Console.WriteLine("Documento:");
                    relacion.documento = Console.ReadLine();
                    Console.WriteLine("Nombre:");
                    relacion.nombres = Console.ReadLine();
                    Console.WriteLine("Apellidos:");
                    relacion.apellidos = Console.ReadLine();
                    Console.WriteLine("Sexo:");
                    relacion.sexo = Console.ReadLine();
                    Console.WriteLine("Fecha nacimiento:");
                    string fechaNac2 = Console.ReadLine();
                    relacion.fechaNacimiento = DateTime.Parse(fechaNac2);
                    Console.WriteLine("Estado");
                    relacion.estado = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nacionalidad:");
                    relacion.nacionalidad = Console.ReadLine();
                    Console.WriteLine("Pais Origen:");
                    relacion.paisNacimiento = Console.ReadLine();
                    
                    comando.Parameters.Clear();
                    comando.CommandText = "SP_InsertarRelacion";
                    comando.Parameters.AddWithValue("@tipoDocumento", relacion.tipoDocumento);
                    comando.Parameters.AddWithValue("@documento", relacion.documento);
                    comando.Parameters.AddWithValue("@nombres", relacion.nombres);
                    comando.Parameters.AddWithValue("@apellidos", relacion.apellidos);
                    comando.Parameters.AddWithValue("@fechaNacimiento", relacion.fechaNacimiento);
                    comando.Parameters.AddWithValue("@sexo", relacion.sexo);
                    comando.Parameters.AddWithValue("@estado", relacion.estado);
                    comando.Parameters.AddWithValue("@nacionalidad", relacion.nacionalidad);
                    comando.Parameters.AddWithValue("@paisNacimiento", relacion.paisNacimiento);
                    comando.Parameters.AddWithValue("@tipoDocumentoPareja", persona.tipoDocumento);
                    comando.Parameters.AddWithValue("@documentoPareja", persona.documento);
                    comando.ExecuteNonQuery();

                }
            }
        }
    }
}
