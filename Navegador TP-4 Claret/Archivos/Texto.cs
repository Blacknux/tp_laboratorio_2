using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        string archivo;
        public Texto(string archivo)
        {
            this.archivo = archivo;
        }

        /// <summary>
        /// Realiza la escritura de un archivo .dat que contendra el historial de las paginas a las que se ingreso
        /// </summary>
        /// <param name="dato">nuevo string para agregar al archivo</param>
        /// <returns>True si esta ok o lanza una excepcion si no puede guardar </returns>
        public bool guardar(string dato)
        {
            try
            {
                StreamWriter sw = new StreamWriter("./" + archivo, true);
                sw.WriteLine(dato.ToString(), Encoding.UTF8);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "ERROR AL GUARDAR");
            }
        }

        /// <summary>
        /// Lee el archivo .dat y lo guarda en una lista de strings la cuals e pasa por parametro anteponiendo out 
        /// </summary>
        /// <param name="dato">lista de strings donde almacenar lo leido desde el archivo</param>
        /// <returns></returns>
        public bool leer(out List<string> dato)
        {
            dato = new List<string>();
            try
            {
                StreamReader reader = new StreamReader("./" + archivo, Encoding.UTF8);
                while (!reader.EndOfStream)
                {
                    dato.Add(reader.ReadLine());
                }
                reader.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "ERROR AL LEER");
            }
        }
    }
}