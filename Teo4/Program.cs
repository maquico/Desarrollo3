using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teo4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDATAEntities1 entities = new MyDATAEntities1();
            entities.tblClientes.Add(new tblClientes()
            {
                Nombres = "Jose",
                Apellidos = "Perez",
                TipoDocumento = 1,
                Documento = "200",
                Balance = 0,
                Comentario = "NA",
                Estado = 0,
                FechaIngreso = DateTime.Now,
                FechaNacimiento = DateTime.Now.AddYears(-15),
                Id = 0,
                Sexo = "M"
            });
            entities.SaveChanges();

            //entities.tblClientes.ToList().ForEach(entities =>
            //{
            //    //ConsoleWriteLine
            //}
        }
    }
}
