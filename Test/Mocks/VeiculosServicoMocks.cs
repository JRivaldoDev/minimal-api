using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;

namespace Test.Mocks
{
    public class VeiculosServicoMocks
    {
        private static readonly List<Veiculo> veiculos = new(){
            new Veiculo{
                Id = 1,
                Ano = 2007,
                Marca = "M1",
                Nome = "N1"
            },
            new Veiculo{
                Id = 2,
                Ano = 2004,
                Marca = "M2",
                Nome = "N2"
            }
        };



        public void Apagar(Veiculo veiculo)
        {
            veiculos.Remove(veiculo);
        }

        public void Atualizar(Veiculo veiculo)
        {
            veiculos[veiculo.Id] = veiculo;

        }

        public Veiculo? BuscaPorId(int id)
        {
            return veiculos.Find(veiculo => veiculo.Id == id);
        }

        public void Incluir(Veiculo veiculo)
        {
            veiculo.Id = veiculos.Count + 1;
            veiculos.Add(veiculo);

        }

        public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
        {
            return veiculos;
        }
    }
}