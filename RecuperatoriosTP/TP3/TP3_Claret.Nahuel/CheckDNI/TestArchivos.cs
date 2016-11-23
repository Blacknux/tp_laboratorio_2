using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Archivos; 

namespace UTest
{
    [TestClass]
    public class TestArchivos
    {
        [TestMethod]
        [ExpectedException (typeof(ArchivosException))]
        public void Archivos()
        {
            Texto T1 = new Texto();

            T1.Guardar(null, "Esto no se va a guardar"); 

        }
    }
}
