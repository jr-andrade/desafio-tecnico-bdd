using DesafioLocalizaBdd.Application.Models;
using System;

namespace DesafioLocalizaBdd.Application.Interfaces
{
    /// <summary>
    /// Interface para o serviço de cálculos de locação
    /// </summary>
    public interface ICalculoService
    {
        /// <summary>
        /// Calcula uma locação
        /// </summary>
        /// <param name="valorHora"></param>
        /// <param name="inicio"></param>
        /// <param name="fim"></param>
        /// <returns></returns>
        public decimal Calcular(decimal valorHora, DateTime inicio, DateTime fim);

        /// <summary>
        /// Calcula o custo adicional 
        /// </summary>
        /// <param name="valorBase"></param>
        /// <param name="checklist"></param>
        /// <returns></returns>
        public decimal CalcularCustoAdicional(decimal valorBase, ChecklistModel checklist);
    }
}
