using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teo2.MyDSTableAdapters;
using static Teo2.MyDS;

namespace Teo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            tblClientesTableAdapter adapter= new tblClientesTableAdapter();
            adapter.Insert("Matilde", "Moreno", DateTime.Now.AddYears(20), "F", DateTime.Now, 1, "aada", 1, "1231", 100M);
            tblClientesDataTable tblClientes = adapter.GetDataByApellido("Moreno");
            foreach (var item in tblClientes)
            {
                Console.WriteLine($"{item.Nombres}-{item.Apellidos}");
            }
            SqlTransaction transaction = null;
            
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.SP_UpsertCliente("Matilde", "Moreno", DateTime.Now.AddYears(20), "aada", "F", 1, "1231", 100M, 1, 50);
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            Console.ReadKey();
        }
    }
}
