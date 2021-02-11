using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioLocalizaBdd.Api.Controllers
{
    /// <summary>
    /// Serviço responsável pelo cadastro de clientes
    /// </summary>
    [Route("clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApplication _clienteApplication;
        private readonly IClienteRepositorio _clienteRepositorio;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="clienteApplication"></param>
        /// <param name="clienteRepositorio"></param>
        public ClienteController(IClienteApplication clienteApplication, IClienteRepositorio clienteRepositorio)
        {
            _clienteApplication = clienteApplication;
            _clienteRepositorio = clienteRepositorio;
        }

        /// <summary>
        /// Obtém um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto contendo o cliente cadastrado</returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var cliente = _clienteRepositorio.Obter(id);

            if (cliente == null)
                return NotFound("Cliente não encontrado");

            return Ok(cliente);
        }

        /// <summary>
        /// Lista os clientes cadastrados
        /// </summary>
        /// <returns>Lista de clientes cadastrados</returns>
        [HttpGet]
        public IActionResult List()
        {
            var clientes = _clienteRepositorio.Listar();

            return Ok(clientes);
        }

        /// <summary>
        /// Realiza o cadastro de um cliente
        /// </summary>
        /// <param name="clienteModel"></param>
        /// <returns>Objeto contendo o cliente cadastrado</returns>
        [HttpPost]        
        public IActionResult Post(ClienteModel clienteModel)
        {
            var resultado = _clienteApplication.Cadastrar(clienteModel);

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