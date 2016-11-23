using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException: Exception
    {
        public DniInvalidoException()
            : base("DNI NO VALIDO ")
        { }
        public DniInvalidoException(Exception e)
            : base("DNI NO VALIDO ", e)
        { }
        public DniInvalidoException(string message)
            : this(message, null)
        { }
        public DniInvalidoException(string message, Exception e)
            : base("DNI NO VALIDO " + message, e)
        { }
    }
}
