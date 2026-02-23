using Capa.Entidad;
using Capa.Entidad.APIs;
using Capa.Entidad.APIs.Header;
using Capa.Transversal.Common;
using Capa.Transversal.Helpers;
using Capa.Transversal.ServicioREST;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Capa.Servicio.File
{
    public class FileService : BaseService
    {
        public static async Task<ApiResponse<List<string>>> SubirImagenes(IEnumerable<HttpPostedFileBase> imagenes, string url)
        {
            var objResponse = new ApiResponse<List<string>>();
            try
            {
                var tokenJwt = TokenProvider.GetToken();
                if (string.IsNullOrEmpty(tokenJwt))
                {
                    return SessionExpirada<List<string>>();
                }

                var content = new MultipartFormDataContent();

                foreach (var imagen in imagenes)
                {
                    if (imagen == null || imagen.ContentLength == 0)
                        continue;

                    var streamContent = new StreamContent(imagen.InputStream);

                    streamContent.Headers.ContentType =
                        new System.Net.Http.Headers.MediaTypeHeaderValue(imagen.ContentType);

                    content.Add(streamContent, "imagenes", imagen.FileName);
                }

                var responseHttp = await RestService.ConsumeServicioPost(url, content, tokenJwt);


                if (responseHttp.Resultado == null)
                {
                    objResponse.Header = responseHttp.Header;
                    return objResponse;
                }

                objResponse = JsonConvert.DeserializeObject<ApiResponse<List<string>>>(responseHttp.Resultado);

                if (objResponse?.Header?.CodigoRetorno != 0)
                {
                    DataUtil.EscribirLog("Error : Capa.Servicio -> subirImagenes() -> "
                        + "CodigoRetorno: " + objResponse.Header.CodigoRetorno + " - "
                        + "DescRetorno: " + objResponse.Header.DescRetorno);
                }
            }
            catch (WebException we)
            {
                DataUtil.EscribirLog(string.Format("Error : Capa.Servicio -> subirImagenes() -> " + " Message Error : {0} ", we.Message.ToString()));
                objResponse.Header = new DTOHeader
                {
                    CodigoRetorno = (int)HeaderEnum.Incorrecto,
                    DescRetorno = "Ocurrió un error al obtener la información del servicio."
                };
            }

            return objResponse;
        }

        public static async Task<ApiResponse<List<string>>> EliminarImagenes(List<string> imagenes, string url)
        {
            var objResponse = new ApiResponse<List<string>>();

            try
            {
                var tokenJwt = TokenProvider.GetToken();
                if (string.IsNullOrEmpty(tokenJwt))
                {
                    return SessionExpirada<List<string>>();
                }

                var responseHttp = await RestService.ConsumeServicioPost(url, imagenes, tokenJwt);

                if (responseHttp.Resultado == null)
                {
                    objResponse.Header = responseHttp.Header;
                    return objResponse;
                }

                objResponse = JsonConvert.DeserializeObject<ApiResponse<List<string>>>(responseHttp.Resultado);

                if (objResponse?.Header?.CodigoRetorno != 0)
                {
                    DataUtil.EscribirLog("Error : Capa.Servicio -> EliminarImagenes() -> "
                        + "CodigoRetorno: " + objResponse.Header.CodigoRetorno + " - "
                        + "DescRetorno: " + objResponse.Header.DescRetorno);
                }
            }
            catch (WebException we)
            {
                DataUtil.EscribirLog(string.Format("Error : Capa.Servicio -> EliminarImagenes() -> " + " Message Error : {0} ", we.Message.ToString()));
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
