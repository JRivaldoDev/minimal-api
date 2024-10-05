using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades
{
    [TestClass]
    public class VeiculosTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Veiculo veiculo = new Veiculo();
            // Act
            veiculo.Ano = 2007;
            veiculo.Id = 1;
            veiculo.Marca = "M1";
            veiculo.Nome = "N1";

            // Assert
            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual("M1", veiculo.Marca);
            Assert.AreEqual("N1", veiculo.Nome);
            Assert.AreEqual(2007, veiculo.Ano);
        }
    }
}