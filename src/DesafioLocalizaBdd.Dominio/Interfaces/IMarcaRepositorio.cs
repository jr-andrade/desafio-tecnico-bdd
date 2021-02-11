using DesafioLocalizaBdd.Domain.ValueObjects.Veiculo;
using System;
using System.Collections.Generic;

namespace DesafioLocalizaBdd.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de marcas de veículos
    /// </summary>
    public interface IMarcaRepositorio
    {
        /// <summary>
        /// Obtém um marca
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public Marca Obter(string codigo);

        /// <summary>
        /// Lista as marcas cadastradas
        /// </summary>
        /// <returns>Lista de marcas</returns>
        public IEnumerable<Marca> Listar();

        /// <summary>
        /// Cadastra uma marca
        /// </summary>
        /// <param name="marca"></param>
        /// <returns></returns>
        public Marca Cadastrar(string marca);
    }
}
