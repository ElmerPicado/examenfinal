using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenFinal.capaModelo
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
    }
}