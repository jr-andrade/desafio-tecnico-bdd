using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.ValueObjects.Locacao;
using Serilog;
using System;

namespace DesafioLocalizaBdd.Application.Services
{
    /// <summary>
    /// Serviço de cálculos de Locação
    /// </summary>
    public class CalculoService : ICalculoService
    {
        /// <summary>
        /// Calcula o valor da locação
        /// </summary>
        /// <param name="valorHora"></param>
        /// <param name="inicio"></param>
        /// <param name="fim"></param>
        /// <returns></returns>
        public decimal Calcular(decimal valorHora, DateTime inicio, DateTime fim)
        {
            var calculo = new Calculo(valorHora, inicio, fim);

            if (calculo.Invalid)
            {
                Log.Error("Erro no cálculo da locação.");
                throw new Exception("Erro no cálculo da locação.");
            }
            return calculo.ValorTotal;
        }

        /// <summary>
        /// Calcula custo adicional
        /// </summary>
        /// <param name="valorBase"></param>
        /// <param name="checklist"></param>
        /// <returns></returns>
        public decimal CalcularCustoAdicional(decimal valorBase, ChecklistModel checklist)
        {
            var calculo = new CalculoAdicional(valorBase, checklist.CarroLimpo, checklist.TanqueCheio, checklist.PossuiAmassados, checklist.PossuiArranhoes);

            if (calculo.Invalid)
            {
                Log.Error("Erro no cálculo do custo adicional da locação.");
                throw new Exception("Erro no cálculo do custo adicional da locação.");
            }
            return calculo.ValorAdicional;
        }
    }
}
