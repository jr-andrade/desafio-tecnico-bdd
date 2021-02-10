using DesafioLocalizaBdd.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace DesafioLocalizaBdd.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de usuários
    /// </summary>
    public interface IUsuarioRepositorio
    {
        /// <summary>
        /// Obtém um usuário
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <returns>Objeto contendo o usuário obtido</returns>
        public Usuario Obter(string login, string senha);

        /// <summary>
        /// Lista os usuários cadastrados
        /// </summary>
        /// <returns>Lista de usuários cadastrados</returns>
        public IEnumerable<Usuario> Listar();

        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="usuario"></param>
        public void Cadastrar(Usuario usuario);

        /// <summary>
        /// Atualiza um usuário
        /// </summary>
        /// <param name="usuario"></param>
        public void Atualizar(Usuario usuario);

        /// <summary>
        /// Remove um usuário
        /// </summary>
        /// <param name="usuario"></param>
        public void Remover(Usuario usuario);
    }
}
