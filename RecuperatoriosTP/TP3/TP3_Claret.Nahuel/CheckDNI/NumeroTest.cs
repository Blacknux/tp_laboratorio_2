using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UTest
{
    [TestClass]
    public class NumeroTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Numerico()
        {
            string numero = "pepe";

                if(!(numero is int))
            {
                throw new Exception("Error no es un numero"); 
            }

        }
    }
}
