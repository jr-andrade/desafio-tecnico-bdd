using System;

namespace DesafioLocalizaBdd.Domain.Entidades
{
    /// <summary>
    /// Entidade de domínio que representa um Cliente
    /// Cliente também é um Usuário
    /// </summary>
    public class Cliente : Usuario
    {
        /// <summary>
        /// Construtor que recebe id, cpf, aniversario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cpf"></param>
        /// <param name="aniversario"></param>
        public Cliente(Guid id, string cpf, DateTime aniversario) : base(id)
        {
            Cpf = cpf;
            Aniversario = aniversario;
        }
        
        /// <summary>
        /// CPF
        /// </summary>
        public string Cpf { get; private set; }

        /// <summary>
        /// Aniversário
        /// </summary>
        public DateTime Aniversario { get; private set; }
    }
}
