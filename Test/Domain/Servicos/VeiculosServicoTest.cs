using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Test.Domain.Servicos
{
    [TestClass]
    public class VeiculosServicoTest
    {
        // Arrange
        private static DbContexto CriarContextoDeTeste()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

            var builder = new ConfigurationBuilder()
                .SetBasePath(path ?? Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(configuration);
        }

        private VeiculoServico servico = new(CriarContextoDeTeste());

        [TestMethod]
        public void TestIncluir()
        {
            // Arrange
            Veiculo veiculo = new Veiculo();
            // Act
            veiculo.Ano = 2007;
            veiculo.Id = 1;
            veiculo.Marca = "M1";
            veiculo.Nome = "N1";

            servico.Incluir(veiculo);

            // Assert
            Assert.AreEqual(1, servico.Todos(1).Count);
            servico.Apagar(veiculo);
        }

        [TestMethod]
        public void TestApagar()
        {
            // Arrange
            Veiculo veiculo = new Veiculo();
            // Act
            veiculo.Ano = 2007;
            veiculo.Id = 1;
            veiculo.Marca = "M1";
            veiculo.Nome = "N1";

            servico.Incluir(veiculo);
            servico.Apagar(veiculo);

            // Assert
            Assert.AreEqual(1, servico.Todos(1).Count);

        }

        [TestMethod]
        public void TestAtualizar()
        {
            // Arrange
            Veiculo veiculo = new Veiculo();
            // Act
            veiculo.Ano = 2004;
            veiculo.Id = 1;
            veiculo.Marca = "M2";
            veiculo.Nome = "N2";
            servico.Atualizar(veiculo);

            // Assert
            Assert.AreEqual(2004, veiculo.Ano);
            Assert.AreEqual("M2", veiculo.Marca);
            Assert.AreEqual("N2", veiculo.Nome);

        }

        [TestMethod]
        public void TestBuscaPorId()
        {
            // Arrange
            Veiculo veiculo = new Veiculo();
            // Act
            veiculo.Ano = 2007;
            veiculo.Id = 3;
            veiculo.Marca = "M3";
            veiculo.Nome = "N3";

            servico.Incluir(veiculo);
            Veiculo? veiculoDoBanco = servico.BuscaPorId(veiculo.Id);

            // Assert
            Assert.AreEqual(3, veiculoDoBanco?.Id);
        }
    }
}