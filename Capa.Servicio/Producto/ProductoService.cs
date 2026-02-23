using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Capa.Entidad.APIs;
using Capa.Entidad.Producto;
using Capa.Transversal.Common;
using Capa.Entidad.APIs.Header;
using Capa.Transversal.Helpers;
using Capa.Transversal.ServicioREST;

namespace Capa.Servicio.Producto
{
    public class ProductoService : BaseService
    {
        public static async Task<ApiResponse<List<Marca>>> ObtenerMarcasProducto(string url)
        {
            var objResponse = new ApiResponse<List<Marca>>();

            try
            {
                var tokenJwt = TokenProvider.GetToken();
                if (string.IsNullOrEmpty(tokenJwt))
                {
                    return SessionExpirada<List<Marca>>();
                }

                var jsonContent = await RestService.ConsumeServicioGet(url, tokenJwt);

                if (jsonContent.Resultado == null)
                {
                    objResponse.Header = jsonContent.Header;
                    return objResponse;
                }

                objResponse = JsonConvert.DeserializeObject<ApiResponse<List<Marca>>>(jsonContent.Resultado);

                if (objResponse?.Header?.CodigoRetorno != 0)
                {
                    DataUtil.EscribirLog("Error : Capa.Servicio -> ObtenerMarcasProducto() -> "
                        + "CodigoRetorno: " + objResponse.Header.CodigoRetorno + " - "
                        + "DescRetorno: " + objResponse.Header.DescRetorno);
                }
            }
            catch (WebException we)
            {
                DataUtil.EscribirLog(string.Format("Error : Capa.Servicio -> ObtenerMarcasProducto() -> " + " Message Error : {0} ", we.Message.ToString()));
                objResponse.Header = new DTOHeader() { CodigoRetorno = (int)HeaderEnum.Incorrecto, DescRetorno = "Ocurrió un error al obtener la información del servicio." };
            }

            return objResponse;
        }
        public static async Task<ApiResponse<List<Categoria>>> ObtenerCategoriasProducto(string url)
        {
            var objResponse = new ApiResponse<List<Categoria>>();

            try
            {
                var tokenJwt = TokenProvider.GetToken();
                if (string.IsNullOrEmpty(tokenJwt))
                {
                    return SessionExpirada <List<Categoria>>();
                }

                var jsonContent = await RestService.ConsumeServicioGet(url, tokenJwt);

                if (jsonContent.Resultado == null)
                {
                    objResponse.Header = jsonContent.Header;
                    return objResponse;
                }

                objResponse = JsonConvert.DeserializeObject<ApiResponse<List<Categoria>>>(jsonContent.Resultado);

                if (objResponse?.Header?.CodigoRetorno != 0)
                {
                    DataUtil.EscribirLog("Error : Capa.Servicio -> ObtenerCategoriasProducto() -> "
                        + "CodigoRetorno: " + objResponse.Header.CodigoRetorno + " - "
                        + "DescRetorno: " + objResponse.Header.DescRetorno);
                }
            }
            catch (WebException we)
            {
                DataUtil.EscribirLog(string.Format("Error : Capa.Servicio -> ObtenerCategoriasProducto() -> " + " Message Error : {0} ", we.Message.ToString()));
                objResponse.Header = new DTOHeader() { CodigoRetorno = (int)HeaderEnum.Incorrecto, DescRetorno = "Ocurrió un error al obtener la información del servicio." };
            }

            return objResponse;
        }

        public static async Task<ApiResponse<List<Conexion>>> ObtenerConexionesProducto(string url)
        {
            var objResponse = new ApiResponse<List<Conexion>>();

            try
            {
                var tokenJwt = TokenProvider.GetToken();
                if (string.IsNullOrEmpty(tokenJwt))
                {
                    return SessionExpirada<List<Conexion>>();
                }

                var jsonContent = await RestService.ConsumeServicioGet(url, tokenJwt);

                if (jsonContent.Resultado == null)
                {
                    objResponse.Header = jsonContent.Header;
                    return objResponse;
                }

                objResponse = JsonConvert.DeserializeObject<ApiResponse<List<Conexion>>>(jsonContent.Resultado);

                if (objResponse?.Header?.CodigoRetorno != 0)
                {
                    DataUtil.EscribirLog("Error : Capa.Servicio -> ObtenerConexionesProducto() -> "
                        + "CodigoRetorno: " + objResponse.Header.CodigoRetorno + " - "
                        + "DescRetorno: " + objResponse.Header.DescRetorno);
                }
            }
            catch (WebException we)
            {
                DataUtil.EscribirLog(string.Format("Error : Capa.Servicio -> ObtenerConexionesProducto() -> " + " Message Error : {0} ", we.Message.ToString()));
                objResponse.Header = new DTOHeader() { CodigoRetorno = (int)HeaderEnum.Incorrecto, DescRetorno = "Ocurrió un error al obtener la información del servicio." };
            }

            return objResponse;
        }

