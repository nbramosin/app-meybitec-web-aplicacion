using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Entidad.Enums;

namespace Capa.Entidad.Persona
{
    public class PersonaRequest
    {
        //Datos persona
        public string nombre { get; set; } = string.Empty;
        public string apellidoPaterno { get; set; } = string.Empty;
        public string apellidoMaterno { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
        public int idTipoUsuario { get; set; }
        public Genero genero { get; set; }
        public bool habilitado { get; set; }

        //Login usuario
        public string userName { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
}
