using InmobiliariaRB.Filters;
using InmobiliariaRB.Logica;
using InmobiliariaRB.Model.Shared;
using InmobiliariaRB.Models.Catalogo;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InmobiliariaRB.Controllers
{
    public class CatalogoController : Controller
    {
        [AuthorizeUser(idOperacion: 31)]
        public ActionResult Catalogos()
        {
            ViewBag.Title = "Gestión de Catalogos";

            SeguridadCore objSeguridad = new SeguridadCore();

            CatalogosView vistaCatalogo = new CatalogosView();

            var usuario = (Usuario)System.Web.HttpContext.Current.Session["Usuario"];

            var transacciones = objSeguridad.ConsultarSubMenuUsuario(usuario.USERNAME.Trim(), 31);

            vistaCatalogo.IdMenuPadre = 31;
            vistaCatalogo.Transacciones = transacciones;

            return View("_Catalogos", vistaCatalogo);
        }

        #region Provincias
        [AuthorizeUser(idOperacion: 32)]
        public ActionResult Provincias(string titulo)
        {
            ViewBag.Title = titulo;

            ProvinciasView vistaProvincias = new ProvinciasView();

            return View("_Provincias", vistaProvincias);
        }

        public JsonResult CargarGridProvincias([DataSourceRequest] DataSourceRequest request)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                var pronvicias = objCatalogo.ConsultarProvincias(true);

                if (pronvicias == null)
                    pronvicias = new List<Provincia>();
                else
                {
                    pronvicias = pronvicias.OrderBy(e => e.IDPROVINCIA).ToList();
                }

                return Json(pronvicias.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }

        public JsonResult ActualizarProvincia(int idProvincia, string codProvincia, string nombre, int estado)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                Provincia provincia = new Provincia()
                {
                    IDPROVINCIA = idProvincia,
                    CODPROVINCIA = codProvincia,
                    NOMBREPROVINCIA = nombre,
                    ESTADOPROVINCIA = Convert.ToBoolean(estado)
                };

                objCatalogo.ActualizarProvincia(provincia);

                return Json("");
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }

        public JsonResult GuardarProvincia(string codProvincia, string nombre)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                Provincia provincia = new Provincia()
                {
                    CODPROVINCIA = codProvincia,
                    NOMBREPROVINCIA = nombre,
                    ESTADOPROVINCIA = true
                };

                objCatalogo.GuardarProvincia(provincia);

                return Json("");
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }

        public JsonResult EliminarProvincia(int idProvincia)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                objCatalogo.EliminarProvincia(idProvincia);

                return Json("");
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }
        #endregion

        #region Cantones
        public ActionResult Cantones(string titulo)
        {
            ViewBag.Title = titulo;

            CantonesView vistaCantones = new CantonesView();
            CatalogoCore objCatalogo = new CatalogoCore();
            var pronvicias = objCatalogo.ConsultarProvincias();
            vistaCantones.Provincias = pronvicias;

            return View("_Cantones", vistaCantones);
        }

        public JsonResult CargarGridCantones([DataSourceRequest] DataSourceRequest request, int idProvincia)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                var cantones = objCatalogo.ConsultarCantones(idProvincia, true);

                if (cantones == null)
                    cantones = new List<Canton>();
                else
                {
                    cantones = cantones.OrderBy(e => e.IDCANTON).ToList();
                }

                return Json(cantones.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }

        public JsonResult ActualizarCanton(int idCanton, int idProvincia, string codCanton, string nombre, int estado)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                Canton canton = new Canton()
                {
                    IDCANTON = idCanton,
                    IDPROVINCIA = idProvincia,
                    CODCANTON = codCanton,
                    NOMBRECANTON = nombre,
                    ESTADOCANTON = Convert.ToBoolean(estado)
                };

                objCatalogo.ActualizarCanton(canton);

                return Json("");
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }

        public JsonResult GuardarCanton(int idProvincia, string codCanton, string nombre)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                Canton canton = new Canton()
                {
                    IDPROVINCIA = idProvincia,
                    CODCANTON = codCanton,
                    NOMBRECANTON = nombre,
                    ESTADOCANTON = true
                };

                objCatalogo.GuardarCanton(canton);

                return Json("");
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }

        public JsonResult EliminarCanton(int idCanton)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                objCatalogo.EliminarCanton(idCanton);

                return Json("");
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }
        #endregion

        #region Parroquias
        public ActionResult Parroquias(string titulo)
        {
            ViewBag.Title = titulo;

            ParroquiasView vista = new ParroquiasView();
            CatalogoCore objCatalogo = new CatalogoCore();
            var cantones = objCatalogo.ConsultarCantones();
            vista.Cantones = cantones;

            return View("_Parroquias", vista);
        }

        public JsonResult CargarGridParroquias([DataSourceRequest] DataSourceRequest request, int idCanton)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                var parroquias = objCatalogo.ConsultarParroquias(idCanton, true);

                if (parroquias == null)
                    parroquias = new List<Parroquia>();
                else
                {
                    parroquias = parroquias.OrderBy(e => e.IDPARROQUIA).ToList();
                }

                return Json(parroquias.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }

        public JsonResult ActualizarParroquia(int idParroquia, int idCanton, string codParroquia, string nombre, int estado)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                Parroquia parroquia = new Parroquia()
                {
                    IDPARROQUIA = idParroquia,
                    IDCANTON = idCanton,
                    CODPARROQUIA = codParroquia,
                    NOMBRECANTON = nombre,
                    ESTADOPARROQUIA = Convert.ToBoolean(estado)
                };

                objCatalogo.ActualizarParroquia(parroquia);

                return Json("");
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }

        public JsonResult GuardarParroquia(int idCanton, string codigo, string nombre)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                Parroquia parroquia = new Parroquia()
                {
                    IDCANTON = idCanton,
                    CODPARROQUIA = codigo,
                    NOMBREPARROQUIA = nombre,
                    ESTADOPARROQUIA = true
                };

                objCatalogo.GuardarParroquia(parroquia);

                return Json("");
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }

        public JsonResult EliminarParroquia(int idParroquia)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                objCatalogo.EliminarParroquia(idParroquia);

                return Json("");
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }
        #endregion

        #region Barrios
        public ActionResult Barrios(string titulo)
        {
            ViewBag.Title = titulo;

            BarriosView vista = new BarriosView();
            CatalogoCore objCatalogo = new CatalogoCore();
            var parroquias = objCatalogo.ConsultarParroquias();
            vista.Parroquias = parroquias;

            return View("_Barrios", vista);
        }

        public JsonResult CargarGridBarrios([DataSourceRequest] DataSourceRequest request, int idParroquia)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                var barrios = objCatalogo.ConsultarBarrios(idParroquia, true);

                if (barrios == null)
                    barrios = new List<Barrio>();
                else
                {
                    barrios = barrios.OrderBy(e => e.IDBARRIO).ToList();
                }

                return Json(barrios.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }

        public JsonResult ActualizarBarrio(int idBarrio, int idParroquia, string nombre, int estado)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                Barrio barrio = new Barrio()
                {
                    IDBARRIO = idBarrio,
                    IDPARROQUIA = idParroquia,
                    NOMBREBARRIO = nombre,
                    ESTADOBARRIO = Convert.ToBoolean(estado)
                };

                objCatalogo.ActualizarBarrio(barrio);

                return Json("");
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }

        public JsonResult GuardarBarrio(int idParroquia, string nombre)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                Barrio barrio = new Barrio()
                {
                    IDPARROQUIA = idParroquia,
                    NOMBREBARRIO = nombre,
                    ESTADOBARRIO = true
                };

                objCatalogo.GuardarBarrio(barrio);

                return Json("");
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }

        public JsonResult EliminarBarrio(int idBarrio)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                objCatalogo.EliminarBarrio(idBarrio);

                return Json("");
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }
        #endregion

        #region TiposPropiedad
        public ActionResult TiposPropiedad(string titulo)
        {
            ViewBag.Title = titulo;

            TiposPropiedadView vista = new TiposPropiedadView();

            return View("_TiposPropiedad", vista);
        }

        public JsonResult CargarGridTiposPropiedad([DataSourceRequest] DataSourceRequest request)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                var tipos = objCatalogo.ConsultarTiposPropiedad(true);

                if (tipos == null)
                    tipos = new List<TipoPropiedad>();
                else
                {
                    tipos = tipos.OrderBy(e => e.IDTIPOPROPIEDAD).ToList();
                }

                return Json(tipos.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }

        public JsonResult ActualizarTiposPropiedad(int idTipo, string nombre, int estado)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                TipoPropiedad tipo = new TipoPropiedad()
                {
                    IDTIPOPROPIEDAD = idTipo,
                    NOMBRETIPOPROPIEDAD = nombre,
                    ESTADOTIPOPROPIEDAD = Convert.ToBoolean(estado)
                };

                objCatalogo.ActualizarTiposPropiedad(tipo);

                return Json("");
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }

        public JsonResult GuardarTiposPropiedad(string nombre)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                TipoPropiedad tipo = new TipoPropiedad()
                {
                    NOMBRETIPOPROPIEDAD = nombre,
                    ESTADOTIPOPROPIEDAD = true
                };

                objCatalogo.GuardarTiposPropiedad(tipo);

                return Json("");
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
        }

        public JsonResult EliminarTiposPropiedad(int idTipo)
        {
            CatalogoCore objCatalogo = new CatalogoCore();

            try
            {
                objCatalogo.EliminarTiposPropiedad(idTipo);

                return Json("");
            }
            catch (Exception ex)
            {
                return RetornarErrorJsonResult(ex.Message);
            }
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