using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Teo6WebApp
{
    /// <summary>
    /// Descripción breve de ServicioWebTeo6
    /// </summary>
    [WebService(Namespace = "http://intec.edu.do")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioWebTeo6 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]

        public int Sumar(int num1, int num2)
        {
            return num1 + num2;
        }

        [WebMethod]
        public Mensaje RegistrarCliente(Cliente cliente)
        {
            Mensaje mensaje = new Mensaje()
            {
                Codigo = 0,
                Texto = $"Transaccion procesada: {cliente.Nombre}",
                Tipo = 1
            };
            return mensaje;
        }
    }
}
