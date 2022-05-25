using InmobiliariaRB.Model.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InmobiliariaRB.Models.Seguridad
{
    public class UsuariosView
    {
        public int IdUsuario { get; set; }

        public int IdRol { get; set; }

        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string IdentificacionUsuario { get; set; }

        public string CorreoUsuario { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Contrasena { get; set; }

        public int Estado { get; set; }

        public List<Rol> Roles { get; set; }

        public bool EstadoOriginalUsuario { get; set; }

        public UsuariosView()
        {
            Roles = new List<Rol>();
        }
    }
}