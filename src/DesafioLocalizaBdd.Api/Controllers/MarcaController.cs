using DesafioLocalizaBdd.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioLocalizaBdd.Api.Controllers
{
    /// <summary>
    /// Serviço de cadastro de marcas de veículos
    /// </summary>
    [Route("marcas")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaRepositorio _marcaRepositorio;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="marcaRepositorio"></param>
        public MarcaController(IMarcaRepositorio marcaRepositorio)
        {
            _marcaRepositorio = marcaRepositorio;
        }

        /// <summary>
        /// Obtém uma marca
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns>Objeto contendo a marca cadastrada</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get(string codigo)
        {
            var marca = _marcaRepositorio.Obter(codigo);

            if (marca == null)
                return NotFound("Marca não encontrada!");

            return Ok(marca);
        }

        /// <summary>
        /// Lista as marcas cadastrados
        /// </summary>
        /// <returns>Lista das marcas cadastrados</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult List()
        {
            var marcas = _marcaRepositorio.Listar();

            return Ok(marcas);
        }

        /// <summary>
        /// Realiza o cadastro de uma marca
        /// </summary>
        /// <param name="marca"></param>
        /// <returns>Objeto contendo a marca cadastrada</returns>
        [HttpPost]
        [Authorize(Roles = "Operador")]
        public IActionResult Post(string marca)
        {
            if (string.IsNullOrWhiteSpace(marca))
            {
                return new BadRequestObjectResult(new
                {
                    message = "Informe a marca!"
                });
            }

            var resultado = _marcaRepositorio.Cadastrar(marca);

            return Created($"/marcas/{resultado.Codigo}", resultado);
        }
    }
}