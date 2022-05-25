using InmobiliariaRB.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InmobiliariaRB.Models.Catalogo
{
    public class BarriosView
    {
        public int IdBarrio { get; set; }

        public int IdParroquia { get; set; }

        public string NombreBarrio { get; set; }

        public int EstadoBarrio { get; set; }

        public string NombreParroquia { get; set; }

        public List<Parroquia> Parroquias { get; set; }

        public BarriosView()
        {
            Parroquias = new List<Parroquia>();
        }
    }
}