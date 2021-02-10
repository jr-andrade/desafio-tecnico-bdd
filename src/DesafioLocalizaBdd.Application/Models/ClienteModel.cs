using System;

namespace DesafioLocalizaBdd.Application.Models
{
    /// <summary>
    /// Modelo representacional de um cliente
    /// </summary>
    public class ClienteModel
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
        /// Cpf
        /// </summary>
        public string Cpf { get; set; }

        /// <summary>
        /// Aniversário
        /// </summary>
        public DateTime Aniversario { get; set; }

        /// <summary>
        /// Endereço
        /// </summary>
        public Endereco Endereco { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        public string Senha { get; set; }
    }

    /// <summary>
    /// Modelo representacional de Endereço
    /// </summary>
    public class Endereco
    {
        /// <summary>
        /// CEP
        /// </summary>
        public string Cep { get; set; }

        /// <summary>
        /// Logradouro
        /// </summary>
        public string Logradouro { get; set; }

        /// <summary>
        /// Número
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Complemento
        /// </summary>
        public string Complemento { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        public string Cidade { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public string Estado { get; set; }
    }
}
