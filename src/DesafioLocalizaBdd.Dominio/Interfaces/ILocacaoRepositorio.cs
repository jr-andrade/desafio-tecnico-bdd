using DesafioLocalizaBdd.Domain.Entidades;
using System;

namespace DesafioLocalizaBdd.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de locações
    /// </summary>
    public interface ILocacaoRepositorio
    {
        /// <summary>
        /// Obtém uma locação
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto contendo a locação recuperada</returns>
        public Locacao Obter(Guid id);

        /// <summary>
        /// Cadastra uma locação
        /// </summary>
        /// <param name="locacao"></param>
        /// <returns>Objeto contendo a locação cadastrada</returns>
        public Locacao Cadastrar(Locacao locacao);
    }
}
