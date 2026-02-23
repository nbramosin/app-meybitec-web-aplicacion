using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Capa.Transversal.Helpers
{
    public abstract class TokenProvider
    {
        public static string GetToken()
        {
            return HttpContext.Current?.Session?["JWT_TOKEN"]?.ToString();
        }
    }
}
