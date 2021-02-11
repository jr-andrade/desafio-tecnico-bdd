using Flunt.Notifications;
using Flunt.Validations;

namespace DesafioLocalizaBdd.Domain.ValueObjects.Veiculo
{
    /// <summary>
    /// Marca de veículo
    /// </summary>
    public class Marca : Notifiable
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="nome"></param>
        public Marca(string nome)
        {
            Nome = nome;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(Nome, nameof(Nome), "Marca não pode ser nula ou branca")
            );
        }

        /// <summary>
        /// Construtor (Utilizado pelo repositório)
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="nome"></param>
        public Marca(string codigo, string nome) : this(nome)
        {
            Codigo = codigo;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(Codigo, nameof(Codigo), "Código não pode ser nula ou branca")
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
