using DesafioLocalizaBdd.Domain.ValueObjects.Veiculo;
using System;
using System.Collections.Generic;

namespace DesafioLocalizaBdd.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de modelos de veículo
    /// </summary>
    public interface IModeloRepositorio
    {
        /// <summary>
        /// Obtém um modelo
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public Modelo Obter(string codigo);

        /// <summary>
        /// Lista os modelos cadastrados
        /// </summary>
        /// <returns>Lista de modelos</returns>
        public IEnumerable<Modelo> Listar();

        /// <summary>
        /// Cadastra um modelo
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        public Modelo Cadastrar(string modelo);
    }
}
