using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.Helper;
using DesafioLocalizaBdd.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioLocalizaBdd.Api.Controllers
{
    /// <summary>
    /// Serviço de cadastro de veículos
    /// </summary>
    [Route("veiculos")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoApplication _veiculoApplication;
        private readonly IVeiculoRepositorio _veiculoRepositorio;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="veiculoApplication"></param>
        /// <param name="veiculoRepositorio"></param>
        public VeiculoController(IVeiculoApplication veiculoApplication, IVeiculoRepositorio veiculoRepositorio)
        {
            _veiculoApplication = veiculoApplication;
            _veiculoRepositorio = veiculoRepositorio;
        }

        /// <summary>
        /// Obtém um veículo
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto contendo o veículo cadastrado</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var veiculo = _veiculoRepositorio.Obter(id);

            if (veiculo == null)
                return NotFound("Veículo não encontrado");

            return Ok(veiculo);
        }

        /// <summary>
        /// Lista os veículos cadastrados
        /// </summary>
        /// <returns>Lista dos veículos cadastrados</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult List()
        {
            var veiculos = _veiculoRepositorio.Listar();

            return Ok(veiculos);
        }

        /// <summary>
        /// Realiza o cadastro de um veículo
        /// </summary>
        /// <param name="veiculoModel"></param>
        /// <returns>Objeto contendo o veículo cadastrado</returns>
        [HttpPost]
        [Authorize(Roles = Constantes.PERFIL_OPERADOR)]
        public IActionResult Post([FromBody]VeiculoModel veiculoModel)
        {
            var resultado = _veiculoApplication.Cadastrar(veiculoModel);

            if (resultado == null)
            {
                return new BadRequestObjectResult(new
                {
                    message = "Dados Inválidos!"
                });
            }

            return Created($"/veiculos/{resultado.Id}", resultado);
        }
    }
}