using Capa.Entidad.APIs;
using Capa.Entidad.APIs.Header;
using Capa.Entidad.Autorizacion;
using Capa.Entidad.Persona;
using Capa.Entidad.Usuario;
using Capa.Transversal.Common;
using Capa.Transversal.ServicioREST;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Servicio.Autorizacion
{
    public class AuthService
    {
        private readonly RestService _restService;

        public AuthService()
        {
            _restService = new RestService();
        }
        public static async Task<ApiResponse<Token>> Login(UsuarioRequest model)
        {
            ApiResponse<Token> objResponse = new ApiResponse<Token>();

            try
            {
                var responseHttp = await RestService.ConsumeServicioPost(
                    ConstanteHelper._Key_UrlUsuarioLogout_API, 
                    model, 
                    null
                );

                objResponse = JsonConvert.DeserializeObject<ApiResponse<Token>>(responseHttp.Resultado.ToString());

                if (objResponse.Header.CodigoRetorno != 0)
                {
                    DataUtil.EscribirLog("Error : Capa.Servicio -> Logout() -> "
                        + "CodigoRetorno: " + objResponse.Header.CodigoRetorno + " - "
                        + "DescRetorno: " + objResponse.Header.DescRetorno);
                }
            }
            catch (Exception ex)
            {
                DataUtil.EscribirLog(string.Format("Error : Capa.Servicio -> Logout() -> " + " Message Error : {0} ", ex.Message));
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
