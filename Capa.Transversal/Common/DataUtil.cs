using System;
using System.IO;
using System.Configuration;
using System.Globalization;

namespace Capa.Transversal.Common
{
    public class DataUtil
    {
        public static bool EscribirLog(string cadena)
        {

            string filename = string.Concat("Log-", DateTime.Now.ToString("ddMMyyyy", CultureInfo.InvariantCulture), ".txt");
            string path = ConfigurationManager.AppSettings["RutaLogApiGet"].ToString();
            string RutaArchivo = string.Concat(path, @"\", filename);
            cadena = string.Concat(DateTime.Now.ToString(), " --> ", cadena);
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);

                    if (!File.Exists(RutaArchivo))
                    {
                        File.Create(RutaArchivo).Dispose();
                        File.AppendAllText(RutaArchivo, cadena + Environment.NewLine);

                    }
                    else
                    {
                        File.AppendAllText(RutaArchivo, cadena + Environment.NewLine);
                    }
                }
                else
                {
                    if (!File.Exists(RutaArchivo))
                    {
                        File.Create(RutaArchivo).Dispose();
                        File.AppendAllText(RutaArchivo, cadena + Environment.NewLine);

                    }
                    else
                    {
                        File.AppendAllText(RutaArchivo, cadena + Environment.NewLine);

                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
