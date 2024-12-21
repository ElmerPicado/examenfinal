using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenFinal.capaModelo
{
    public class Asignacion
    {
        public int AsignacionID { get; set; }
        public int EmpleadoID { get; set; }
        public int ProyectoID { get; set; }
        public string FechaAsignacion { get; set; }
        public string Estado { get; set; }
    }
}