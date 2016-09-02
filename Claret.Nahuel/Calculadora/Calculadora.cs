using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Calculadora
    {

        public static string validarOperador(string operValidar) 
        {
           string retorno=operValidar;
           if (operValidar != "+" && operValidar != "-" && operValidar != "*" && operValidar != "/")
           {
               retorno = "+";
           }
           return retorno;
        }

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
                    if (num2 == 0)
                    {
                        resultado = 0;
                    }
                    else
                    {
                        resultado = num1 / num2;
                    }
                    break;
            }

            return resultado;

        }

        



        
    }


    
}
