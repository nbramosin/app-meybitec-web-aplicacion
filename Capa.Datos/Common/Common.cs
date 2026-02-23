
using System;
using System.Web;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capa.Entidad;
using Capa.Transversal.Common;
using Capa.Entidad.APIs;
using Capa.Entidad.Producto;
using Capa.Entidad.Persona;
using Capa.Servicio.Persona;
using Capa.Entidad.Usuario;
using Capa.Servicio.Autorizacion;
using Capa.Entidad.Autorizacion;
using Capa.Servicio.Producto;
using Capa.Servicio.File;

namespace Capa.Datos.Common
{
    public class Common
    {
        public static async Task<ApiResponse<List<MarcasProducto>>> ObtenerMarcasProducto()
        {
            var objResponse = new ApiResponse<List<MarcasProducto>>();

            try
            {
                objResponse = await ProductoService.ObtenerMarcasProducto(ConstanteHelper._Key_UrlMarcasProd_API);
                var responseLog = Newtonsoft.Json.JsonConvert.SerializeObject(objResponse);
                DataUtil.EscribirLog(string.Format("Info: Capa Datos -> Response ObtenerMarcasProducto() : {0} ", responseLog));
            }
            catch (Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Datos -> ObtenerMarcasProducto() : {0} ", ex.Message.ToString()));
            }

            return objResponse;
        }
        public static async Task<ApiResponse<List<CategoriasProducto>>> ObtenerCategoriasProducto()
        {
            var objResponse = new ApiResponse<List<CategoriasProducto>>();

            try
            {
                objResponse = await ProductoService.ObtenerCategoriasProducto(ConstanteHelper._Key_UrlCatProd_API);
                var responseLog = Newtonsoft.Json.JsonConvert.SerializeObject(objResponse);
                DataUtil.EscribirLog(string.Format("Info: Capa Datos -> Response ObtenerCategoriasProducto() : {0} ", responseLog));
            }
            catch(Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Datos -> ObtenerCategoriasProducto() : {0} ", ex.Message.ToString()));
            }

            return objResponse;
        }

        public static async Task<ApiResponse<List<ConexionesProducto>>> ObtenerConexionesProducto()
        {
            var objResponse =  new ApiResponse<List<ConexionesProducto>>();

            try
            {
                objResponse = await ProductoService.ObtenerConexionesProducto(ConstanteHelper._Key_UrlCnxProd_API);
                var responseLog = Newtonsoft.Json.JsonConvert.SerializeObject(objResponse);
                DataUtil.EscribirLog(string.Format("Info: Capa Datos -> Response ObtenerConexionesProducto() : {0} ", responseLog));
            }
            catch (Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Datos -> ObtenerConexionesProducto() : {0} ", ex.Message.ToString()));
            }

            return objResponse;
        }

        public static async Task<ApiResponse<List<TiposCategoriaProducto>>> ObtenerTiposCategoriaProducto()
        {
            var objResponse = new ApiResponse<List<TiposCategoriaProducto>>();

            try
            {
                objResponse = await ProductoService.ObtenerTiposCategoriaProducto(ConstanteHelper._Key_UrlTiposCatProd_API);
                var responseLog = Newtonsoft.Json.JsonConvert.SerializeObject(objResponse);
                DataUtil.EscribirLog(string.Format("Info: Capa Datos -> Response ObtenerTiposCategoriaProducto() : {0} ", responseLog));
            }
            catch (Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Datos -> ObtenerTiposCategoriaProducto() : {0} ", ex.Message.ToString()));
            }

            return objResponse;
        }

        public static async Task<ApiResponse<List<LongitudesProducto>>> ObtenerLongitudesProducto()
        {
            var objResponse = new ApiResponse<List<LongitudesProducto>>();

            try
            {
                objResponse = await ProductoService.ObtenerLongitudesProducto(ConstanteHelper._Key_UrlLongProd_API);
                var responseLog = Newtonsoft.Json.JsonConvert.SerializeObject(objResponse);
                DataUtil.EscribirLog(string.Format("Info: Capa Datos -> Response ObtenerLongitudesProducto() : {0} ", responseLog));
            }
            catch (Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Datos -> ObtenerLongitudesProducto() : {0} ", ex.Message.ToString()));
            }

            return objResponse;
        }

