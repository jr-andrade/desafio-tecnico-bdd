using Flunt.Notifications;
using Flunt.Validations;

namespace DesafioLocalizaBdd.Domain.ValueObjects.Cliente
{
    /// <summary>
    /// Endereço
    /// </summary>
    public class Endereco : Notifiable
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="cep"></param>
        /// <param name="logradouro"></param>
        /// <param name="numero"></param>
        /// <param name="cidade"></param>
        /// <param name="estado"></param>
        public Endereco(string cep, string logradouro, int numero, string cidade, string estado)
        {

            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;

            AddNotifications(new Contract()
                .Requires()
                
                .IsNotNullOrWhiteSpace(Cep, nameof(Cep), "CEP não pode ser nulo ou branco")
                .HasLen(Cep, 8, nameof(Cep), "CEP deve possuir 8 dígitos")
                .IsDigit(Cep, nameof(Cep), "CEP deve possuir apenas números")

                .IsNotNullOrWhiteSpace(Logradouro, nameof(Logradouro), "Logradouro não pode ser nulo ou branco")

                .IsNotNull(Numero, nameof(Numero), "Número não pode ser nulo")
                .IsGreaterThan(Numero, 0, nameof(Numero), "Número deve ser maior que 0")

                .IsNotNullOrWhiteSpace(Cidade, nameof(Cidade), "Cidade não pode ser nulo ou branco")

                .IsNotNullOrWhiteSpace(Estado, nameof(Estado), "Logradouro não pode ser nulo ou branco")
            );
        }

        /// <summary>
        /// CEP
        /// </summary>
        public string Cep { get; private set; }

        /// <summary>
        /// Logradouro
        /// </summary>
        public string Logradouro { get; private set; }

        /// <summary>
        /// Numero
        /// </summary>
        public int Numero { get; private set; }

        /// <summary>
        /// Cidade
        /// </summary>
        public string Cidade { get; private set; }

        /// <summary>
        /// Estado
        /// </summary>
        public string Estado { get; private set; }
    }
}
