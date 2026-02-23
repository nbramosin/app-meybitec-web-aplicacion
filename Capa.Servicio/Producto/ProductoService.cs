using Capa.Entidad;
using Capa.Entidad.APIs;
using Capa.Entidad.APIs.Header;
using Capa.Entidad.Producto;
using Capa.Transversal.Common;
using Capa.Transversal.Helpers;
using Capa.Transversal.ServicioREST;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Servicio.Producto
{
    public class ProductoService : BaseService
    {
        public static async Task<ApiResponse<List<MarcasProducto>>> ObtenerMarcasProducto(string url)
        {
            var objResponse = new ApiResponse<List<MarcasProducto>>();

            try
            {
                var tokenJwt = TokenProvider.GetToken();
                if (string.IsNullOrEmpty(tokenJwt))
                {
                    return SessionExpirada<List<MarcasProducto>>();
                }

                var jsonContent = await RestService.ConsumeServicioGet(url, tokenJwt);

                if (jsonContent.Resultado == null)
                {
                    objResponse.Header = jsonContent.Header;
                    return objResponse;
                }

                objResponse = JsonConvert.DeserializeObject<ApiResponse<List<MarcasProducto>>>(jsonContent.Resultado);

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
        public static async Task<ApiResponse<List<CategoriasProducto>>> ObtenerCategoriasProducto(string url)
        {
            var objResponse = new ApiResponse<List<CategoriasProducto>>();

            try
            {
                var tokenJwt = TokenProvider.GetToken();
                if (string.IsNullOrEmpty(tokenJwt))
                {
                    return SessionExpirada <List<CategoriasProducto>>();
                }

                var jsonContent = await RestService.ConsumeServicioGet(url, tokenJwt);

                if (jsonContent.Resultado == null)
                {
                    objResponse.Header = jsonContent.Header;
                    return objResponse;
                }

                objResponse = JsonConvert.DeserializeObject<ApiResponse<List<CategoriasProducto>>>(jsonContent.Resultado);

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

        public static async Task<ApiResponse<List<ConexionesProducto>>> ObtenerConexionesProducto(string url)
        {
            var objResponse = new ApiResponse<List<ConexionesProducto>>();

            try
            {
                var tokenJwt = TokenProvider.GetToken();
                if (string.IsNullOrEmpty(tokenJwt))
                {
                    return SessionExpirada<List<ConexionesProducto>>();
                }

                var jsonContent = await RestService.ConsumeServicioGet(url, tokenJwt);

                if (jsonContent.Resultado == null)
                {
                    objResponse.Header = jsonContent.Header;
                    return objResponse;
                }

                objResponse = JsonConvert.DeserializeObject<ApiResponse<List<ConexionesProducto>>>(jsonContent.Resultado);

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

        public static async Task<ApiResponse<List<TiposCategoriaProducto>>> ObtenerTiposCategoriaProducto(string url)
        {
            var objResponse = new ApiResponse<List<TiposCategoriaProducto>>();

            try
            {
                var tokenJwt = TokenProvider.GetToken();
                if (string.IsNullOrEmpty(tokenJwt))
                {
                    return SessionExpirada<List<TiposCategoriaProducto>>();
                }

                var jsonContent = await RestService.ConsumeServicioGet(url, tokenJwt);

                if (jsonContent.Resultado == null)
                {
                    objResponse.Header = jsonContent.Header;
                    return objResponse;
                }

                objResponse = JsonConvert.DeserializeObject<ApiResponse<List<TiposCategoriaProducto>>>(jsonContent.Resultado);

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

        public static async Task<ApiResponse<List<LongitudesProducto>>> ObtenerLongitudesProducto(string url)
        {
            var objResponse = new ApiResponse<List<LongitudesProducto>>();

            try
            {
                var tokenJwt = TokenProvider.GetToken();
                if (string.IsNullOrEmpty(tokenJwt))
                {
                    return SessionExpirada<List<LongitudesProducto>>();
                }

                var jsonContent = await RestService.ConsumeServicioGet(url, tokenJwt);

                if (jsonContent.Resultado == null)
                {
                    objResponse.Header = jsonContent.Header;
                    return objResponse;
                }

                objResponse = JsonConvert.DeserializeObject<ApiResponse<List<LongitudesProducto>>>(jsonContent.Resultado);

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
