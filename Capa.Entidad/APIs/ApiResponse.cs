using Capa.Entidad.APIs.Header;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Entidad.APIs
{
    public class ApiResponse<T>
    {
        public DTOHeader Header { get; set; }
        public T Body { get; set; }
    }
}
