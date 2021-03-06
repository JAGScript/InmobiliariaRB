using InmobiliariaRB.Filters;
using InmobiliariaRB.Logica;
using InmobiliariaRB.Model.Shared;
using InmobiliariaRB.Models.Administracion;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InmobiliariaRB.Controllers
{
    public class AdministracionController : Controller
    {
        #region Clientes
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Clientes()
        {
            ViewBag.Title = "Gestión de Clientes";

            SeguridadCore objSeguridad = new SeguridadCore();

            ClientesView vistaClientes = new ClientesView();

            try
            {
                vistaClientes.IdTemp = Guid.NewGuid().ToString();
                vistaClientes.Asesores = objSeguridad.ConsultarAsesores();
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
            }

            return View("_Clientes", vistaClientes);
        }

        public JsonResult CargarGridClientes([DataSourceRequest] DataSourceRequest request)
        {
            AdministracionCore objAdministracion = new AdministracionCore();

            try
            {
                var clientes = objAdministracion.ConsultarClientes(true);

                if (clientes == null)
                    clientes = new List<Cliente>();
                else
                {
                    clientes = clientes.OrderBy(e => e.IDCLIENTE).ToList();
                }

                return Json(clientes.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }

        public ActionResult ActualizarUsuario(ClientesView vistaCliente)
        {
            ViewBag.Title = "Gestión de Clientes";

            AdministracionCore objAdministracion = new AdministracionCore();
            SeguridadCore objSeguridad = new SeguridadCore();

            try
            {
                if (ModelState.IsValid)
                {
                    Cliente cliente = new Cliente()
                    {
                        IDCLIENTE = vistaCliente.IdCliente,
                        NOMBRECLIENTE = vistaCliente.NombreCliente,
                        IDENTIFICACIONCLIENTE = vistaCliente.IdentificacionCliente,
                        DIRECCIONCLIENTE = vistaCliente.DireccionCliente,
                        CELULARCLIENTE = vistaCliente.CelularCliente,
                        CORREOCLIENTE = vistaCliente.CorreoCliente,
                        ASESOR = vistaCliente.IdAsesor,
                        ESTADOCLIENTE = vistaCliente.EstadoOriginalCliente ? true : vistaCliente.EstadoCliente == 1
                    };

                    objAdministracion.ActualizarCliente(cliente);

                    vistaCliente.IdTemp = Guid.NewGuid().ToString();
                    vistaCliente.Asesores = objSeguridad.ConsultarAsesores();

                    vistaCliente = new ClientesView();

                    ModelState.Clear();
                }

                ViewBag.Message = "Cliente Actualizado Correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
            }

            return View("_Clientes", vistaCliente);
        }

        public ActionResult EliminarCliente(ClientesView vistaCliente)
        {
            ViewBag.Title = "Gestión de Clientes";

            AdministracionCore objAdministracion = new AdministracionCore();
            SeguridadCore objSeguridad = new SeguridadCore();

            try
            {
                if (ModelState.IsValid)
                {
                    Cliente cliente = new Cliente()
                    {
                        IDCLIENTE = vistaCliente.IdCliente
                    };

                    objAdministracion.EliminarCliente(cliente);

                    vistaCliente.IdTemp = Guid.NewGuid().ToString();
                    vistaCliente.Asesores = objSeguridad.ConsultarAsesores();

                    vistaCliente = new ClientesView();

                    ModelState.Clear();
                }

                ViewBag.Message = "Cliente Eliminado Correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
            }

            return View("_Clientes", vistaCliente);
        }

        public ActionResult GuardarCliente(ClientesView vistaCliente)
        {
            ViewBag.Title = "Gestión de Clientes";

            AdministracionCore objAdministracion = new AdministracionCore();
            SeguridadCore objSeguridad = new SeguridadCore();

            try
            {
                if (ModelState.IsValid)
                {
                    Cliente cliente = new Cliente()
                    {
                        NOMBRECLIENTE = vistaCliente.NombreCliente,
                        IDENTIFICACIONCLIENTE = vistaCliente.IdentificacionCliente,
                        DIRECCIONCLIENTE = vistaCliente.DireccionCliente,
                        CELULARCLIENTE = vistaCliente.CelularCliente,
                        CORREOCLIENTE = vistaCliente.CorreoCliente,
                        ASESOR = vistaCliente.IdAsesor,
                        ESTADOCLIENTE = true
                    };

                    objAdministracion.GuardarCliente(cliente);

                    vistaCliente.IdTemp = Guid.NewGuid().ToString();
                    vistaCliente.Asesores = objSeguridad.ConsultarAsesores();

                    vistaCliente = new ClientesView();

                    ModelState.Clear();
                }

                ViewBag.Message = "Cliente Actualizado Correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
            }

            return View("_Clientes", vistaCliente);
        }
        #endregion

        #region Propiedades
        [AuthorizeUser(idOperacion: 11)]
        public ActionResult Propiedades()
        {
            ViewBag.Title = "Gestión de Propiedades";

            CatalogoCore objCatalogo = new CatalogoCore();
            AdministracionCore objAdministracion = new AdministracionCore();

            PropiedadesView vista = new PropiedadesView();

            try
            {
                vista.TiposPropiedades = objCatalogo.ConsultarTiposPropiedad();
                vista.Provincias = objCatalogo.ConsultarProvincias();
                vista.Propietarios = objAdministracion.ConsultarPropietarios();
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
            }

            return View("_Propiedades", vista);
        }

        public JsonResult CargarGridPropiedades([DataSourceRequest] DataSourceRequest request)
        {
            AdministracionCore objAdministracion = new AdministracionCore();

            try
            {
                var propiedades = objAdministracion.ConsultarPropiedades(true);

                if (propiedades == null)
                    propiedades = new List<Propiedad>();
                else
                {
                    propiedades = propiedades.OrderBy(e => e.IDPROPIEDAD).ToList();
                }

                return Json(propiedades.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }

        public ActionResult GuardarPropiedad(PropiedadesView vista)
        {
            ViewBag.Title = "Gestión de Propiedades";

            AdministracionCore objAdministracion = new AdministracionCore();
            CatalogoCore objCatalogo = new CatalogoCore();

            var usuario = (Usuario)System.Web.HttpContext.Current.Session["Usuario"];

            try
            {
                Propiedad propiedad = new Propiedad()
                {
                    IDPROPIETARIO = vista.IdPropietario,
                    IDTIPOPROPIEDAD = vista.IdTipoPropiedad,
                    IDPROVINCIA = vista.IdProvincia,
                    PRECIO = vista.Precio,
                    IDUSUARIO = usuario.IDUSUARIO,
                    ESTADOPROPIEDAD = true
                };

                Caracteristica caracteristica = new Caracteristica()
                {
                    METROSCUADRADOS = vista.Caracteristica.METROSCUADRADOS,
                    PLANTAS = vista.Caracteristica.PLANTAS,
                    BANIOS = vista.Caracteristica.BANIOS,
                    HABITACIONES = vista.Caracteristica.HABITACIONES,
                    PARQUEADEROS = vista.Caracteristica.PARQUEADEROS,
                    SERVICIOS = vista.Caracteristica.SERVICIOS,
                    OTROS = vista.Caracteristica.OTROS
                };

                objAdministracion.GuardarPropiedad(caracteristica, propiedad);

                vista = new PropiedadesView();

                vista.TiposPropiedades = objCatalogo.ConsultarTiposPropiedad();
                vista.Provincias = objCatalogo.ConsultarProvincias();
                vista.Propietarios = objAdministracion.ConsultarPropietarios();

                ModelState.Clear();

                ViewBag.Message = "Propiedad Guardada Correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
            }

            return View("_Propiedades", vista);
        }

        public ActionResult ActualizarPropiedad(PropiedadesView vista)
        {
            ViewBag.Title = "Gestión de Propiedades";

            AdministracionCore objAdministracion = new AdministracionCore();
            CatalogoCore objCatalogo = new CatalogoCore();

            var usuario = (Usuario)System.Web.HttpContext.Current.Session["Usuario"];

            try
            {
                if (ModelState.IsValid)
                {
                    Propiedad propiedad = new Propiedad()
                    {
                        IDPROPIEDAD = vista.IdPropiedad,
                        IDTIPOPROPIEDAD = vista.IdTipoPropiedad,
                        IDPROVINCIA = vista.IdProvincia,
                        PRECIO = vista.Precio,
                        IDUSUARIO = usuario.IDUSUARIO,
                        ESTADOPROPIEDAD = vista.EstadoPropiedadOriginal ? true : vista.EstadoPropiedad == 1
                    };

                    objAdministracion.ActualizarPropiedad(propiedad);

                    vista = new PropiedadesView();

                    vista.TiposPropiedades = objCatalogo.ConsultarTiposPropiedad();
                    vista.Provincias = objCatalogo.ConsultarProvincias();
                    vista.Propietarios = objAdministracion.ConsultarPropietarios();

                    ModelState.Clear();
                }

                ViewBag.Message = "Propiedad Actualizada Correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
            }

            return View("_Propiedades", vista);
        }

        public ActionResult EliminarPropiedad(PropiedadesView vista)
        {
            ViewBag.Title = "Gestión de Propiedades";

            AdministracionCore objAdministracion = new AdministracionCore();
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                if (ModelState.IsValid)
                {
                    Propiedad propiedad = new Propiedad()
                    {
                        IDPROPIEDAD = vista.IdPropiedad
                    };

                    objAdministracion.EliminarPropiedad(propiedad);

                    vista = new PropiedadesView();

                    vista.TiposPropiedades = objCatalogo.ConsultarTiposPropiedad();
                    vista.Provincias = objCatalogo.ConsultarProvincias();
                    vista.Propietarios = objAdministracion.ConsultarPropietarios();

                    ModelState.Clear();
                }

                ViewBag.Message = "Propiedad Eliminada Correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
            }

            return View("_Propiedades", vista);
        }
        #endregion

        #region Propietarios
        [AuthorizeUser(idOperacion: 21)]
        public ActionResult Propietarios()
        {
            ViewBag.Title = "Gestión de Propietarios";

            PropietariosView vista = new PropietariosView();

            return View("_Propietarios", vista);
        }

        public JsonResult CargarGridPropietarios([DataSourceRequest] DataSourceRequest request)
        {
            AdministracionCore objAdministracion = new AdministracionCore();

            try
            {
                var propietarios = objAdministracion.ConsultarPropietarios(true);

                if (propietarios == null)
                    propietarios = new List<Propietario>();
                else
                {
                    propietarios = propietarios.OrderBy(e => e.IDPROPIETARIO).ToList();
                }

                return Json(propietarios.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }

        public ActionResult GuardarPropietario(PropietariosView vista)
        {
            ViewBag.Title = "Gestión de Propietarios";

            AdministracionCore objAdministracion = new AdministracionCore();

            try
            {
                if (ModelState.IsValid)
                {
                    Propietario propietario = new Propietario()
                    {
                        NOMBREPROPIETARIO = vista.NombrePropietario,
                        DIRECCIONPROPIETARIO = vista.DireccionPropietario,
                        CELULARPROPIETARIO = vista.CelularPropietario,
                        CORRREOPROPIETARIO = vista.CorreoPropietario,
                        ESTADOPROPIETARIO = true
                    };

                    objAdministracion.GuardarPropietario(propietario);

                    vista = new PropietariosView();

                    ModelState.Clear();
                }

                ViewBag.Message = "Propietario Guardado Correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
            }

            return View("_Propietarios", vista);
        }

        public ActionResult ActualizarPropietario(PropietariosView vista)
        {
            ViewBag.Title = "Gestión de Propietarios";

            AdministracionCore objAdministracion = new AdministracionCore();

            try
            {
                if (ModelState.IsValid)
                {
                    Propietario propietario = new Propietario()
                    {
                        IDPROPIETARIO = vista.IdPropietario,
                        NOMBREPROPIETARIO = vista.NombrePropietario,
                        DIRECCIONPROPIETARIO = vista.DireccionPropietario,
                        CELULARPROPIETARIO = vista.CelularPropietario,
                        CORRREOPROPIETARIO = vista.CorreoPropietario,
                        ESTADOPROPIETARIO = vista.EstadoPropietarioOriginal ? true : vista.EstadoPropietario == 1
                    };

                    objAdministracion.ActualizarPropietario(propietario);

                    vista = new PropietariosView();

                    ModelState.Clear();
                }

                ViewBag.Message = "Propietario Actualizado Correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
            }

            return View("_Propietarios", vista);
        }

        public ActionResult EliminarPropietario(PropietariosView vista)
        {
            ViewBag.Title = "Gestión de Propietarios";

            AdministracionCore objAdministracion = new AdministracionCore();

            try
            {
                if (ModelState.IsValid)
                {
                    Propietario propietario = new Propietario()
                    {
                        IDPROPIETARIO = vista.IdPropietario
                    };

                    objAdministracion.EliminarPropietario(propietario);

                    vista = new PropietariosView();

                    ModelState.Clear();
                }

                ViewBag.Message = "Propietario Eliminado Correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
            }

            return View("_Propietarios", vista);
        }
        #endregion

        #region Comunes
        private JsonResult RetornarErrorJsonResult(string mensajeError)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Response.StatusDescription = mensajeError.Replace(Environment.NewLine, string.Empty);

            return Json(mensajeError, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}