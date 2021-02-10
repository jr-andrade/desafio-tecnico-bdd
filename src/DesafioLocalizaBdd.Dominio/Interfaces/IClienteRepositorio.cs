using DesafioLocalizaBdd.Domain.Entidades;
using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Lista os clientes cadastrados
        /// </summary>
        /// <returns>Lista de clientes cadastrados</returns>
        public IEnumerable<Cliente> Listar();

        /// <summary>
        /// Cadastra um cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>Id do cliente cadastrado</returns>
        public Guid Cadastrar(Cliente cliente);

        /// <summary>
        /// Atualiza um cliente
        /// </summary>
        /// <param name="cliente"></param>
        public void Atualizar(Cliente cliente);

        /// <summary>
        /// Remove um cliente
        /// </summary>
        /// <param name="cliente"></param>
        public void Remover(Cliente cliente);
    }
}
