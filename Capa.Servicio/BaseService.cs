using Capa.Entidad.APIs;
using Capa.Entidad.APIs.Header;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Servicio
{
    public abstract class BaseService
    {
        protected static ApiResponse<T> SessionExpirada<T>()
        {
            return new ApiResponse<T>
            {
                Header = new DTOHeader
                {
                    CodigoRetorno = 401,
                    DescRetorno = "Sesión expirada"
                }
            };
        }
    }
}
