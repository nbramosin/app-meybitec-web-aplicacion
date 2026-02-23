using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Transversal.Common
{
    public static class ConstanteHelper
    {
        public static readonly string _key_User_API = ConfigurationManager.AppSettings["kUsuarioAPI"];
        public static readonly string _key_Clave_API = ConfigurationManager.AppSettings["kClaveAPI"];
        public static readonly string _Key_UrlMarcasProd_API = ConfigurationManager.AppSettings["url_marcasProducto_apiRest"];
        public static readonly string _Key_UrlCatProd_API = ConfigurationManager.AppSettings["url_categoriasProducto_apiRest"];
        public static readonly string _Key_UrlCnxProd_API = ConfigurationManager.AppSettings["url_conexionesProducto_apiRest"];
        public static readonly string _Key_UrlTiposCatProd_API = ConfigurationManager.AppSettings["url_tiposCategoriaProducto_apiRest"];
        public static readonly string _Key_UrlLongProd_API = ConfigurationManager.AppSettings["url_longitudesProducto_apiRest"];
        public static readonly string _Key_UrlRegProd_API = ConfigurationManager.AppSettings["url_registrarProducto_apiRest"];
        public static readonly string _Key_UrlTiposUsuario_API = ConfigurationManager.AppSettings["url_tiposUsuario_apiRest"];
        public static readonly string _Key_UrlRegPerson_API = ConfigurationManager.AppSettings["url_registrarPersona_apiRest"];
        public static readonly string _Key_UrlUsuarioLogout_API = ConfigurationManager.AppSettings["url_usuariologout_apiRest"];
        public static readonly string _Key_UrlImagenProducto_API = ConfigurationManager.AppSettings["url_imagenProducto_apiRest"];
        public static readonly string _Key_UrlEliminarImagen_API = ConfigurationManager.AppSettings["url_eliminarImagen_apiRest"];
    }
}
