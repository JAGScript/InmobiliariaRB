using InmobiliariaRB.Logica;
using InmobiliariaRB.Model.Shared;
using InmobiliariaRB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InmobiliariaRB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTransacciones()
        {
            List<TransaccionMenu> transaccionesMenu = new List<TransaccionMenu>();

            SeguridadCore objSeguridad = new SeguridadCore();

            var usuario = (Usuario)System.Web.HttpContext.Current.Session["Usuario"];

            if (usuario != null)
            {
                var transacciones = objSeguridad.ConsultarTransaccionesUsuario(usuario.USERNAME.Trim());

                foreach (var tran in transacciones.FindAll(t => !string.IsNullOrEmpty(t.MENU)))
                {
                    var datosMenu = tran.MENU.Split('\\');

                    if (datosMenu.Length == 2)
                    {
                        TransaccionMenu menu = new TransaccionMenu();

                        menu.Nombre = tran.NOMBRE;
                        menu.UrlTransaccion = UrlHelper.GenerateUrl(null, datosMenu[1], datosMenu[0], null, RouteTable.Routes, System.Web.HttpContext.Current.Request.RequestContext, false);

                        transaccionesMenu.Add(menu);
                    }
                }
            }

            return Json(transaccionesMenu, JsonRequestBehavior.AllowGet);
        }
    }
}