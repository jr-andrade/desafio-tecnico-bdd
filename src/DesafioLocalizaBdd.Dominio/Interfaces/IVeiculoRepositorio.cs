using DesafioLocalizaBdd.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace DesafioLocalizaBdd.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de Veículo
    /// </summary>
    public interface IVeiculoRepositorio
    {
        /// <summary>
        /// Obtém um veículo
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto contendo o Veículo</returns>
        public Veiculo Obter(Guid id);

        /// <summary>
        /// Lista os veículos cadastrados
        /// </summary>
        /// <returns>Lista dos veículos cadastrados</returns>
        public IEnumerable<Veiculo> Listar();

        /// <summary>
        /// Cadastra um veículo
        /// </summary>
        /// <param name="veiculo"></param>
        /// <returns>Objeto contendo o veículo</returns>
        public Veiculo Cadastrar(Veiculo veiculo);
    }
}
