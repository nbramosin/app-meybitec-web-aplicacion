using Capa.Entidad;
using Capa.Entidad.Persona;
using Capa.Entidad.Producto;
using Capa.Entidad.Usuario;
using Capa.Negocio.Common;
using Capa.Transversal.Common;
using Capa.Transversal.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace app_meybitec_web_aplicacion.Controllers
{
    public class VistaController : BaseController
    {
        //public static readonly string token = Session["JWT_TOKEN"]?.ToString();
        // GET: Vista
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Producto()
        {
            ViewBag.MenuActivo = "mnuproducto";
            //var token = Session["JWT_TOKEN"]?.ToString();
            var taskMarcas = Common.ObtenerMarcasProducto();
            var taskCategorias = Common.ObtenerCategoriasProducto();
            var taskConexiones = Common.ObtenerConexionesProducto();
            var taskTiposCategoria = Common.ObtenerTiposCategoriaProducto();
            var taskLongitudes = Common.ObtenerLongitudesProducto();

            await Task.WhenAll(
                taskMarcas,
                taskCategorias,
                taskConexiones,
                taskTiposCategoria,
                taskLongitudes
            );

            var objMarcasProdResponse = taskMarcas.Result;
            var objCatProdResponse = taskCategorias.Result;
            var objCnxProdResponse = taskConexiones.Result;
            var objTiposCatProdResponse = taskTiposCategoria.Result;
            var objLongProdResponse = taskLongitudes.Result;

            // Validar si el token esta vencido
            var session = ValidarSesion(objMarcasProdResponse);
            if (session != null)
            {
                return session;
            }

            if (!RespuestaServicio.RespuestaValida(objMarcasProdResponse))
                return ErrorView("No se pudieron cargar las marcas");

            if (!RespuestaServicio.RespuestaValida(objCatProdResponse))
                return ErrorView("No se pudieron cargar las categorías");

            if (!RespuestaServicio.RespuestaValida(objCnxProdResponse))
                return ErrorView("No se pudieron cargar las conexiones");

            if (!RespuestaServicio.RespuestaValida(objTiposCatProdResponse))
                return ErrorView("No se pudieron cargar los tipos de categoría");

            if (!RespuestaServicio.RespuestaValida(objLongProdResponse))
                return ErrorView("No se pudieron cargar las longitudes");

            var marcas = objMarcasProdResponse.Body;
            var categorias = objCatProdResponse.Body;
            var conexiones = objCnxProdResponse.Body;
            var tiposCategoria = objTiposCatProdResponse.Body;
            var longitudes = objLongProdResponse.Body;

            ViewBag.Marcas = marcas;
            ViewBag.Categorias = categorias;
            ViewBag.Conexiones = conexiones;
            ViewBag.TiposCategoria = tiposCategoria;
            ViewBag.Longitudes = longitudes;

            return View();
        }

        public ActionResult Marcas()
        {
            ViewBag.MenuActivo = "mnumarcas";
            return View();
        }

        public async Task<ActionResult> Modelos()
        {
            ViewBag.MenuActivo = "mnumodelos";

            var objMarcasProdResponse = await Common.ObtenerMarcasProducto();

            // Validar si el token esta vencido
            var session = ValidarSesion(objMarcasProdResponse);
            if (session != null)
            {
                return session;
            }

            if (!RespuestaServicio.RespuestaValida(objMarcasProdResponse))
                return ErrorView("No se pudieron cargar las marcas");

            var marcas = objMarcasProdResponse.Body;

            ViewBag.Marcas = marcas;

            return View();
        }

        public ActionResult Categorias()
        {
            ViewBag.MenuActivo = "mnucategorias";
            return View();
        }

        public ActionResult Especificaciones()
        {
            ViewBag.MenuActivo = "mnuespecificaciones";
            return View();
        }

        public async Task<ActionResult> Persona()
        {
            ViewBag.MenuActivo = "mnupersona";

            var objTiposUsuarioResponse = await Common.ListarTiposUsuario();

            // Validar si el token esta vencido
            var session = ValidarSesion(objTiposUsuarioResponse);
            if(session != null)
            {
                return session;
            }

            if (!RespuestaServicio.RespuestaValida(objTiposUsuarioResponse))
                return ErrorView("No se pudieron cargar los tipos de usuarios");

            var tiposUsuario = objTiposUsuarioResponse.Body;

            ViewBag.TiposUsuario = tiposUsuario;

            return View();
        }

        ActionResult ErrorView(string mensaje)
        {
            ViewBag.Error = mensaje;
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> guardarProducto(ProductoRequest model, IEnumerable<HttpPostedFileBase> imagenes)
        {
            var archivos = new List<HttpPostedFileBase>();

            if (!ModelState.IsValid)
            {
                return Json(new { Ok = false, message = "Datos inválidos" });
            }

            if(imagenes == null || !imagenes.Any())
                return Json(new { Ok = false, message = "Debe subir al menos una imagen" });

            try
            {
                foreach (var imagen in imagenes)
                {
                    if (imagen == null || imagen.ContentLength == 0)
                        continue;

                    string extension = Path.GetExtension(imagen.FileName).ToLower(); //.TrimStart('.')
                    string[] permitidas = { ".jpg", ".jpeg", ".png", ".webp" };
                    const long tamanioMaximo = 2 * 1024 * 1024; //equivale a 2MB

                    if (!permitidas.Contains(extension))
                        return Json(new { Ok = false, message = "Formato no permitido. Formatos permitidos : " + string.Join(", ", permitidas) });

                    if (imagen.ContentLength > tamanioMaximo)
                        return Json(new { Ok = false, message = "La imagen supera el tamaño permitido (2MB)" });

                    archivos.Add(imagen);
                }

                var usuario = Session["oUsuario"] as UsuarioResponse;

                if(usuario == null)
                {
                    return Json(new { Ok = false, redirect = "/Login/Index" });
                }

                model.usuarioRegistra = usuario.nombreUsuario;

                var result = await Common.SubirImagenes(archivos);

                if(result == null || result.Header.CodigoRetorno != 0)
                {
                    return Json(result);
                    /*return Json(new
                    {
                        Ok = false,
                        message = result?.Header?.DescRetorno ?? "Error al subir imágenes"
                    });*/
                }

                model.imagenes = result.Body;

                var response = await Common.RegistrarProducto(model);

                if(response == null || response.Header.CodigoRetorno != 0)
                {
                    await Common.EliminarImagenes(result.Body);

                    return Json(response);

                    /*return Json(new
                    {
                        Ok = false,
                        message = response?.Header?.DescRetorno ?? "No se pudo registrar el producto"
                    });*/
                }

                var session = ValidarSesion(response);

                if(session != null)
                {
                    return Json( new 
                    { 
                        Ok = false,
                        redirect = "/Login/Index"
                    });
                }

                if (response == null)
                {
                    return Json(new
                    {
                        Ok = false,
                        message = "No hubo respuesta del servicio"
                    });
                }
                    
                return Json(new
                {
                    Ok = true,
                    data = response
                });
            }
            catch
            {
                return Json(new
                {
                    Ok = false,
                    message = "Ocurrió un error interno al guardar el producto"
                });
            }
        }

        [HttpPost]
        public async Task<JsonResult> guardarPersona(PersonaRequest model)
        {
            try
            {
                var response = await Common.RegistrarPersona(model);

                var session = ValidarSesion(response);

                if (session != null)
                {
                    return Json(new
                    {
                        Ok = false,
                        redirect = "/Login/Index"
                    });
                }

                if (response == null)
                {
                    return Json(new
                    {
                        Ok = false,
                        message = "No hubo respuesta del servicio"
                    });
                }
                return Json(new
                {
                    Ok = true,
                    data = response
                });
            }
            catch
            {
                return Json(new
                {
                    Ok = false,
                    message = "Ocurrió un error interno al guardar la persona"
                });
            }
        }
    }
}