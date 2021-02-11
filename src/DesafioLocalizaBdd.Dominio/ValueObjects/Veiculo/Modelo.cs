using Flunt.Notifications;
using Flunt.Validations;

namespace DesafioLocalizaBdd.Domain.ValueObjects.Veiculo
{
    /// <summary>
    /// Modelo de veículo
    /// </summary>
    public class Modelo : Notifiable
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="nome"></param>
        public Modelo(string nome)
        {
            Nome = nome;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(Nome, nameof(Nome), "Modelo não pode ser nulo ou branco")
            );
        }

        /// <summary>
        /// Construtor (Utilizado pelo repositório)
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="nome"></param>
        public Modelo(string codigo, string nome) : this(nome)
        {
            Codigo = codigo;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(Codigo, nameof(Codigo), "Código não pode ser nulo ou branco")
            );
        }

        /// <summary>
        /// Código
        /// </summary>
        public string Codigo { get; private set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; private set; }
    }
}
