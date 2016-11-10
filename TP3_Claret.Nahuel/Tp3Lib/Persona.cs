using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos
        string _nombre;
        string _apellido;
        ENacionalidad _nacionalidad;
        #endregion

        #region Enumerados
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Propertys
        int _dni;

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = this.ValidarNombreApellido(value);
            }
        }
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = this.ValidarNombreApellido(value);
            }
        }
        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set
            {
                if (value == ENacionalidad.Argentino || value == ENacionalidad.Extranjero)
                {
                    this._nacionalidad = value;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
        }
        public int Dni
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = this.ValidarDni(this._nacionalidad, value);
            }
        }
        public string StringToDni
        {
            set
            {
                if (!int.TryParse(value, out this._dni))
                {
                    throw new DniInvalidoException();
                }
            }
        }


        #endregion

        #region Constructors
        public Persona(string nombre, string apellido, ENacionalidad naciona)
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Nacionalidad = naciona;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad naciona)
            : this(nombre, apellido, naciona)
        {
            this.Dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad naciona)
            : this(nombre, apellido, naciona)
        {
            this.StringToDni = dni;
        }
        #endregion

        #region Methods

        /// <summary>
        /// metodo que valida el dni que si es argentino o extranjero y la numeroacion que les corresponden
        /// </summary>
        /// <param name="naciona">nacionalidad </param>
        /// <param name="dni">dni a validar </param>
        /// <returns>devuelve un dni si es valido</returns>
        private int ValidarDni(ENacionalidad naciona, int dni)
        {
            if ((this._nacionalidad == ENacionalidad.Argentino && dni > 1 && dni < 89999999) ||
            (this._nacionalidad == ENacionalidad.Extranjero && dni > 89999999 && dni < 99999999))
            {
                return dni;
            }
            else
            {
                throw new DniInvalidoException();
            }
        }
        /// <summary>
        /// valida que los nombre sy los apellidos tengan caracteres validos. 
        /// 
        /// </summary>
        /// <param name="dato">string a validar</param>
        /// <returns>el string validado con el nombre o apellido o en caso de error un string null </returns>
        private string ValidarNombreApellido(string dato)
        {
            bool flag = true;
            foreach (char item in dato)
            {
                if (!char.IsLetter(item))
                {
                    flag = false; 
                }
            }
            if (flag == true)
            {
                return dato;
            }
            else { return null; } 
        }

        /// <summary>
        /// public alos datos de una persona
        /// </summary>
        /// <returns>sring con los datos </returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("Nombre: " + this.Nombre);
            retorno.AppendLine("Apellido: " + this.Apellido);
            retorno.AppendLine("DNI: " + this.Dni);
            retorno.AppendLine("Nacionalidad: " + this.Nacionalidad); 

            return retorno.ToString();
        }


        #endregion


    }
}
