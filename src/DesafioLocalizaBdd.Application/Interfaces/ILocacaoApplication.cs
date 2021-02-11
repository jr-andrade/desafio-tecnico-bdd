using DesafioLocalizaBdd.Domain.Entidades;
using System;

namespace DesafioLocalizaBdd.Application.Interfaces
{
    /// <summary>
    /// Interface para a aplicação de locações
    /// </summary>
    public interface ILocacaoApplication
    {
        /// <summary>
        /// Realiza a estimativa da locação 
        /// </summary>
        /// <param name="veiculoId"></param>
        /// <param name="inicio"></param>
        /// <param name="fim"></param>
        /// <returns>valor estimado</returns>
        public decimal Estimar(Guid veiculoId, DateTime inicio, DateTime fim);

        /// <summary>
        /// Realiza o agendamento de uma locação
        /// </summary>
        /// <param name="veiculoId"></param>
        /// <param name="clienteId"></param>
        /// <param name="inicio"></param>
        /// <param name="fim"></param>
        /// <returns>Objeto contendo a Locacao cadastrada</returns>
        public Locacao Agendar(Guid veiculoId, Guid clienteId, DateTime inicio, DateTime fim);
    }
}
