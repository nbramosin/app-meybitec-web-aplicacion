using Capa.Entidad.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Entidad.Autorizacion
{
    public class Token
    {
        public string token { get; set; } = string.Empty;
        public UsuarioResponse usuario { get; set; }
    }
}
