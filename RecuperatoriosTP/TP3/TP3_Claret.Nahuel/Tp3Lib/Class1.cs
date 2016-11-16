using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    class Class1:Persona
    {public string Nombre
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

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("Nombre: " + this.Nombre);
            retorno.AppendLine("Apellido: " + this.Apellido);
            retorno.AppendLine("DNI: " + this.Dni);
            retorno.AppendLine("Nacionalidad: " + this.Nacionalidad); 

            return retorno.ToString();
        }
    }
}
