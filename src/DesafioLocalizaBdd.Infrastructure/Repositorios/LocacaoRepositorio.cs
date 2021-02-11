using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioLocalizaBdd.Infrastructure.Repositorios
{
    public class LocacaoRepositorio : ILocacaoRepositorio
    {
        private static List<Locacao> _locacoes = new List<Locacao>()
        {
            new Locacao(new Guid("53a44ce5-78c9-43df-be52-46e6fbaf3779"), new Guid("67b7ebc4-fcf1-45fa-a35e-b0c68ec57b89"), 150, new DateTime(2021,03,01), new DateTime(2021, 03, 03)),
            new Locacao(new Guid("0e2b6f7f-45bb-427d-acf4-5cbef600b053"), new Guid("67b7ebc4-fcf1-45fa-a35e-b0c68ec57b89"), 180, new DateTime(2021,03,10), new DateTime(2021, 03, 14))
        };

        public Locacao Cadastrar(Locacao locacao)
        {
            var id = Guid.NewGuid();
            var locacaoCadastrada = new Locacao(id, locacao.IdVeiculo, locacao.IdCliente, locacao.Valor, locacao.Inicio, locacao.Final);
            _locacoes.Add(locacaoCadastrada);
            return locacaoCadastrada;
        }

        public Locacao Obter(Guid id)
        {
            return _locacoes.FirstOrDefault(l => l.Id == id);
        }
    }
}