        public static async Task<ApiResponse<List<TipoCategoria>>> ObtenerTiposCategoriaProducto(string url)
        {
            var objResponse = new ApiResponse<List<TipoCategoria>>();

            try
            {
                var tokenJwt = TokenProvider.GetToken();
                if (string.IsNullOrEmpty(tokenJwt))
                {
                    return SessionExpirada<List<TipoCategoria>>();
                }

                var jsonContent = await RestService.ConsumeServicioGet(url, tokenJwt);

                if (jsonContent.Resultado == null)
                {
                    objResponse.Header = jsonContent.Header;
                    return objResponse;
                }

                objResponse = JsonConvert.DeserializeObject<ApiResponse<List<TipoCategoria>>>(jsonContent.Resultado);

                if (objResponse?.Header?.CodigoRetorno != 0)
                {
                    DataUtil.EscribirLog("Error : Capa.Servicio -> ObtenerTiposCategoriaProducto() -> "
                        + "CodigoRetorno: " + objResponse.Header.CodigoRetorno + " - "
                        + "DescRetorno: " + objResponse.Header.DescRetorno);
                }
            }
            catch (WebException we)
            {
                DataUtil.EscribirLog(string.Format("Error : Capa.Servicio -> ObtenerTiposCategoriaProducto() -> " + " Message Error : {0} ", we.Message.ToString()));
                objResponse.Header = new DTOHeader() { CodigoRetorno = (int)HeaderEnum.Incorrecto, DescRetorno = "Ocurrió un error al obtener la información del servicio." };
            }

            return objResponse;
        }

        public static async Task<ApiResponse<List<Longitud>>> ObtenerLongitudesProducto(string url)
        {
            var objResponse = new ApiResponse<List<Longitud>>();

            try
            {
                var tokenJwt = TokenProvider.GetToken();
                if (string.IsNullOrEmpty(tokenJwt))
                {
                    return SessionExpirada<List<Longitud>>();
                }

                var jsonContent = await RestService.ConsumeServicioGet(url, tokenJwt);

                if (jsonContent.Resultado == null)
                {
                    objResponse.Header = jsonContent.Header;
                    return objResponse;
                }

                objResponse = JsonConvert.DeserializeObject<ApiResponse<List<Longitud>>>(jsonContent.Resultado);

                if (objResponse?.Header?.CodigoRetorno != 0)
                {
                    DataUtil.EscribirLog("Error : Capa.Servicio -> ObtenerLongitudesProducto() -> "
                        + "CodigoRetorno: " + objResponse.Header.CodigoRetorno + " - "
                        + "DescRetorno: " + objResponse.Header.DescRetorno);
                }
            }
            catch (WebException we)
            {
                DataUtil.EscribirLog(string.Format("Error : Capa.Servicio -> ObtenerLongitudesProducto() -> " + " Message Error : {0} ", we.Message.ToString()));
                objResponse.Header = new DTOHeader() { CodigoRetorno = (int)HeaderEnum.Incorrecto, DescRetorno = "Ocurrió un error al obtener la información del servicio." };
            }

            return objResponse;
        }

        public static async Task<ApiResponse<ProductoResponse>> RegistrarProducto(ProductoRequest objRequest, string url)
        {
            var objResponse = new ApiResponse<ProductoResponse>();

            try
            {
                var tokenJwt = TokenProvider.GetToken();
                if (string.IsNullOrEmpty(tokenJwt))
                {
                    return SessionExpirada<ProductoResponse>();
                }

                var responseHttp = await RestService.ConsumeServicioPost(url, objRequest, tokenJwt);

                if (responseHttp.Resultado == null)
                {
                    objResponse.Header = responseHttp.Header;
                    return objResponse;
                }

                objResponse = JsonConvert.DeserializeObject<ApiResponse<ProductoResponse>>(responseHttp.Resultado);

                if (objResponse?.Header?.CodigoRetorno != 0)
                {
                    DataUtil.EscribirLog("Error : Capa.Servicio -> RegistrarProducto() -> "
                        + "CodigoRetorno: " + objResponse.Header.CodigoRetorno + " - "
                        + "DescRetorno: " + objResponse.Header.DescRetorno);
                }
            }
            catch (WebException we)
            {
                DataUtil.EscribirLog(string.Format("Error : Capa.Servicio -> RegistrarProducto() -> " + " Message Error : {0} ", we.Message.ToString()));
                objResponse.Header = new DTOHeader
                {
                    CodigoRetorno = (int)HeaderEnum.Incorrecto,
                    DescRetorno = "Ocurrió un error al obtener la información del servicio."
                };
            }

            return objResponse;
        }
    }
}
