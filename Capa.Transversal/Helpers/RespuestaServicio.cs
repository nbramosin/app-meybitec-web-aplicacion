using Capa.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Transversal.Helpers
{
    public class RespuestaServicio
    {
        public static bool RespuestaValida(dynamic response)
        {
            return response != null &&
                   response.Header.CodigoRetorno == (int)HeaderEnum.Correcto;
        }
    }
}
