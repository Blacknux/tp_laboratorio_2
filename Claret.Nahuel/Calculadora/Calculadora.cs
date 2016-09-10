using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Calculadora
    {
        /// <summary>
        /// Recibe un string y valida que el mismo corresponda con algunos de los chars de operaciones "+,-,*,/"
        /// Si no corresponde retorna un "+"
        /// </summary>
        /// <param name="operValidar">String que se recibe para validar el signo de operacion</param>
        /// <returns>En caso de que el string sea valido retorna ese string, caso contarrio retorna +</returns>
        public static string validarOperador(string operValidar) 
        {
           string retorno=operValidar;
           if (operValidar != "+" && operValidar != "-" && operValidar != "*" && operValidar != "/")
           {
               retorno = "+";
           }
           return retorno;
        }

        /// <summary>
        /// Recibe dos numeros y un str oeprador, dados estos paramertros realiza la operacion correspondiente
        /// entre los 2 numeros:
        /// Numero 1 + Numero 2, Numero 1 - Numero 2, Numero 1 * Numero 2, Numero 1 / Numero 2.
        /// En caso de que se quiera dividir por 0 devuelve 0.
        /// </summary>
        /// <param name="num1">Primer numero para la operacion</param>
        /// <param name="num2">segundo numero para la operacion</param>
        /// <param name="oper">string de operador</param>
        /// <returns>Devuelve el valor de la operacion solicitada de los numeros pasados por parametros</returns>
        public static double Operar(Numero num1, Numero num2, string oper)
        {
            double resultado=0;
            string operador = validarOperador(oper);
            switch (operador)
            {
                case "+":
                    resultado= num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    //if (num2 == 0)
                    //{
                    //    resultado = 0;
                    //}
                    //else
                    //{
                        resultado = num1 / num2;
                    //}
                    break;
            }

            return resultado;

        }

        



        
    }


    
}
