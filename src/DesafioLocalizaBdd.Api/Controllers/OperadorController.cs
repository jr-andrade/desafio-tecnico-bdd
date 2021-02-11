using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioLocalizaBdd.Api.Controllers
{
    /// <summary>
    /// Serviço responsável pelo cadastro de operadores
    /// </summary>
    [Route("operadores")]
    [ApiController]
    public class OperadorController : ControllerBase
    {
        private readonly IOperadorApplication _operadorApplication;
        private readonly IOperadorRepositorio _operadorRepositorio;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="operadorApplication"></param>
        /// <param name="operadorRepositorio"></param>
        public OperadorController(IOperadorApplication operadorApplication, IOperadorRepositorio operadorRepositorio)
        {
            _operadorApplication = operadorApplication;
            _operadorRepositorio = operadorRepositorio;
        }

        /// <summary>
        /// Obtém um operador
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto contendo o operador cadastrado</returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var operador = _operadorRepositorio.Obter(id);

            if (operador == null)
                return NotFound("Operador não encontrado");

            return Ok(operador);
        }

        /// <summary>
        /// Lista os operadores cadastrados
        /// </summary>
        /// <returns>Lista de operadores cadastrados</returns>
        [HttpGet]
        public IActionResult List()
        {
            var operadores = _operadorRepositorio.Listar();

            return Ok(operadores);
        }

        /// <summary>
        /// Realiza o cadastro de um operador
        /// </summary>
        /// <param name="operadorModel"></param>
        /// <returns>Objeto contendo o operador cadastrado</returns>
        [HttpPost]
        public IActionResult Post(OperadorModel operadorModel)
        {
            var resultado = _operadorApplication.Cadastrar(operadorModel);

            if (resultado == null)
            {
                return new BadRequestObjectResult(new
                {
                    message = "Dados Inválidos!"
                });
            }

            return Ok(resultado);
        }
    }
}