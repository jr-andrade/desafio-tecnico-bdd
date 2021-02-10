using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioLocalizaBdd.Api.Controllers
{
    /// <summary>
    /// Serviço responsável pelo cadastro de clientes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApplication _clienteApplication;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="clienteApplication"></param>
        public ClienteController(IClienteApplication clienteApplication)
        {
            _clienteApplication = clienteApplication;
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

            return Ok(resultado);

            //if (result.Success)
            //    return Created($"/clientes/{result.Object.Id}", _mapper.Map<Cliente, ClienteModel>(result.Object));

            //return BadRequest(result.Notifications);
        }
    }
}