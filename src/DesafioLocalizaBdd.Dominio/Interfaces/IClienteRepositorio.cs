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
        /// <param name="id"></param>
        /// <returns>Objeto contendo o Cliente</returns>
        public Cliente Obter(Guid id);

        /// <summary>
        /// Lista os clientes cadastrados
        /// </summary>
        /// <returns>Lista de clientes cadastrados</returns>
        public IEnumerable<Cliente> Listar();

        /// <summary>
        /// Cadastra um cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>Cliente cadastrado</returns>
        public Cliente Cadastrar(Cliente cliente);
        
    }
}
