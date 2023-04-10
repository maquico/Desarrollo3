using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class PlaceOrder :
        ICommand
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public decimal ITBIS { get; set; }
        public decimal TotalGeneral { get; set; }
        public int Estado { get; set; }



    }
}
