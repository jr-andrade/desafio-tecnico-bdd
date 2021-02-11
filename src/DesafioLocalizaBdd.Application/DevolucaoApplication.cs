using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;
using System;

namespace DesafioLocalizaBdd.Application
{
    /// <summary>
    /// Aplicação para devolução de um veículo
    /// </summary>
    public class DevolucaoApplication : IDevolucaoApplication
    {
        private readonly ILocacaoRepositorio _locacaoRepositorio;
        private readonly ICalculoService _calculoService;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="locacaoRepositorio"></param>
        /// <param name="calculoService"></param>
        public DevolucaoApplication(ILocacaoRepositorio locacaoRepositorio, ICalculoService calculoService)
        {
            _locacaoRepositorio = locacaoRepositorio;
            _calculoService = calculoService;
        }

        /// <summary>
        /// Checklist para vistoria do veículo
        /// </summary>
        /// <param name="idLocacao"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public Locacao Checklist(Guid idLocacao, ChecklistModel model)
        {
            var locacaoOriginal = _locacaoRepositorio.Obter(idLocacao);

            var cobrancaAdicional = _calculoService.CalcularCustoAdicional(locacaoOriginal.Valor, model);

            if (cobrancaAdicional != 0)
                locacaoOriginal.AtualizarValorTotal(cobrancaAdicional);

            return locacaoOriginal;
        }
    }
}
