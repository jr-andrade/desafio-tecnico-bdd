using DesafioLocalizaBdd.Domain.Interfaces;
using DesafioLocalizaBdd.Domain.ValueObjects.Veiculo;
using System.Collections.Generic;
using System.Linq;

namespace DesafioLocalizaBdd.Infrastructure.Repositorios
{
    public class MarcaRepositorio : IMarcaRepositorio
    {
        private static List<Marca> _marcas = new List<Marca>()
        {
            new Marca("1", "Fiat"),
            new Marca("2", "Ford"),
            new Marca("3", "Volkswagem")
        };

        public Marca Cadastrar(string marca)
        {
            var codigo = (_marcas.Count + 1).ToString();
            var marcaCadastrada = new Marca(codigo, marca);
            _marcas.Add(marcaCadastrada);
            return marcaCadastrada;
        }

        public IEnumerable<Marca> Listar()
        {
            return _marcas;
        }

        public Marca Obter(string codigo)
        {
            return _marcas.FirstOrDefault(m => m.Codigo == codigo);
        }
    }
}
