using DesafioLocalizaBdd.Domain.Interfaces;
using DesafioLocalizaBdd.Domain.ValueObjects.Veiculo;
using System.Collections.Generic;
using System.Linq;

namespace DesafioLocalizaBdd.Infrastructure.Repositorios
{
    public class ModeloRepositorio : IModeloRepositorio
    {
        private static List<Modelo> _modelos = new List<Modelo>()
        {
            new Modelo("1", "Argo"),
            new Modelo("2", "Gol"),
            new Modelo("3", "Siena")
        };

        public Modelo Cadastrar(string modelo)
        {
            var codigo = (_modelos.Count + 1).ToString();
            var modeloCadastrado = new Modelo(codigo, modelo);
            _modelos.Add(modeloCadastrado);
            return modeloCadastrado;
        }

        public IEnumerable<Modelo> Listar()
        {
            return _modelos;
        }

        public Modelo Obter(string codigo)
        {
            return _modelos.FirstOrDefault(m => m.Codigo == codigo);
        }
    }
}
