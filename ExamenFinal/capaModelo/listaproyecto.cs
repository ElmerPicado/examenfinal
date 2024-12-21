using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenFinal.capaModelo
{
    public class listaproyecto
    {
        public class Proyecto
        {
            public int ProyectoID { get; set; }
            public string Nombre { get; set; }
            public int Codigo { get; set; }
            public DateTime FechaAsignacion { get; set; }
            public DateTime FechaFinal { get; set; }
        }
    }
}