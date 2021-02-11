using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.Entidades;

namespace DesafioLocalizaBdd.Application.Interfaces
{
    /// <summary>
    /// Interface para a aplicação de veículos
    /// </summary>
    public interface IVeiculoApplication
    {
        /// <summary>
        /// Cadastra um veículo
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Veículo cadastrado</returns>
        public Veiculo Cadastrar(VeiculoModel model);
    }
}
