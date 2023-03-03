using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teo5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDATAEntities entities = new MyDATAEntities();
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
        }
    }
}
