using System;

namespace DesafioLocalizaBdd.Domain.Entidades
{
    /// <summary>
    /// Entidade de domínio que representa um Usuário do sistema
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Construtor protegido que recebe Id
        /// </summary>
        /// <param name="id"></param>
        protected Usuario(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Construtor que recebe login, senha, nome e perfil
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <param name="nome"></param>
        /// <param name="perfil"></param>
        public Usuario(Guid id, string login, string senha, string nome, Perfil perfil)
        {
            Id = id;
            Login = login;
            Senha = senha;
            Nome = nome;
            Perfil = perfil;
        }
       
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Login
        /// </summary>
        public string Login { get; private set; }
        
        /// <summary>
        /// Senha
        /// </summary>
        public string Senha { get; private set; }

        /// <summary>
        /// Token de autenticação
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; private set; }

        /// <summary>
        /// Perfil
        /// </summary>
        public Perfil Perfil { get; private set; }

        /// <summary>
        /// Autentica o usuário
        /// </summary>
        /// <param name="token"></param>
        public void Autenticar(string token)
        {
            Token = token;
        }
    }

    /// <summary>
    /// Enumerador de perfis
    /// </summary>
    public enum Perfil
    {
        Cliente = 1,
        Operador = 2
    }
}
