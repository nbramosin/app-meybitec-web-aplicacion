using Capa.Entidad;
using Capa.Entidad.APIs;
using Capa.Entidad.APIs.Header;
using Capa.Transversal.Common;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace Capa.Transversal.ServicioREST
{
    public class RestService
    {
        public static async Task<DTOConsumeApiRest> ConsumeServicioGet(string url, string tokenJwt)
        {
            var objResultado = new DTOConsumeApiRest();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    /*AUTENTICATION BASIC DONDE SE LE MANDA USUARIO Y PASSWORD AL SERVICIO REST*/
                    /*string authBasic = Convert.ToBase64String(
                        Encoding.ASCII.GetBytes($"{ConstanteHelper._key_User_API}:{ConstanteHelper._key_Clave_API}"));

                    client.DefaultRequestHeaders
                        .Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization
                        = new AuthenticationHeaderValue("Basic", authBasic);*/

                    /*AUTENTICATIO CON JWT*/
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", tokenJwt);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        objResultado.Header = new DTOHeader
                        {
                            CodigoRetorno = 401,
                            DescRetorno = "Token expirado"
                        };

                        return objResultado;
                    }
                        
                    objResultado.Resultado = await response.Content.ReadAsStringAsync();

                    objResultado.Header = new DTOHeader
                    {
                        CodigoRetorno = response.IsSuccessStatusCode ? 0 : (int)response.StatusCode,
                        DescRetorno = response.IsSuccessStatusCode ? "OK" : objResultado.Resultado
                    };
                }
                catch (HttpRequestException ex)
                {
                    DataUtil.EscribirLog("Error HttpRequestException : Capa.Transversal -> ConsumeServicioGet() - " + url + " - " + ex.Message);
                    objResultado.Header = new DTOHeader
                    {
                        CodigoRetorno = (int)HeaderEnum.Incorrecto,
                        DescRetorno = "Error de comunicación con el servicio."
                    };
                }
                catch (Exception ex)
                {
                    DataUtil.EscribirLog("Error Exception : Capa.Transversal -> ConsumeServicioGet() - " + url + " - " + ex.Message);
                    objResultado.Header = new DTOHeader 
                    { 
                        CodigoRetorno = (int)HeaderEnum.Incorrecto, 
                        DescRetorno = "Ocurrió un error inesperado al consumir el servicio." 
                    };
                }
            }

            return objResultado;
        }

        public static async Task<DTOConsumeApiRest> ConsumeServicioPost<T>(string url, T obj, string token)
        {
            var objResultado = new DTOConsumeApiRest();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", token);
                    }

                    var requestMessage = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(url)
                    };

                    if(obj is HttpContent content)
                    {
                        requestMessage.Content = content;
                    }
                    else
                    {
                        requestMessage.Content = new StringContent(
                            JsonConvert.SerializeObject(obj),
                            Encoding.UTF8,
                            "application/json");
                    }
                    
                    HttpResponseMessage response = await client.SendAsync(requestMessage);

                    objResultado.Resultado = await response.Content.ReadAsStringAsync();
                    
                    objResultado.Header = new DTOHeader
                    {
                        CodigoRetorno = response.IsSuccessStatusCode ? 0 : (int)response.StatusCode,
                        DescRetorno = response.IsSuccessStatusCode ? "OK" : objResultado.Resultado
                    };
                }
            }
            catch (HttpRequestException ex)
            {
                DataUtil.EscribirLog("Error HttpRequestException : Capa.Transversal -> ConsumeServicioPost() - " + url + " - " + ex.Message);
                objResultado.Header = new DTOHeader
                {
                    CodigoRetorno = (int)HeaderEnum.Incorrecto,
                    DescRetorno = "Error de comunicación con el servicio."
                };
            }
            catch (Exception ex)
            {
                DataUtil.EscribirLog("Error Exception : Capa.Transversal -> ConsumeServicioPost() - " + url + " - " + ex.Message);
                objResultado.Header = new DTOHeader
                {
                    CodigoRetorno = (int)HeaderEnum.Incorrecto,
                    DescRetorno = "Ocurrió un error al intentar enviar la información a insertar."
                };
            }

            return objResultado;
        }
    }
}
