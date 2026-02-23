using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Entidad.Usuario
{
    public class UsuarioResponse
    {
        public int id { get; set; }
        public string nombreUsuario { get; set; } = string.Empty;
        public string nombre { get; set; } = string.Empty;
        public string apellidos { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
        public string genero { get; set; } = string.Empty;
        public string tipoUsuario { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
    }
}
