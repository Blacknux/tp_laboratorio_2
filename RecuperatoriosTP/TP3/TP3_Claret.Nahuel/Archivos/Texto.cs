using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;





namespace Archivos
{
    public class Texto:IArchivo<string>
    {
        /// <summary>
        /// Rcibe un path y un string de datos y los guarda en un txt
        /// </summary>
        /// <param name="archivo">path para guardar archivo</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns>true si pudo false si no </returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(archivo, true))
                {
                    fileWriter.WriteLine(datos);
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
                
            }
        
        }
        /// <summary>
        /// Lee un archivo de texto y lo asigna a una variable string
        /// </summary>
        /// <param name="archivo">path del archivo a leer</param>
        /// <param name="target">variable donde se guardara el string leido del archivo</param>
        /// <returns>True si pudo leer y asignar, si no false</returns>
        public bool Leer(string archivo, out string target)
        {
            try
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(archivo))
                {
                    target = reader.ReadToEnd();

                }
                return true;

            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }


        }


    }
}
