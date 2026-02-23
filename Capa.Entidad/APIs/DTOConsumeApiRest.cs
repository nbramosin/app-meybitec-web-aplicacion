using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Entidad.APIs.Header;

namespace Capa.Entidad.APIs
{
    public class DTOConsumeApiRest
    {
        public DTOHeader Header { get; set; }
        public string Resultado { get; set; }
    }
}
