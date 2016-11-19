using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {
        /// <summary>
        /// datos a guardar serializados en un xml en el path indicado
        /// </summary>
        /// <param name="archivo">path </param>
        /// <param name="datos">datos a serializar </param>
        /// <returns>True si pudo serializar</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer serial = new XmlSerializer(typeof(T));
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    serial.Serialize(writer, datos);
                    writer.Close();

                }
                //XmlSerializer serializer = new XmlSerializer(typeof(T));
                //TextWriter writer = new StreamWriter(archivo);
                //serializer.Serialize(writer, datos);
                //writer.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e); 
            }
        
        }

        /// <summary>
        /// lee un archivo serializado y lo carga en target 
        /// </summary>
        /// <param name="archivo">path del archivo a leer</param>
        /// <param name="target">lugar donde guardar los datos</param>
        /// <returns>True si pudo serializar</returns>
        public bool Leer(string archivo, out T target)
        {

            try
            {
                XmlSerializer serial = new XmlSerializer(typeof(T));
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    target = (T)serial.Deserialize(reader);
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
