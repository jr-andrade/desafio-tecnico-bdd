using System;

namespace DesafioLocalizaBdd.Application.Models
{
    /// <summary>
    /// Modelo representacional de um operador
    /// </summary>
    public class OperadorModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Matricula
        /// </summary>
        public string Matricula { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        public string Senha { get; set; }
    }
}
