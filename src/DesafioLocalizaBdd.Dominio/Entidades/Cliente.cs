using DesafioLocalizaBdd.Domain.ValueObjects.Cliente;
using Flunt.Validations;
using System;

namespace DesafioLocalizaBdd.Domain.Entidades
{
    /// <summary>
    /// Entidade de domínio que representa um Cliente
    /// Cliente também é um Usuário
    /// </summary>
    public class Cliente : Usuario
    {
        //TODO: Verificar necessidade desse construtor
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
        /// Construtor
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cpf"></param>
        /// <param name="aniversario"></param>
        /// <param name="endereco"></param>
        /// <param name="senha"></param>
        public Cliente(string nome, string cpf, DateTime aniversario, Endereco endereco, string senha)
            :base(nome, cpf, senha, Helper.Constantes.PERFIL_CLIENTE)
        {
            Cpf = cpf;
            Aniversario = aniversario;
            Endereco = endereco;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(Cpf, nameof(Cpf), "CPF não pode ser nulo ou branco")
                .HasLen(Cpf, 11, nameof(Cpf), "CPF deve possuir 11 dígitos")
                .IsDigit(Cpf, nameof(Cpf), "CPF deve possuir apenas números")

                .IsNotNull(Aniversario, nameof(Aniversario), "Aniversário não pode ser nulo")
                .IsLowerThan(Aniversario, DateTime.Today.AddYears(-21), nameof(Aniversario), "Cliente deve possuir mais de 21 anos")
                .IsGreaterThan(Aniversario, DateTime.Today.AddYears(-70), nameof(Aniversario), "Cliente deve possuir menos de 70 anos")

                .IsNotNull(Endereco, nameof(Endereco), "Endereco não pode ser nulo")
            );

            if (Endereco != null)
                AddNotifications(Endereco);
        }

        /// <summary>
        /// Construtor (Utilizado pelo repositório)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nome"></param>
        /// <param name="cpf"></param>
        /// <param name="aniversario"></param>
        /// <param name="endereco"></param>
        /// <param name="senha"></param>
        public Cliente(Guid id, string nome, string cpf, DateTime aniversario, Endereco endereco, string senha) 
            : this(nome, cpf, aniversario, endereco, senha)
        {
            Id = id;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Id, nameof(Id), "Id não pode ser nulo")
            );
        }

        /// <summary>
        /// CPF
        /// </summary>
        public string Cpf { get; private set; }

        /// <summary>
        /// Aniversário
        /// </summary>
        public DateTime Aniversario { get; private set; }

        /// <summary>
        /// Endereço
        /// </summary>
        public Endereco Endereco { get; private set; }
    }
}
