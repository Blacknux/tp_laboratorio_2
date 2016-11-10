using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException: Exception
    {

        string mensajeBase;
        public DniInvalidoException():base("Error en formato del DNI")
        {
                  
        }

    }
}
