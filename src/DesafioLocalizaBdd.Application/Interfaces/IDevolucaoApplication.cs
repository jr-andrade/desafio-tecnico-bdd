using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.Entidades;
using System;

namespace DesafioLocalizaBdd.Application.Interfaces
{
    /// <summary>
    /// Interface para a aplicação de devolução
    /// </summary>
    public interface IDevolucaoApplication
    {
        /// <summary>
        /// Checklist para vistoria do veículo
        /// </summary>
        /// <param name="idLocacao"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public Locacao Checklist(Guid idLocacao, ChecklistModel model);
    }
}
