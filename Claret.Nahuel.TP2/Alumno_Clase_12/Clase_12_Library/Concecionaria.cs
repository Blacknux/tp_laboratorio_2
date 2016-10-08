﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public  class Concecionaria
    {
        #region Atributos
        List<Vehiculo> _vehiculos;
        int _espacioDisponible;
        #endregion

        #region enumerado tipo de vehiculos
        public enum ETipo
        {
            Moto, Camion, Automovil, Todos
        }
         #endregion

        #region "Constructores"
        private Concecionaria()
        {
            this._vehiculos = new List<Vehiculo>();
        }
        public Concecionaria(int espacioDisponible):this()
        {
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro la concecionaria y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Concecionaria.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos de la concecionaria y sus vehículos (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="concecionaria">Concecionaria a exponer</param>
        /// <param name="ETipo">Tipos de Vehiculos a mostrar</param>
        /// <returns>string mcon los datos e a ocncesionaria y sus vehiculos </returns>
        public static string Mostrar(Concecionaria concecionaria, ETipo tipoDeVehiculo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", concecionaria._vehiculos.Count, concecionaria._espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in concecionaria._vehiculos)
            {
                //switch (tipoDeVehiculo)
                //{
                //    case ETipo.Automovil:
                //        sb.AppendLine(v.Mostrar());
                //        break;
                //    case ETipo.Moto:
                //        sb.AppendLine(v.Mostrar());
                //        break;
                //    case ETipo.Camion:
                //        sb.AppendLine(v.Mostrar());
                //        break;
                //    default:
                //        sb.AppendLine(v.Mostrar());
                //        break;
                //}

                if (tipoDeVehiculo == ETipo.Automovil && v is Automovil)
                {
                    sb.AppendLine(v.Mostrar());
                }
                else if (tipoDeVehiculo == ETipo.Moto && v is Moto)
                {
                    sb.AppendLine(v.Mostrar());
                }
                else if (tipoDeVehiculo == ETipo.Camion && v is Camion)
                {
                    sb.AppendLine(v.Mostrar());
                }
                else if (tipoDeVehiculo==ETipo.Todos)
                {
                    sb.AppendLine(v.Mostrar());
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un vehículo a la concecionaria, siempre que haya espacio disponible y el vehiculo no exista en la misma 
        /// </summary>
        /// <param name="concecionaria">Objeto del tipo Concecionaria donde se agregará el vehículo</param>
        /// <param name="vehiculo">Objeto del tipo Vehículo a agregar</param>
        /// <returns>un objeto concecioanaria con el nuevo vehiculo agregado si corresponde</returns>
        public static Concecionaria operator +(Concecionaria concecionaria, Vehiculo vehiculo)
        {
            if (concecionaria._vehiculos != null && concecionaria._vehiculos.Count >= concecionaria._espacioDisponible)
                return concecionaria;
            if (concecionaria._vehiculos != null)
            {
                foreach (Vehiculo v in concecionaria._vehiculos)
                {
                    if (v == vehiculo)
                        return concecionaria;
                }
            }

            concecionaria._vehiculos.Add(vehiculo);
            return concecionaria;
        }
        /// <summary>
        /// Quitará un vehículo de la concecionaria si existe en ella
        /// </summary>
        /// <param name="concecionaria">Objeto del tipo Concecionaria donde se agregará el vehículo</param>
        /// <param name="vehiculo">Objeto del tipo Vehículo a agregar</param>
        /// <returns>un objeto concesionaria sin el vehiculo en caso de que este existiera en la ocncesionaria</returns>
        public static Concecionaria operator -(Concecionaria concecionaria, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in concecionaria._vehiculos)
            {
                if (v == vehiculo)
                {
                    concecionaria._vehiculos.Remove(v);
                    break;
                }
            }

            return concecionaria;
        }
        #endregion
    }
}
