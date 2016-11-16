using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
namespace EntidadesInstanciables
{
    sealed public class Alumno :PersonaGimnasio
    {
        #region Atributos
        EEstadoCuenta _estadoCuenta;
        Gimnasio.EClases _claseQueToma; 
        #endregion

        #region Enumerados
        public enum EEstadoCuenta { AlDia, Deudor, MesPrueba }
        #endregion  

       
        #region Constructor

        public Alumno() { }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad naciona, Gimnasio.EClases claseQueToma)
            :base(id,nombre,apellido,dni,naciona)
        {
            this._claseQueToma = claseQueToma;
            
            
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad naciona, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, naciona, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta; 
        }

        #endregion

        

        #region Overrides
        /// <summary>
        /// devuelve un string con todos los datos de un alumno
        /// </summary>
        /// <returns>string con datos </returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta.ToString());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// hace publicos los datos de MostrarDatos
        /// </summary>
        /// <returns>string con los datos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// da info sobre que clase toma el alumno
        /// </summary>
        /// <returns>string con los datos de que clase toma </returns>
        protected override string ParticiparEnClase()
        {
            return ("TOMA CLASES DE: " + this._claseQueToma.ToString());
        }

        /// <summary>
        /// Comparacion entre un alumno y una clase
        /// </summary>
        /// <param name="a1">alumno a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>Retorna True si un alumno toma la clase y no es deudor</returns>
        public static bool operator ==(Alumno a1, Gimnasio.EClases clase)
        {
            if (a1._claseQueToma == clase && a1._estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        /// <summary>
        /// comparacion negativa entre un alumno y una clase
        /// </summary>
        /// <param name="a1">alumno a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>Retorna true si la clase que toma el alumno es diferente a la  clase que se esta comparando </returns>
        public static bool operator !=(Alumno a1, Gimnasio.EClases clase)
        {
            if (a1._claseQueToma != clase)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
