using Capa.Entidad.APIs;
using Capa.Entidad.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace app_meybitec_web_aplicacion.Controllers
{
    public class BaseController : Controller
    {
        protected ActionResult ValidarSesion<T>(ApiResponse<T> resp)
        {
            if (resp?.Header?.CodigoRetorno == 401)
            {
                Session.Clear();
                Session.Abandon();
                return RedirectToAction("Index", "Login");
            }

            return null;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var usuario = Session["oUsuario"] as UsuarioResponse;
            ViewBag.Nombre = usuario?.nombre;

            base.OnActionExecuting(filterContext);
        }
    }
}