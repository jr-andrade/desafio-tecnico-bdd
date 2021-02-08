using System;

namespace DesafioLocalizaBdd.Domain.Entidades
{
    /// <summary>
    /// Entidade de domínio que representa um Operador
    /// Operador também é um usuário
    /// </summary>
    public class Operador : Usuario
    {
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
        /// Matricula
        /// </summary>
        public string Matricula { get; set; }
    }
}
