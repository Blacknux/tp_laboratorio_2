using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using Excepciones; 

namespace TestDNI
{
    [TestClass]
    public class NullTest
    {
        [TestMethod]
        [ExpectedException (typeof(NullReferenceException))]
        public void NullTest1()
        {
            Instructor i1 = new Instructor(3, null, "jose", "30998992", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
        }
    }
}
