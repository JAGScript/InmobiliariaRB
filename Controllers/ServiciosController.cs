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
        [ActionName("ConsultarUsuario")]
        public IEnumerable<Usuario> ConsultarUsuario(string id)
        {
            string email = id;
            SeguridadCore objSeguridad = new SeguridadCore();

            var usuario = objSeguridad.ConsultarUsuario(email);

            var respuesta = new List<Usuario>();
            respuesta.Add(usuario);

            var record = respuesta.ToArray();

            return record;
        }

        [HttpGet]
        [ActionName("ObtenerPropiedades")]
        public IEnumerable<Propiedad> ObtenerPropiedades()
        {
            AdministracionCore objAdministracion = new AdministracionCore();

            var propiedades = objAdministracion.ConsultarPropiedades();

            var respuesta = new List<Propiedad>();

            respuesta.AddRange(propiedades);

            var record = respuesta.ToArray();

            return record;
        }
    }
}
