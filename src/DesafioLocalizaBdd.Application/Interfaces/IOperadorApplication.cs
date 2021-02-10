using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.Entidades;

namespace DesafioLocalizaBdd.Application.Interfaces
{
    /// <summary>
    /// Interface para a aplicação de cadastro de operadores
    /// </summary>
    public interface IOperadorApplication
    {
        /// <summary>
        /// Realiza o cadastro do operador
        /// </summary>
        /// <param name="operadorModel"></param>
        /// <returns>Objeto contendo o operador cadastrado</returns>
        public Operador Cadastrar(OperadorModel operadorModel);
    }
}
