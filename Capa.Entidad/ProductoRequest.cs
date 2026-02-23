using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Capa.Entidad
{
    public class ProductoRequest
    {
        //PRODUCTO
        //public string sku { get; set; } = string.Empty;
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public string marcaRef { get; set; } = string.Empty;
        public int idMarca { get; set; }
        public int stock { get; set; }
        public int idCategoria { get; set; }
        public int? idConexion { get; set; }
        public int? idTipoCategoria { get; set; }
        public int? idLongitud { get; set; }
        public decimal precioBase { get; set; }
        public int estadoProd { get; set; } = 1;
        public string usuarioRegistra { get; set; } = string.Empty;
        public string usuarioActualizacion { get; set; } = string.Empty;

        //PRECIO
        public decimal? precioOferta { get; set; }
        public int? descuento { get; set; }
        public DateTime? fechaInicio { get; set; }
        public DateTime? fechaFin { get; set; }

        //IMAGENES SOLO RUTAS
        public List<string> imagenes { get; set; }
    }
}
