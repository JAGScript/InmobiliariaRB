using InmobiliariaRB.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InmobiliariaRB.Models.Administracion
{
    public class PropiedadesView
    {
        public int IdPropiedad { get; set; }

        public int IdCaracteristica { get; set; }

        public int IdProvincia { get; set; }

        public List<Provincia> Provincias { get; set; }

        public int IdTipoPropiedad { get; set; }

        public List<TipoPropiedad> TiposPropiedades { get; set; }

        public int IdPropietario { get; set; }

        public List<Propietario> Propietarios { get; set; }

        public int IdUsuario { get; set; }

        public decimal Precio { get; set; }

        public DateTime FechaRegistroPropiedad { get; set; }

        public string FotoPrincipal { get; set; }

        public int EstadoPropiedad { get; set; }

        public bool EstadoPropiedadOriginal { get; set; }

        public Caracteristica Caracteristica { get; set; }

        public PropiedadesView()
        {
            TiposPropiedades = new List<TipoPropiedad>();
            Provincias = new List<Provincia>();
            Propietarios = new List<Propietario>();
        }
    }
}