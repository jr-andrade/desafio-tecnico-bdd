using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace DesafioLocalizaBdd.Domain.ValueObjects.Veiculo
{
    /// <summary>
    /// Combustivel de veículo
    /// </summary>
    
    public class Combustivel : Notifiable
    {
        public Combustivel(TipoCombustivel combustivel)
        {
            TipoCombustivel = combustivel;

            int count = Enum.GetValues(typeof(TipoCombustivel)).Length;

            AddNotifications(new Contract()
                .Requires()

                .IsLowerOrEqualsThan((int)TipoCombustivel, count, nameof(TipoCombustivel), "Tipo combustível inválido")
                .IsGreaterThan((int)TipoCombustivel, 0, nameof(TipoCombustivel), "Tipo combustível inválido")
            );
        }

        /// <summary>
        /// Tipo de Combustivel
        /// </summary>
        public TipoCombustivel TipoCombustivel { get; private set; }
    }

    /// <summary>
    /// Tipo de Combustivel
    /// </summary>
    public enum TipoCombustivel
    {
        gasolina = 1,
        alcool,
        diesel
    }
}
