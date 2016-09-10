using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Numero
    {
        private double numero;

        #region Constructores
        /// <summary>
        /// Instancia un Numero con valor Default 
        /// campo numero=0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Recibe un string e instancia un Numero con el valor del string validado por setNumero.
        /// </summary>
        /// <param name="numero">String con el numero recibido</param>
        public Numero(string numero)
        {
            this.setNumero(numero);
        }

        /// <summary>
        /// Recibe un Double e instancia un Numero con ese valor en el campo numero
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Recibe un string y si es un numero lo retorna en caso contarrio retorna 0
        /// </summary>
        /// <param name="numeroString">String a validar</param>
        /// <returns></returns>
        private static double validarNumero(string numeroString)
        {
            double retorno;
            double.TryParse(numeroString, out retorno);
            return retorno;
        }

        /// <summary>
        /// Recibe un string y lo asigna al atributo numero del objeto
        /// </summary>
        /// <param name="numero">string con numero a asignar a atrib numero</param>
        private  void setNumero(string numero)
        {
            this.numero = Numero.validarNumero(numero);
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Overload del operador + para que pueda sumar 2 objetos del tipo Numero. 
        /// Suma los atributos Numero.numero de cada uno de los numeros recibidos por parametros
        /// </summary>
        /// <param name="num1">Numero 1 a sumar</param>
        /// <param name="num2">Numero 2 a sumar</param>
        /// <returns>Resultado de la suma entre 2 objetos del tipo Numero.</returns>
        public  static  double operator+ (Numero num1, Numero num2)
        {
            double retorno;
            retorno = num1.numero + num2.numero;
            return retorno;
        }

        /// <summary>
        /// Overload del operador - para que pueda restar 2 objetos del tipo Numero.
        /// Resta los atributos Numero.numero de cada uno de los numeros recibidos por parametro.
        /// </summary>
        /// <param name="num1">Numero 1 a Restar</param>
        /// <param name="num2">Numero 2 a Restar</param>
        /// <returns>Resultado de la resta entre 2 objetos del tipo Numero. </returns>
        public static double operator -(Numero num1, Numero num2)
        {
            double retorno;
            retorno = num1.numero - num2.numero;
            return retorno;
        }

        /// <summary>
        /// Overload del operador * para que pueda Multiplicar 2 objetos del tipo Numero.
        /// Multiplica los atributos Numero.numero de cada uno de los numeros recibidos por parametro.
        /// </summary>
        /// <param name="num1">Numero 1 a Multiplicar</param>
        /// <param name="num2">Numero 2 a Multiplicar</param>
        /// <returns>Resultado de la resta entre 2 objetos del tipo Numero.</returns>
        public static double operator *(Numero num1, Numero num2)
        {
            double retorno;
            retorno = num1.numero * num2.numero;
            return retorno;
        }
        /// <summary>
        /// Overload del operador / para que pueda dividir 2  objetos del tipo Numero.
        /// Divide los atributos Numero1.numero /  Numero2.numero de cada uno de los numeros recibidos por parametro.
        /// valida la division por 0 en caso de que el divisor sea 0 retorna 0 como resultado 
        /// </summary>
        /// <param name="num1">Numero 1 a Dividir</param>
        /// <param name="num2">Numero 2 a Dividir</param>
        /// <returns>Resultado de la division entre 2 objetos del tipo Numero en caso que el segundo numero sea 0 retorna 0.</returns>
        public static double operator /(Numero num1, Numero num2)
        {
            double retorno;
            if (num2 == 0)
            {
                retorno = 0;
            }
            else
            {
                retorno = num1.numero / num2.numero;
            }
            return retorno;
        }

        /// <summary>
        /// Overload del operador == para que pueda comparar un objeto de tipo Numero con un int.
        /// Compara el atributo Numero.numero con un int.
        /// </summary>
        /// <param name="num1">Objeto tipo numero a comparar</param>
        /// <param name="num2">int a comparar</param>
        /// <returns>Si el atributo numero del objeto Numero es igual al valor del int recibido retorna True caso
        /// contrario retorna False</returns>
        public static bool operator ==(Numero num1, double num2)
        {
            bool retorno = false;
            if (num1.numero == num2)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Overload del operador != para que pueda comparar un objeto de tipo Numero con un int.
        /// Compara el atributo Numero.numero con un int.
        /// </summary>
        /// <param name="num1">Objeto tipo numero a comparar</param>
        /// <param name="num2">int a comparar</param>
        /// <returns>Si el atributo numero del objeto Numero es igual al valor del int recibido retorna False caso
        /// contrario retorna True</returns>
        public static bool operator !=(Numero num1, double num2)
        {
            return !(num1 == num2);
        }



        #endregion


    }
}
