using DesafioLocalizaBdd.Domain.Helper;
using Flunt.Notifications;
using Flunt.Validations;
using System.Linq;

namespace DesafioLocalizaBdd.Domain.ValueObjects.Locacao
{
    //TODO: polimorfismo
    /// <summary>
    /// Calculo de despesas adicionais
    /// </summary>
    public class CalculoAdicional : Notifiable
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="valorBase"></param>
        /// <param name="carroLimpo"></param>
        /// <param name="tanqueCheio"></param>
        /// <param name="possuiAmassados"></param>
        /// <param name="possuiArranhoes"></param>
        public CalculoAdicional(decimal valorBase, bool carroLimpo, bool tanqueCheio, bool possuiAmassados, bool possuiArranhoes)
        {
            ValorBase = valorBase;
            CarroLimpo = carroLimpo;
            TanqueCheio = tanqueCheio;
            PossuiAmassados = possuiAmassados;
            PossuiArranhoes = possuiArranhoes;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(ValorBase, 0, nameof(ValorBase), "Valor base deve ser maior que 0")
            );

            if (!Notifications.Any())
                CalcularValorAdicional();
        }

        /// <summary>
        /// Valor base
        /// </summary>
        public decimal ValorBase { get; private set; }

        /// <summary>
        /// Está limpo
        /// </summary>
        public bool CarroLimpo { get; private set; }

        /// <summary>
        /// Tanque está cheio
        /// </summary>
        public bool TanqueCheio { get; private set; }

        /// <summary>
        /// Possui Amassados
        /// </summary>
        public bool PossuiAmassados { get; private set; }

        /// <summary>
        /// Possui arranhoes
        /// </summary>
        public bool PossuiArranhoes { get; private set; }

        /// <summary>
        /// Valor total
        /// </summary>
        public decimal ValorAdicional { get; private set; }

        /// <summary>
        /// Porcentagem de cobrança por ocorrência
        /// </summary>
        public decimal PorcentagemCobranca {
            get
            {
                return Constantes.PORCENTAGEM_COBRANCA_ADICIONAL;
            }
        }

        /// <summary>
        /// Calcula o valor total
        /// </summary>
        private void CalcularValorAdicional()
        {
            int multiplicador = (!CarroLimpo ? 1 : 0) + (!TanqueCheio ? 1 : 0) + (PossuiAmassados ? 1 : 0) + (PossuiArranhoes ? 1 : 0);
            ValorAdicional = ValorBase * PorcentagemCobranca * multiplicador;
        }
    }
}
