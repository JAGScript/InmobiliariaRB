using InmobiliariaRB.Model.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InmobiliariaRB.Models.Administracion
{
    public class ClientesView
    {
        public int IdCliente { get; set; }

        [Required]
        public string IdentificacionCliente { get; set; }

        [Required]
        public string NombreCliente { get; set; }

        [Required]
        public string DireccionCliente { get; set; }

        [Required]
        public string CelularCliente { get; set; }

        [Required]
        public string CorreoCliente { get; set; }

        public int IdAsesor { get; set; }

        public int EstadoCliente { get; set; }

        public bool EstadoOriginalCliente { get; set; }

        public string IdTemp { get; set; }

        public List<Usuario> Asesores { get; set; }

        public List<Cliente> Clientes { get; set; }

        public ClientesView()
        {
            Clientes = new List<Cliente>();
            Asesores = new List<Usuario>();
        }
    }
}