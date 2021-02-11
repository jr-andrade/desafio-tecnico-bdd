using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace DesafioLocalizaBdd.Domain.ValueObjects.Veiculo
{
    /// <summary>
    /// Categoria de veículo
    /// </summary>

    public class Categoria : Notifiable
    {
        public Categoria(TipoCategoria categoria)
        {
            TipoCategoria = categoria;

            int count = Enum.GetValues(typeof(TipoCategoria)).Length;

            AddNotifications(new Contract()
                .Requires()

                .IsLowerOrEqualsThan((int)TipoCategoria, count, nameof(TipoCategoria), "Categoria inválida")
                .IsGreaterThan((int)TipoCategoria, 0, nameof(TipoCategoria), "Categoria inválida")
            );
        }

        /// <summary>
        /// Tipo de Categoria
        /// </summary>
        public TipoCategoria TipoCategoria { get; private set; }
    }

    /// <summary>
    /// Tipo de Categoria
    /// </summary>
    public enum TipoCategoria
    {
        basico = 1,
        completo,
        luxo 
    }
}
