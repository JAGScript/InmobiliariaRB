using InmobiliariaRB.Logica;
using InmobiliariaRB.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InmobiliariaRB.Controllers
{
    public class ServiciosController : ApiController
    {
        [HttpGet]
        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            string email = "administrador@pruebas.com";
            SeguridadCore objSeguridad = new SeguridadCore();

            var usuario = objSeguridad.ConsultarUsuario(email);

            var respuesta = new List<Usuario>();
            respuesta.Add(usuario);

            var record = respuesta.ToArray();

            return record;
        }
    }
}
