//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Teo4
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblClientes
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public int Estado { get; set; }
        public string Comentario { get; set; }
        public int TipoDocumento { get; set; }
        public string Documento { get; set; }
        public decimal Balance { get; set; }
    }
}