﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Automovil:Vehiculo
    {
        #region "Constructor"
        public Automovil(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Los automoviles tienen 4 ruedas
        /// </summary>
        public  override short CantidadRuedas
        {
            get
            {
                return 4;
            }
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Concatena en un string los atributos  de un Automovil
        /// </summary>
        /// <returns>String con atributos de un Automovil</returns>

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS : "+ this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
