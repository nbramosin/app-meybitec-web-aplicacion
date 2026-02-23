using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace app_meybitec_web_aplicacion.Controllers
{
    public class PrincipalController : BaseController
    {
        // GET: Principal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inicio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session.Remove("JWT_TOKEN");
            Session.Remove("oUsuario");
            Session.Abandon();

            return Json(new
            {
                Ok = true
            });
        }
    }
}