using DesafioLocalizaBdd.Domain.Entidades;
using System;

namespace DesafioLocalizaBdd.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de clientes
    /// </summary>
    public interface IClienteRepositorio
    {
        /// <summary>
        /// Obtém um cliente
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Objeto contendo o Cliente</returns>
        public Cliente Obter(Guid Id);
    }
}
