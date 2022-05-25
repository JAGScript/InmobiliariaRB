using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InmobiliariaRB.Models.Catalogo
{
    public class ProvinciasView
    {
        public int IdProvincia { get; set; }

        [Required]
        public string CodProvincia { get; set; }

        [Required]
        public string NombreProvincia { get; set; }

        public int EstadoProvincia { get; set; }

        public bool EstadoProvinciaOriginal { get; set; }
    }
}