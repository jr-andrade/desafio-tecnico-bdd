using Flunt.Validations;
using System;

namespace DesafioLocalizaBdd.Domain.Entidades
{
    /// <summary>
    /// Entidade de domínio que representa um Operador
    /// Operador também é um usuário
    /// </summary>
    public class Operador : Usuario
    {
        //TODO: Verificar se esse construtor é nescessário
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        /// <param name="id"></param>
        /// <param name="matricula"></param>
        public Operador(Guid id, string matricula) : base(id)
        {
            Matricula = matricula;
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="matricula"></param>
        /// <param name="senha"></param>
        public Operador(string nome, string matricula, string senha)
            : base (nome, matricula, senha, Helper.Constantes.PERFIL_OPERADOR)
        {
            Matricula = matricula;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(Matricula, nameof(Matricula), "Matricula não pode ser nula ou em branco")
                .HasLen(Matricula, 6, nameof(Matricula), "CPF deve possuir 6 dígitos")
                .IsDigit(Matricula, nameof(Matricula), "Matricula deve possuir apenas números")
            );
        }

        /// <summary>
        /// Matricula
        /// </summary>
        public string Matricula { get; set; }
    }
}
