using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Instructor:PersonaGimnasio
    {
        #region Atributos
        Queue<Gimnasio.EClases> _clasesDelDia;
        static Random _random;
        #endregion

        #region Constructores
        static Instructor()
        {
            Instructor._random = new Random();
        }

        public Instructor() { }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad naciona):base(id,nombre,apellido,dni,naciona)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClases();
        }
        #endregion

        public static Random Random
        {
            get { return Instructor._random; }
            set { Instructor._random = value; }
        }
        /// <summary>
        /// Devuelve un string protegido con los datos del instructor
        /// </summary>
        /// <returns>datos del instructor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();

        }
        /// <summary>
        /// asigna dos clases de manera random a la cola de clases
        /// </summary>
        /// //********************************************************************
        private void _randomClases()
        {
            Array list = Enum.GetValues(typeof(Gimnasio.EClases));

            this._clasesDelDia.Enqueue((Gimnasio.EClases)list.GetValue(_random.Next(list.Length)));
            this._clasesDelDia.Enqueue((Gimnasio.EClases)list.GetValue(_random.Next(list.Length)));
        }

        //*********************************************************************************************
        /// <summary>
        /// devuelve los datos de als clases del 
        /// </summary>
        /// <returns> un strings con las clases del dia </returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA:");
            foreach (Gimnasio.EClases clase in this._clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            return sb.ToString();
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
        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {

            bool retorno = false; 
            if (!object.Equals(i, null))
            {
                foreach (Gimnasio.EClases item in i._clasesDelDia)
                {
                    if (item == clase)
                        retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Instructor i1, Gimnasio.EClases c1)
        {
            return !(i1==c1);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }


    }
}
