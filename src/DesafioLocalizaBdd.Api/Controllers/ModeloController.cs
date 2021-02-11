using DesafioLocalizaBdd.Domain.Helper;
using DesafioLocalizaBdd.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioLocalizaBdd.Api.Controllers
{
    /// <summary>
    /// Serviço de cadastro de modelos de veículos
    /// </summary>
    [Route("modelos")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly IModeloRepositorio _modeloRepositorio;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="modeloRepositorio"></param>
        public ModeloController(IModeloRepositorio modeloRepositorio)
        {
            _modeloRepositorio = modeloRepositorio;
        }

        /// <summary>
        /// Obtém um modelo
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns>Objeto contendo o modelo cadastrado</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("{codigo}")]
        public IActionResult Get(string codigo)
        {
            var modelo = _modeloRepositorio.Obter(codigo);

            if (modelo == null)
                return NotFound("Modelo não encontrado");

            return Ok(modelo);
        }

        /// <summary>
        /// Lista os modelos cadastrados
        /// </summary>
        /// <returns>Lista dos modelos cadastrados</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult List()
        {
            var modelos = _modeloRepositorio.Listar();

            return Ok(modelos);
        }

        /// <summary>
        /// Realiza o cadastro de um modelo
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns>Objeto contendo o modelo cadastrado</returns>
        [HttpPost]
        [Authorize(Roles = Constantes.PERFIL_OPERADOR)]
        [Route("{modelo}")]
        public IActionResult Post(string modelo)
        {
            if (string.IsNullOrWhiteSpace(modelo))
            {
                return new BadRequestObjectResult(new
                {
                    message = "Informe o modelo!"
                });
            }
            
            var resultado = _modeloRepositorio.Cadastrar(modelo);

            return Created($"/modelos/{resultado.Codigo}", resultado);
        }
    }
}