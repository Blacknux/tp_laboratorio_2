using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Archivos; 


namespace TestDNI
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        [ExpectedException (typeof(NacionalidadInvalidaException))]
        public void NacionalidadExtranjerainvalido()
        {
            Alumno a1 = new Alumno(23, "Jose", "Perez", "33333333", Persona.ENacionalidad.Extranjero, Gimnasio.EClases.Natacion); 
        }

        



    }
}
