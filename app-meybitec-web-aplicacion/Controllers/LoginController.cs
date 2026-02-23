using Capa.Entidad.Usuario;
using Capa.Negocio.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace app_meybitec_web_aplicacion.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        /*public async Task<ActionResult> Acceso()
        {

        }*/

        [HttpPost]
        public async Task<ActionResult> Login(UsuarioRequest request)
        {
            var response = await Common.Login(request);

            if (response.Header.CodigoRetorno != 0)
            {
                return Json(new
                {
                    Ok = false,
                    message = response.Header.DescRetorno
                });
            }
                //return View("Login");
            //Guardar Token generado
            Session["JWT_TOKEN"] = response.Body.token;
            Session["oUsuario"] = response.Body.usuario;

            return Json(new
            {
                Ok = true,
                data = response
            });
        }
    }
}