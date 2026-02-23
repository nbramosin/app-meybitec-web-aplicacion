using Capa.Entidad;
using Capa.Entidad.APIs;
using Capa.Entidad.Autorizacion;
using Capa.Entidad.Persona;
using Capa.Entidad.Producto;
using Capa.Entidad.Usuario;
using Capa.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace Capa.Negocio.Common
{
    public class Common
    {
        public static async Task<ApiResponse<List<Marca>>> ObtenerMarcasProducto()
        {
            var objResponse = new ApiResponse<List<Marca>>();

            try
            {
                objResponse = await Capa.Datos.Common.Common.ObtenerMarcasProducto();
            }
            catch (Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Negocio -> ObtenerMarcasProducto() : {0} ", ex.Message.ToString()));
            }

            return objResponse;
        }
        public static async Task<ApiResponse<List<Categoria>>> ObtenerCategoriasProducto()
        {
            var objResponse = new ApiResponse < List<Categoria>>();
            
            try
            {
                objResponse = await Capa.Datos.Common.Common.ObtenerCategoriasProducto();
            }
            catch(Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Negocio -> ObtenerCategoriaProducto() : {0} ", ex.Message.ToString()));
            }

            return objResponse;
        }

        public static async Task<ApiResponse<List<Conexion>>> ObtenerConexionesProducto()
        {
            var objResponse = new ApiResponse < List<Conexion>>();

            try
            {
                objResponse = await Capa.Datos.Common.Common.ObtenerConexionesProducto();

            }
            catch(Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Negocio -> ObtenerConexionesProducto() : {0} ", ex.Message.ToString()));
            }

            return objResponse;
        }

        public static async Task<ApiResponse<List<TipoCategoria>>> ObtenerTiposCategoriaProducto()
        {
            var objResponse = new ApiResponse<List<TipoCategoria>>();

            try
            {
                objResponse = await Capa.Datos.Common.Common.ObtenerTiposCategoriaProducto();

            }
            catch (Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Negocio -> ObtenerTiposCategoriaProducto() : {0} ", ex.Message.ToString()));
            }

            return objResponse;
        }

        public static async Task<ApiResponse<List<Longitud>>> ObtenerLongitudesProducto()
        {
            var objResponse = new ApiResponse<List<Longitud>>();

            try
            {
                objResponse = await Capa.Datos.Common.Common.ObtenerLongitudesProducto();

            }
            catch (Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Negocio -> ObtenerLongitudesProducto() : {0} ", ex.Message.ToString()));
            }

            return objResponse;
        }

        public static async Task<ApiResponse<ProductoResponse>> RegistrarProducto(ProductoRequest objRequest)
        {
            var objResponse = new ApiResponse < ProductoResponse>();

            try
            {
                objResponse = await Capa.Datos.Common.Common.RegistrarProducto(objRequest);

            }
            catch (Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Negocio -> RegistrarProducto() : {0} ", ex.Message.ToString()));
            }

            return objResponse;
        }

        public static async Task<ApiResponse<List<TipoUsuario>>> ListarTiposUsuario()
        {
            var objResponse = new ApiResponse<List<TipoUsuario>>();

            try
            {
                objResponse = await Capa.Datos.Common.Common.ListarTiposUsuario();
            }
            catch (Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Negocio -> ListarTiposUsuario() : {0} ", ex.Message.ToString()));
            }

            return objResponse;
        }

        public static async Task<ApiResponse<string>> RegistrarPersona (PersonaRequest model)
        {
            var apiResponse = new ApiResponse<string>();

            try
            {
                apiResponse = await Capa.Datos.Common.Common.RegistrarPersona(model);

            }catch(Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Negocio -> RegistrarPersona() : {0} ", ex.Message.ToString()));
            }

            return apiResponse;
        }

        public static async Task<ApiResponse<Token>> Login(UsuarioRequest request)
        {
            var apiResponse = new ApiResponse<Token>();

            try
            {
                apiResponse = await Capa.Datos.Common.Common.Login(request);

            }
            catch (Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Negocio -> Logout() : {0} ", ex.Message.ToString()));
            }

            return apiResponse;
        }

        public static async Task<ApiResponse<List<string>>> SubirImagenes(IEnumerable<HttpPostedFileBase> imagenes)
        {
            var apiResponse = new ApiResponse<List<string>>();
            try
            {
                apiResponse = await Capa.Datos.Common.Common.SubirImagenes(imagenes);
            }
            catch(Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Negocio -> SubirImagenes() : {0} ", ex.Message.ToString()));
            }

            return apiResponse;
        }

        public static async Task<ApiResponse<List<string>>> EliminarImagenes(List<string> imagenes)
        {
            var apiResponse = new ApiResponse<List<string>>();
            try
            {
                apiResponse = await Capa.Datos.Common.Common.EliminarImagenes(imagenes);
            }
            catch (Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error: Capa.Negocio -> EliminarImagenes() : {0} ", ex.Message.ToString()));
            }

            return apiResponse;
        }
    }
}
