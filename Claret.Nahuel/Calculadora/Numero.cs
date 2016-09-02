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
        /// Recibe un string y valida si es un numero, si no lo es asigna cero a 
        /// al campo numero caso contrario asigna el numero recibido
        /// </summary>
        /// <param name="numero">String con el numero recibido</param>
        public Numero(string numero)
        {
            double.TryParse(numero, out this.numero);
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
        /// Recibe un strin y si es un numero lo retorna en caso contarrio retorna 0
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

        public  static  double operator+ (Numero num1, Numero num2)
        {
            double retorno;
            retorno = num1.numero + num2.numero;
            return retorno;
        }

        public static double operator -(Numero num1, Numero num2)
        {
            double retorno;
            retorno = num1.numero - num2.numero;
            return retorno;
        }

        public static double operator *(Numero num1, Numero num2)
        {
            double retorno;
            retorno = num1.numero * num2.numero;
            return retorno;
        }

        public static double operator /(Numero num1, Numero num2)
        {
            double retorno;
            retorno = num1.numero / num2.numero;
            return retorno;
        }
        public static bool operator ==(Numero num1, double num2)
        {
            bool retorno = false;
            if (num1.numero == num2)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Numero num1, double num2)
        {
            return !(num1 == num2);
        }



        #endregion


    }
}
