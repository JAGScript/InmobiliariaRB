using InmobiliariaRB.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InmobiliariaRB.Models.Catalogo
{
    public class CatalogosView
    {
        public int IdMenuPadre { get; set; }

        public List<Transaccion> Transacciones { get; set; }

        public CatalogosView()
        {
            Transacciones = new List<Transaccion>();
        }
    }
}