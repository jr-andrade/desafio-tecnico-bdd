using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;
using System;

namespace DesafioLocalizaBdd.Application
{
    /// <summary>
    /// Aplicação de locações
    /// </summary>
    public class LocacaoApplication : ILocacaoApplication
    {
        private readonly IVeiculoRepositorio _veiculoRepositorio;
        private readonly ICalculoService _calculoService;
        private readonly ILocacaoRepositorio _locacaoRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="veiculoRepositorio"></param>
        /// <param name="calculoService"></param>
        public LocacaoApplication(IVeiculoRepositorio veiculoRepositorio, ICalculoService calculoService, ILocacaoRepositorio locacaoRepositorio)
        {
            _veiculoRepositorio = veiculoRepositorio;
            _calculoService = calculoService;
            _locacaoRepositorio = locacaoRepositorio;
        }

        /// <summary>
        /// Realiza a estimativa da locação 
        /// </summary>
        /// <param name="veiculoId"></param>
        /// <param name="inicio"></param>
        /// <param name="fim"></param>
        /// <returns>valor estimado da locação</returns>
        public decimal Estimar(Guid veiculoId, DateTime inicio, DateTime fim)
        {
            var veiculo = _veiculoRepositorio.Obter(veiculoId);

            //TODO: ajustar aqui
            if (veiculo == null)
            {
                throw new Exception();
            }

            return _calculoService.Calcular(veiculo.ValorHora, inicio, fim);
        }

        /// <summary>
        /// Realiza o agendamento de uma locação
        /// </summary>
        /// <param name="veiculoId"></param>
        /// <param name="inicio"></param>
        /// <param name="fim"></param>
        /// <returns>Objeto contendo a locação agendada</returns>
        public Locacao Agendar(Guid veiculoId, Guid clienteId, DateTime inicio, DateTime fim)
        {
            var valor = Estimar(veiculoId, inicio, fim);

            var locacao = new Locacao(veiculoId, clienteId, valor, inicio, fim);

            if (locacao.Valid)
            {
                return _locacaoRepositorio.Cadastrar(locacao);
            }

            return null;
        }
    }
}
