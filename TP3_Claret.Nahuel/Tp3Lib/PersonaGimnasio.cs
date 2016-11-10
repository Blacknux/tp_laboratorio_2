using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 

namespace EntidadesAbstractas
{
    abstract public  class PersonaGimnasio:Persona
    {
        int _identificador;
        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad naciona)
            : base(nombre, apellido, dni, naciona)
        {
            this._identificador = id;
        }

        #region Methods
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("ID: " + this._identificador);
            return sb.ToString(); 
        
        }
        protected abstract string ParticiparEnClase();
        #endregion
        #region Overloads
        public static bool operator ==(PersonaGimnasio p1, PersonaGimnasio p2)
        {
            if (p1.GetType() == p2.GetType() && p1.Dni == p2.Dni && p1._identificador == p2._identificador)
            {
                return true; 
            }
            else 
            {
                return false;
             }
        }

        public static bool operator !=(PersonaGimnasio p1, PersonaGimnasio p2)
        {
            return !(p1 == p2); 
        }

        #endregion
    }
}
