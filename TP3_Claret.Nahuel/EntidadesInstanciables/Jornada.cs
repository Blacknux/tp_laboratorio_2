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
        List<Alumno> _alumnos;
        Gimnasio.EClases _clase;
        Instructor _instructor;

        public Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        

        public Jornada(Gimnasio.EClases clase, Instructor i1) : this()
        {
            this._clase = clase;
            this._instructor = i1;
        }


        public static bool operator ==(Jornada j1, Alumno a1)
        {
            
            
            if (j1._alumnos.Contains(a1))
            {
                return true;
            }
            else {
                return false;
            }
        }

        public static bool operator !=(Jornada j1, Alumno a1)
        {
            return !(j1 == a1);
        }

        public static Jornada operator +(Jornada j1, Alumno a1)
        {
            if (!j1._alumnos.Contains(a1))
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

            sb.AppendLine("Clase: " + this._clase);
            sb.AppendLine("Instructor: " + this._instructor);
            foreach(Alumno alumno in this._alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }
            return sb.ToString();
        }

        public static bool Guardar(Jornada jornada)
        {
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

        public bool Leer(string archivo, out string salida)
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

    }
}
