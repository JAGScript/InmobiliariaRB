using InmobiliariaRB.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InmobiliariaRB.Models.Catalogo
{
    public class TiposPropiedadView
    {
        public int IdTipoPropiedad { get; set; }

        public string NombreTipoPropiedad { get; set; }

        public int EstadoTipoPropiedad { get; set; }

        public bool EstadoTipoPropiedadOriginal { get; set; }

        public List<TipoPropiedad> Tipos { get; set; }

        public TiposPropiedadView()
        {
            Tipos = new List<TipoPropiedad>();
        }
    }
}