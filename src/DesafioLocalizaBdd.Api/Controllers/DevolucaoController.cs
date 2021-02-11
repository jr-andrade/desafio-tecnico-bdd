using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioLocalizaBdd.Api.Controllers
{
    /// <summary>
    /// Serviço de devolução de locações
    /// </summary>
    [Route("devolucoes")]
    [ApiController]
    public class DevolucaoController : ControllerBase
    {
        private readonly IDevolucaoApplication _devolucaoApplication;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="devolucaoApplication"></param>
        public DevolucaoController(IDevolucaoApplication devolucaoApplication)
        {
            _devolucaoApplication = devolucaoApplication;
        }

        /// <summary>
        /// Checklist para devolução do veículo
        /// </summary>
        /// <param name="idLocacao"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("checklist")]
        [Authorize(Roles = Constantes.PERFIL_OPERADOR)]
        public IActionResult Post(Guid idLocacao, [FromBody]ChecklistModel model)
        {
            var resultado = _devolucaoApplication.Checklist(idLocacao, model);

            return Ok(resultado);
        }
    }
}