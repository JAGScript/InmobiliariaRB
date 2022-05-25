using InmobiliariaRB.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InmobiliariaRB.Models.Catalogo
{
    public class CantonesView
    {
        public int IdCanton { get; set; }

        public int IdProvincia { get; set; }

        public string CodCanton { get; set; }

        public string NombreCanton { get; set; }

        public int EstadoCanton { get; set; }

        public bool EstadoCantonOriginal { get; set; }

        public string NombreProvincia { get; set; }

        public List<Provincia> Provincias { get; set; }

        public CantonesView()
        {
            Provincias = new List<Provincia>();
        }
    }
}