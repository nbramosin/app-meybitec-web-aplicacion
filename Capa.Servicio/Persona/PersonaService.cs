using Capa.Entidad;
using Capa.Entidad.APIs;
using Capa.Entidad.APIs.Header;
using Capa.Entidad.Persona;
using Capa.Entidad.Producto;
using Capa.Transversal.Common;
using Capa.Transversal.Helpers;
using Capa.Transversal.ServicioREST;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Servicio.Persona
{
    public class PersonaService : BaseService
    {
        public static async Task<ApiResponse<List<TipoUsuario>>> ListarTiposUsuario(string url)
        {
            var objResponse = new ApiResponse<List<TipoUsuario>>();

            try
            {
                //Obtener el token
                var token = TokenProvider.GetToken();

                if (string.IsNullOrEmpty(token))
                {
                    return SessionExpirada<List<TipoUsuario>>();
                }

                var jsonContent = await RestService.ConsumeServicioGet(url, token);

                if (jsonContent.Resultado == null)
                {
                    objResponse.Header = jsonContent.Header;
                    return objResponse;
                }

                objResponse = JsonConvert.DeserializeObject<ApiResponse<List<TipoUsuario>>>(jsonContent.Resultado);

                if (objResponse?.Header?.CodigoRetorno != 0)
                {
                    DataUtil.EscribirLog("Error : Capa.Servicio -> ListarTiposUsuario() -> "
                        + "CodigoRetorno: " + objResponse.Header.CodigoRetorno + " - "
                        + "DescRetorno: " + objResponse.Header.DescRetorno);
                }
            }
            catch( Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error : Capa.Servicio -> ListarTiposUsuario() -> " + " Message Error : {0} ", ex.Message));
                objResponse.Header = new DTOHeader
                {
                    CodigoRetorno = (int)HeaderEnum.Incorrecto,
                    DescRetorno = "Ocurrió un error al obtener la información del servicio."
                };
            }

            return objResponse;
        }
        public static async Task<ApiResponse<string>> RegistrarPersona(PersonaRequest model, string url)
        {
            var objResponse = new ApiResponse<string>();

            try
            {
                var token = TokenProvider.GetToken();

                if (string.IsNullOrEmpty(token))
                {
                    return SessionExpirada<string>();
                }

                var responseHttp = await RestService.ConsumeServicioPost(url, model, token);

                if (responseHttp.Resultado == null)
                {
                    objResponse.Header = responseHttp.Header;
                    return objResponse;
                }

                objResponse = JsonConvert.DeserializeObject<ApiResponse<string>>(responseHttp.Resultado.ToString());

                if (objResponse?.Header?.CodigoRetorno != 0)
                {
                    DataUtil.EscribirLog("Error : Capa.Servicio -> RegistrarPersona() -> "
                        + "CodigoRetorno: " + objResponse.Header.CodigoRetorno + " - "
                        + "DescRetorno: " + objResponse.Header.DescRetorno);
                }
            }
            catch(Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error : Capa.Servicio -> RegistrarPersona() -> " + " Message Error : {0} ", ex.Message));
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
