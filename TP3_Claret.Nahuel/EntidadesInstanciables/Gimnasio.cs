using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.Xml.Serialization;
using EntidadesAbstractas;


namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Instructor))]

    [XmlInclude(typeof(Persona))]

       
    public class Gimnasio
    {
        
        List<Alumno> _alumnos; 
        List<Instructor> _instructores;
        List<Jornada> _jornada;
        public enum EClases
        {
            CrossFit,
            Natacion,
            Pilates,
            Yoga
        }


        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }

        #region propertys
        public Jornada this[int i ] 
        {
            get
            {
                return this._jornada[i];
            }
        }
        #endregion

        #region overrides
        /// <summary>
        /// override de igualacion un alumno es iguala  un gimnasio si esta en su lista de alumnos
        /// </summary>
        /// <param name="g1">gimnasio a comparar </param>
        /// <param name="a1">alumno a comparar </param>
        /// <returns>True si a1 esta en la lista de alumnos de g1</returns>
        public static bool operator ==(Gimnasio g1, Alumno a1)
        {

            try
            {
                foreach (Alumno item in g1._alumnos)
                {

                    if (item == a1)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// override de no igualacion un alumno no  es igual a  un gimnasio si no esta en su lista de alumnos
        /// </summary>
        /// <param name="g1">gimnasio a comparar </param>
        /// <param name="a1">alumno a comparar </param>
        /// <returns>false si a1 esta en la lista de alumnos de g1</returns>
        public static bool operator !=(Gimnasio g1, Alumno a1)
        {
            return !(g1 == a1);
        }

        // <summary>
        /// override de igualacion, un instructor es iguala  un gimnasio si esta en su lista de instructores
        /// </summary>
        /// <param name="g1">gimnasio a comparar </param>
        /// <param name="i1">instructor a comparar </param>
        /// <returns>True si i1 esta en la lista de instructores de g1</returns>
        public static bool operator ==(Gimnasio g1, Instructor i1)
        {
            foreach (Instructor i in g1._instructores) { 
            if (i == i1)
            {
                return true;
            }
            
            }
            return false;
        }


        public static bool operator !=(Gimnasio g1, Instructor i1)
        {
            return !(g1 == i1);
        }

        // <summary>
        /// override de igualacion, una clases es igual a  un gimnasio si esta en su lista de alumnos
        /// </summary>
        /// <param name="g1">gimnasio a comparar </param>
        /// <param name="clase">clase a comparar </param>
        /// <returns>True si clase esta en la lista de clases de g1</returns>

        public static Instructor operator ==(Gimnasio g, Gimnasio.EClases clase)
        {
            foreach (Instructor b in g._instructores)
            {
                if (b == clase)
                {
                    return b;
                }
            }
            throw new SinInstructorException();
        }

        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            foreach (Instructor a in g._instructores)
            {
                if (a != clase)
                {
                    return a;
                }
            }
            throw new SinInstructorException();
        }

        /// <summary>
        /// si el alumno no es igual al gym entonces lo agrega
        /// </summary>
        /// <param name="g2">gimnasio donde agregar el alumno</param>
        /// <param name="a1">alumno a agregar</param>
        /// <returns>un gimnasio con el valor agregado si corresponde</returns>  
        public static Gimnasio operator +(Gimnasio g2, Alumno a1)
        {
            if (g2 != a1)
            {
                g2._alumnos.Add(a1);
            }
            return g2;
        }

        /// <summary>
        /// si el Instructor no es igual al gym entonces lo agrega
        /// </summary>
        /// <param name="g2">gimnasio donde agregar el alumno</param>
        /// <param name="i">Instructor a agregar</param>
        /// <returns>un gimnasio con el valor agregado si corresponde</returns>
        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            for (int a = 0; a < g._instructores.Count; a++)
            {
                if (g._instructores[a] == i)
                {
                    break;
                }
            }
            g._instructores.Add(i);
            return g;
        }
        /// <summary>
        /// si el clase no es igual al gym entonces lo agrega
        /// </summary>
        /// <param name="g2">gimnasio donde agregar el alumno</param>
        /// <param name="clase">clase a agregar</param>
        /// <returns>un gimnasio con el valor agregado si corresponde</returns>
        public static Gimnasio operator +(Gimnasio g1,EClases clase)
        {
            Jornada jornada = new Jornada(clase, g1 == clase);
            foreach (Alumno a1 in g1._alumnos)
            {
                if ( a1 == clase )
                {
                    jornada += a1;
                }
            }
            g1._jornada.Add(jornada);
            return g1;
        }

        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }
        

        #endregion
        #region Methods
        /// <summary>
        /// retorna  todos los datos del gimnasio
        /// </summary>
        /// <param name="gym1">gimnasio a mostrar</param>
        /// <returns>string con los datos del gimnasio</returns>
        protected static string MostrarDatos(Gimnasio gym1)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada a in gym1._jornada)
            {
                sb.AppendLine(a.ToString());
                sb.AppendLine("<-------------------------------->");
            }

            return sb.ToString();
        }
        /// <summary>
        /// guarda la informacion de un gimnasio en un Xml
        /// </summary>
        /// <param name="gim">gimnasio a serializar</param>
        /// <returns>True si no fallo, una execpcion si no puede guardar </returns>
        public static bool Guardar(Gimnasio gim)
        {
            try
            {
            
            Console.WriteLine("XML");
            Xml<Gimnasio> xml = new Xml<Gimnasio>();
            xml.Guardar("Gimnasio.xml", gim);
            return true;
            }
            catch( Exception e)
            {
            throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// leer la informacion de un gimnasio de un xml
        /// </summary>
        /// <param name="gim">gimnasio en el que se volcara la informacion deserializada</param>
        /// <returns>un gimnasio con los datos del xml</returns>
        public static Gimnasio Leer(Gimnasio gim)
        {
            try
            {

                Xml<Gimnasio> xml = new Xml<Gimnasio>();
                xml.Leer("Gimasio.xml", out gim);
                return gim;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }


        #endregion

    }
}
