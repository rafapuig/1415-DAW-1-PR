using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Programacion.POO.Encapsulacion;

namespace Clases.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCapitalizarNombre()
        {
            Persona p = new Persona(Genero.Hombre, "jose luis", null as Persona, null);

            Assert.AreEqual(p.Nombre, "Jose Luis");

            Persona maria = new Persona(Genero.Mujer, "Maria", "Lopez", "Ramos");

            p.Casarse(maria);

            Assert.AreSame(p.Conyuge, maria, "No se corresponde el conyuge");


            //p.Nombre = "";

            p.Divorciarse();

            Assert.AreSame(maria.Conyuge, null);

        }
    }
}