        public static async Task<ApiResponse<ProductoResponse>> RegistrarProducto(ProductoRequest objRequest)
        {
            var objResponse = new ApiResponse<ProductoResponse>();

            try
            {
                objResponse = await ProductoService.RegistrarProducto(objRequest, ConstanteHelper._Key_UrlRegProd_API);
                var responseLog = Newtonsoft.Json.JsonConvert.SerializeObject(objResponse);
                DataUtil.EscribirLog(string.Format("Info: Capa Datos -> Response RegistrarProducto() : {0} ", responseLog));

            }
            catch(Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Datos -> RegistrarProducto() : {0} ", ex.Message.ToString()));
            }

            return objResponse;
        }

        public static async Task<ApiResponse<List<TipoUsuario>>> ListarTiposUsuario()
        {
            var objResponse = new ApiResponse<List<TipoUsuario>>();

            try
            {
                objResponse = await PersonaService.ListarTiposUsuario(ConstanteHelper._Key_UrlTiposUsuario_API);
                var responseLog = Newtonsoft.Json.JsonConvert.SerializeObject(objResponse);
                DataUtil.EscribirLog(string.Format("Info: Capa Datos -> Response ListarTiposUsuario() : {0} ", responseLog));
            }
            catch (Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Datos -> ListarTiposUsuario() : {0} ", ex.Message));
            }

            return objResponse;
        }

        public static async Task<ApiResponse<string>> RegistrarPersona (PersonaRequest model)
        {
            var apiResponse = new ApiResponse<string>();

            try
            {
                apiResponse = await PersonaService.RegistrarPersona(model, ConstanteHelper._Key_UrlRegPerson_API);
                var responseLog = Newtonsoft.Json.JsonConvert.SerializeObject(apiResponse);
                DataUtil.EscribirLog(string.Format("Info: Capa Datos -> Response RegistrarPersona() : {0} ", responseLog));

            }
            catch(Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Datos -> RegistrarPersona() : {0} ", ex.Message.ToString()));
            }

            return apiResponse;
        }

        public static async Task<ApiResponse<Token>> Login(UsuarioRequest request)
        {
            ApiResponse<Token> apiResponse = null;

            try
            {
                apiResponse = await AuthService.Login(request);
                var responseLog = Newtonsoft.Json.JsonConvert.SerializeObject(apiResponse);
                DataUtil.EscribirLog(string.Format("Info: Capa Datos -> Response Logout() : {0} ", responseLog));

            }
            catch (Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Datos -> Logout() : {0} ", ex.Message.ToString()));
            }

            return apiResponse;
        }

        public static async Task<ApiResponse<List<string>>> SubirImagenes (IEnumerable<HttpPostedFileBase> imagenes)
        {
            ApiResponse<List<string>> apiResponse = null;

            try
            {
                apiResponse = await FileService.SubirImagenes(imagenes, ConstanteHelper._Key_UrlImagenProducto_API);

            }
            catch (Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Datos -> SubirImagenes() : {0} ", ex.Message.ToString()));
                var responseLog = Newtonsoft.Json.JsonConvert.SerializeObject(apiResponse);
                DataUtil.EscribirLog(string.Format("Info: Capa Datos -> Response SubirImagenes() : {0} ", responseLog));
            }

            return apiResponse;
        }

        public static async Task<ApiResponse<List<string>>> EliminarImagenes(List<string> imagenes)
        {
            ApiResponse<List<string>> apiResponse = null;

            try
            {
                apiResponse = await FileService.EliminarImagenes(imagenes, ConstanteHelper._Key_UrlEliminarImagen_API);

            }
            catch (Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Datos -> EliminarImagenes() : {0} ", ex.Message.ToString()));
                var responseLog = Newtonsoft.Json.JsonConvert.SerializeObject(apiResponse);
                DataUtil.EscribirLog(string.Format("Info: Capa Datos -> Response EliminarImagenes() : {0} ", responseLog));
            }

            return apiResponse;
        }
    }
}
