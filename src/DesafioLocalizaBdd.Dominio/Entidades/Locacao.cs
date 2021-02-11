using Flunt.Validations;
using System;

namespace DesafioLocalizaBdd.Domain.Entidades
{
    /// <summary>
    /// Entidade que representa uma locação
    /// </summary>
    public class Locacao : Entity
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="idVeiculo"></param>
        /// <param name="idCliente"></param>
        /// <param name="valor"></param>
        /// <param name="inicio"></param>
        /// <param name="final"></param>
        public Locacao(Guid idVeiculo, Guid idCliente, decimal valor, DateTime inicio, DateTime final)
        {
            IdVeiculo = idVeiculo;
            IdCliente = idCliente;
            Valor = valor;
            Inicio = inicio;
            Final = final;
            DataAgendamento = DateTime.Now;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(Valor, 0, nameof(Valor), "Valor da locação deve ser maior que 0")
                .IsGreaterThan(Inicio, DateTime.Now, nameof(Inicio), "Data inicial deve ser maior que data atual")
                .IsGreaterThan(Final, Inicio, nameof(Final), "Data final deve ser maior que data inicial")
            );
        }
        /// <summary>
        /// Id do Veículo
        /// </summary>
        public Guid IdVeiculo { get; private set; }

        /// <summary>
        /// Id do cliente
        /// </summary>
        public Guid IdCliente { get; private set; }

        /// <summary>
        /// Valor da locação
        /// </summary>
        public decimal Valor { get; private set; }

        /// <summary>
        /// Data e hora do início da locação
        /// </summary>
        public DateTime Inicio { get; private set; }

        /// <summary>
        /// Data e hora do final da Locação
        /// </summary>
        public DateTime Final { get; private set; }

        /// <summary>
        /// Data e Hora do agendamento
        /// </summary>
        public DateTime DataAgendamento { get; private set; }

        /// <summary>
        /// Atualiza o valor da locação
        /// </summary>
        /// <param name="valorAdicional"></param>
        public void AtualizarValorTotal(decimal valorAdicional)
        {
            Valor += valorAdicional;
        }
    }
}
