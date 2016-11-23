using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 

namespace EntidadesAbstractas
{
    abstract public  class PersonaGimnasio:Persona
    {
        #region Atributo
        private int _identificador;
        #endregion
        #region constructor 
        public PersonaGimnasio() { }

                public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad naciona)
                    : base(nombre, apellido, dni, naciona)
                {
                    this._identificador = id;
                }
        #endregion
                public int Identificador { get { return this._identificador; } set { this._identificador = value; } }
                
                // public string Apellido{ get; set; }
                // public ENacionalidad Nacionalidad { get; set; }
                // public int Dni { get; set; }

        #region Methods
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("CARNET NUMERO: " + this._identificador);
            return sb.ToString(); 
        
        }
        protected abstract string ParticiparEnClase();
        #endregion
        #region Overloads
        public static bool operator ==(PersonaGimnasio p1, PersonaGimnasio p2)
        {
            if (!object.Equals(p1, null) && !object.Equals(p2, null) && (p1._identificador == p2._identificador || p1.Dni == p2.Dni))
                return true;
            else return false;
        }
        public static bool operator !=(PersonaGimnasio p1, PersonaGimnasio p2)
        { 
            return !(p1 == p2); 
        }
        public override bool Equals(object obj)
        {
            return (this.GetType() == obj.GetType());
        }


        
        #endregion
    }
}
