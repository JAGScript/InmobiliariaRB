using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InmobiliariaRB.Models.Administracion
{
    public class PropietariosView
    {
        public int IdPropietario { get; set; }

        public string NombrePropietario { get; set; }

        public string DireccionPropietario { get; set; }

        public string CelularPropietario { get; set; }

        public string CorreoPropietario { get; set; }

        public int EstadoPropietario { get; set; }

        public bool EstadoPropietarioOriginal { get; set; }
    }
}