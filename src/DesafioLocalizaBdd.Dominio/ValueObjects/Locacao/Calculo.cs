using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Linq;

namespace DesafioLocalizaBdd.Domain.ValueObjects.Locacao
{
    /// <summary>
    /// Calculo de uma locação
    /// </summary>
    public class Calculo : Notifiable
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="valorHora"></param>
        /// <param name="inicio"></param>
        /// <param name="final"></param>
        public Calculo(decimal valorHora, DateTime inicio, DateTime final)
        {
            ValorHora = valorHora;
            Inicio = inicio;
            Final = final;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(ValorHora, 0, nameof(ValorHora), "Valor da hora deve ser maior que 0")
                .IsGreaterThan(Inicio, DateTime.Now, nameof(Inicio), "Data inicial deve ser maior que data atual")
                .IsGreaterThan(Final, Inicio, nameof(Final), "Data final deve ser maior que data inicial")
            );

            if (!Notifications.Any())
                CalcularValorTotal();
        }
        /// <summary>
        /// Valor Hora
        /// </summary>
        public decimal ValorHora { get; private set; }

        /// <summary>
        /// Início
        /// </summary>
        public DateTime Inicio { get; private set; }

        /// <summary>
        /// Final
        /// </summary>
        public DateTime Final { get; private set; }

        /// <summary>
        /// Valor Total
        /// </summary>
        public decimal ValorTotal { get; private set; }

        /// <summary>
        /// Cálculo do valor total
        /// </summary>
        private void CalcularValorTotal()
        {
            ValorTotal = ValorHora * (decimal)(Final - Inicio).TotalHours;
        }
    }
}
