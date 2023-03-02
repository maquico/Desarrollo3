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
            MyDATAEntities entities = new MyDATAEntities();
            entities.tblCliente.Add(new tblCliente())
                {
                Nombres =
            }

            entities.SaveChanges();

            entities.tblClientes.ToList().ForEach(entities =>
            {
                //ConsoleWriteLine
            }
        }
    }
}
