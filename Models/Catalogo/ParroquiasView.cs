using InmobiliariaRB.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InmobiliariaRB.Models.Catalogo
{
    public class ParroquiasView
    {
        public int IdParroquia { get; set; }

        public int IdCanton { get; set; }

        public string CodParroquia { get; set; }

        public string NombreParroquia { get; set; }

        public int EstadoParroquia { get; set; }

        public bool EstadoParroquiaOriginal { get; set; }

        public string NombreCanton { get; set; }

        public List<Canton> Cantones { get; set; }

        public ParroquiasView()
        {
            Cantones = new List<Canton>();
        }
    }
}