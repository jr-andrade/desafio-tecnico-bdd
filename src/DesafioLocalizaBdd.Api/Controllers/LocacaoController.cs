using DesafioLocalizaBdd.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace DesafioLocalizaBdd.Api.Controllers
{
    /// <summary>
    /// Serviço de locações
    /// </summary>
    [Route("locacoes")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoApplication _locacaoApplication;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="locacaoApplication"></param>
        public LocacaoController(ILocacaoApplication locacaoApplication)
        {
            _locacaoApplication = locacaoApplication;
        }

        /// <summary>
        /// Simula uma locação
        /// </summary>
        /// <param name="veiculoId"></param>
        /// <param name="inicio"></param>
        /// <param name="fim"></param>
        /// <returns>valor da locação</returns>
        [HttpGet]
        [Route("simular")]
        [AllowAnonymous]
        public IActionResult Get(Guid veiculoId, DateTime inicio, DateTime fim)
        {
            var valor = _locacaoApplication.Estimar(veiculoId, inicio, fim);

            return Ok(valor);
        }

        /// <summary>
        /// Agenda uma locação
        /// </summary>
        /// <param name="veiculoId"></param>
        /// <param name="inicio"></param>
        /// <param name="fim"></param>
        /// <returns>Locação agendada</returns>
        [HttpPost]
        [Route("agendar")]
        [Authorize(Roles = "Cliente")]
        public IActionResult Post(Guid veiculoId, DateTime inicio, DateTime fim)
        {
            var clienteId = new Guid(User.Identity.Name);
            var locacao = _locacaoApplication.Agendar(veiculoId, clienteId, inicio, fim);

            return Ok(locacao);
        }

        /// <summary>
        /// Faz download de um modelo de contrato
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("download")]
        public IActionResult Download()
        {
            var stream = new FileStream(@".\Documents\ModeloContratoLocacao.pdf", FileMode.Open, FileAccess.Read);
            
            return File(stream, "application/pdf", "ModeloContratoLocacao.pdf");
        }
    }
}