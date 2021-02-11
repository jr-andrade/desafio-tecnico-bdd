using DesafioLocalizaBdd.Domain.Entidades;
using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Lista os operadores cadastrados
        /// </summary>
        /// <returns>Lista de operadores cadastrados</returns>
        public IEnumerable<Operador> Listar();

        /// <summary>
        /// Cadastra um operador
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Operador cadastrado</returns>
        public Operador Cadastrar(Operador operador);
    }
}
