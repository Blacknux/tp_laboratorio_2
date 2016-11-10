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


        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("Clase del dia: "+this._clasesDelDia.ToString());
            //sb.AppendLine(this._random.ToString());
            return sb.ToString();

        }

        private void _randomClases()
        {
            Array list = Enum.GetValues(typeof(Gimnasio.EClases));

            this._clasesDelDia.Enqueue((Gimnasio.EClases)list.GetValue(_random.Next(list.Length)));
            this._clasesDelDia.Enqueue((Gimnasio.EClases)list.GetValue(_random.Next(list.Length)));
        }

        protected override string ParticiparEnClase()
        {
            return "CLASES DEL DÍA: " + this._clasesDelDia;
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

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
