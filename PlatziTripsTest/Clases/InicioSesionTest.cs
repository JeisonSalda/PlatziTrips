using System;

using NUnit.Framework;
using PlatziTrips.Clases;

namespace PlatziTripsTest.Clases
{
    public class InicioSesionTest
    {
        [Test]
        public void inicioSesionValido(){
            //arrange
            String userName = "Jeison";
            String password = "Jeison123";

            //act

            InicioSesion inicioSesion = new InicioSesion();
            bool puedeIniciarSesion = inicioSesion.iniciarSesion(userName, password);

            //assert
            Assert.IsTrue(puedeIniciarSesion);

        }

    }
}
