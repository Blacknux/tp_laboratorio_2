using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public class Instructor:PersonaGimnasio
    {
        Queue<Gimnasio.EClases> _clasesDelDia;
        static Random _random;
         static Instructor()
        {
            _random = new Random();
        }
        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad naciona):base(id,nombre,apellido,dni,naciona)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Devuelve un string protegido con los datos del instructor
        /// </summary>
        /// <returns>datos del instructor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("Clase del dia: "+this._clasesDelDia.ToString());
            //sb.AppendLine(this._random.ToString());
            return sb.ToString();

        }
        /// <summary>
        /// asigna dos clases de manera random a la cola de clases
        /// </summary>
        private void _randomClases()
        {
            Array list = Enum.GetValues(typeof(Gimnasio.EClases));

            this._clasesDelDia.Enqueue((Gimnasio.EClases)list.GetValue(_random.Next(list.Length)));
            this._clasesDelDia.Enqueue((Gimnasio.EClases)list.GetValue(_random.Next(list.Length)));
        }
        /// <summary>
        /// devuelve los datos de als clases del 
        /// </summary>
        /// <returns> un strings con las clases del dia </returns>
        protected override string ParticiparEnClase()
        {
            return "CLASES DEL DÍA: " + (Gimnasio.EClases)this._clasesDelDia.Dequeue()+","+ (Gimnasio.EClases)this._clasesDelDia.Dequeue();
        }

        /// <summary>
        /// hace publicos los datos de MostrarDatos
        /// </summary>
        /// <returns>string con los datos del instructor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// un instructr es igual a una clase si esta esta en su lista de clase del dia
        /// </summary>
        /// <param name="i1">instructor a comparar</param>
        /// <param name="c1">clase a comaparar </param>
        /// <returns>True si el instructor tiene en su list a ala clase o caso contrario false</returns>
        public static bool operator ==(Instructor i1, Gimnasio.EClases c1)
        {
            if (i1._clasesDelDia.Contains(c1))
            {
                return true;
            }
            else
            {
                return false; 
            }
        }

        public static bool operator !=(Instructor i1, Gimnasio.EClases c1)
        {
            return !(i1==c1);
        }

    }
}
