using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.Entidades;

namespace DesafioLocalizaBdd.Application.Interfaces
{
    /// <summary>
    /// Interface para a aplicação de cadastro de clientes
    /// </summary>
    public interface IClienteApplication
    {
        /// <summary>
        /// Realiza o cadastro do cliente
        /// </summary>
        /// <param name="clienteModel"></param>
        /// <returns>Objeto contendo o cliente cadastrado</returns>
        public Cliente Cadastrar(ClienteModel clienteModel);
    }
}
