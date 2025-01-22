using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using gestionBancariaApp;

namespace GestionBancariaTest
{
    [TestClass]
    public class GestionBancariaTests
    {
        [TestMethod]
        public void validarMetodoIngreso()
        {
            double saldoInicial = 1000;
            double ingreso = 500;
            double saldoActual = 0;
            double saldoEsperado = 1500;

            gestionBancaria cuenta = new gestionBancaria(saldoInicial);
            cuenta.realizarIngreso(ingreso);
            saldoActual = cuenta.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, saldoActual, 0.001, "El saldo en la cuenta no es correcto");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IngresoNegativo() {
            double saldoInicial = 1000;
            gestionBancaria cuenta = new gestionBancaria(saldoInicial);
            double ingreso = -1;
            cuenta.realizarIngreso(ingreso);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ingreso0() {
            double saldoInicial = 1000;
            gestionBancaria cuenta = new gestionBancaria(saldoInicial);
            double ingreso = 0;
            cuenta.realizarIngreso(ingreso);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestReintegroNegativos(){
            double saldo = 300;
            gestionBancaria cuenta = new gestionBancaria(saldo);
            double cantidad = -100;
            cuenta.realizarReintegro(cantidad);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestReintegro0() {
            double saldo = 300;
            gestionBancaria cuenta = new gestionBancaria(saldo);
            double cantidad = 0;
            cuenta.realizarReintegro(cantidad);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestReintegroSaldoInsuficiente() {
            double saldo = 300;
            gestionBancaria cuenta = new gestionBancaria(saldo);
            double cantidad = 500;
            cuenta.realizarReintegro(cantidad);
        }

        [TestMethod]
        public void TestReintegroCorrecto() {
            double saldo = 300;
            gestionBancaria cuenta = new gestionBancaria(saldo);
            double cantidad = 185;
            double cantidadEsperada = saldo - cantidad;
            cuenta.realizarReintegro(cantidad);
            saldo = cuenta.obtenerSaldo();
            Assert.AreEqual(cantidadEsperada, saldo);
        }
    }
}
