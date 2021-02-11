using Flunt.Validations;
using Newtonsoft.Json;
using System;

namespace DesafioLocalizaBdd.Domain.Entidades
{
    /// <summary>
    /// Entidade de domínio que representa um Usuário do sistema
    /// </summary>
    public class Usuario : Entity
    {
        /// <summary>
        /// Construtor para testes de integração
        /// </summary>
        [JsonConstructor]
        public Usuario(Guid id, string login, string senha, string nome, string perfil, string token)
        {
            Id = id;
            Login = login;
            Senha = senha;
            Nome = nome;
            Perfil = perfil;
            Token = token;
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <param name="nome"></param>
        /// <param name="perfil"></param>
        public Usuario(string nome, string login, string senha,  string perfil)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Perfil = perfil;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(Nome, nameof(Nome), "Nome não pode ser nulo ou branco")
                .HasMinLen(Nome, 2, nameof(Nome), "Nome deve possuir no mínimo 2 dígitos")

                .IsNotNullOrWhiteSpace(Senha, nameof(Senha), "Senha não pode ser nulo ou branco")
                .HasMinLen(Senha, 8, nameof(Senha), "Senha deve possuir no mínimo 8 dígitos")

                .IsNotNullOrWhiteSpace(Perfil, nameof(Perfil), "Perfil não pode ser nulo ou branco")
            );
        }
                
        /// <summary>
        /// Construtor que recebe login, senha, nome e perfil
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <param name="nome"></param>
        /// <param name="perfil"></param>
        public Usuario(Guid id, string login, string senha, string nome, string perfil)
        {
            Id = id;
            Login = login;
            Senha = senha;
            Nome = nome;
            Perfil = perfil;
        }       
        
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
        public string Perfil { get; private set; }

        /// <summary>
        /// Autentica o usuário
        /// </summary>
        /// <param name="token"></param>
        public void Autenticar(string token)
        {
            Token = token;
        }
    }
}
