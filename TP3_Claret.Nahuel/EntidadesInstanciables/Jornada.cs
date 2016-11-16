    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;


namespace EntidadesInstanciables
{
  public class Jornada
  {
      #region atributos
        List<Alumno> _alumnos;
        Gimnasio.EClases _clase;
        Instructor _instructor;
      #endregion
        
      #region Constructors
        public Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        

        public Jornada(Gimnasio.EClases clase, Instructor i1) : this()
        {
            this._clase = clase;
            this._instructor = i1;
        }
        #endregion

        #region methods
        public static bool operator ==(Jornada j1, Alumno a1)
        {
            
            for (int i = 0; i < j1._alumnos.Count; i++)
            {
                if (j1._alumnos[i] == a1)
                {
                    return true;
                }
            }
            return false;
            
        }

        public static bool operator !=(Jornada j1, Alumno a1)
        {
            return !(j1 == a1);
        }

        public static Jornada operator +(Jornada j1, Alumno a1)
        {
            if (!(j1==a1))
            {
                j1._alumnos.Add(a1);
            }
            else
            {
                throw new AlumnoRepetidoException(); 
            }

            return j1; 
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            sb.AppendLine("CLASE DE " + this._clase.ToString() + " DADA POR " + this._instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this._alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<----------------------------------------------------->");
            return sb.ToString();
        }

        public static bool Guardar(Jornada jornada)
        {
            Console.WriteLine("TXT");
            try
            {
                Texto T1 = new Texto();
                T1.Guardar("./Jornada.txt", jornada.ToString());
                return true;
            }
            catch (ArchivosException e)
            {
                throw e;
            }
        }

        public static bool Leer(string archivo, out string salida)
        {
            try
            {
                Texto t1 = new Texto();
                t1.Leer(archivo, out salida);
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            
            }
        }
        #endregion

  }
}
