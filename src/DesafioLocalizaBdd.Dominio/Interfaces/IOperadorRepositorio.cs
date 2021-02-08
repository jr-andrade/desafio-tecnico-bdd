using DesafioLocalizaBdd.Domain.Entidades;
using System;

namespace DesafioLocalizaBdd.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de operadores
    /// </summary>
    public interface IOperadorRepositorio
    {
        /// <summary>
        /// Obtém um Operador pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto contendo um Operador do sistema</returns>
        public Operador Obter(Guid id);
    }
}
