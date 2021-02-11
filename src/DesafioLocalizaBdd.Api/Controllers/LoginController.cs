using DesafioLocalizaBdd.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioLocalizaBdd.Api.Controllers
{
    /// <summary>
    /// Serviço de Login
    /// </summary>
    [Route("login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginApplication _loginApplication;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="loginApplication"></param>
        public LoginController(ILoginApplication loginApplication)
        {
            _loginApplication = loginApplication;
        }

        /// <summary>
        /// Realiza a autenticação
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <returns>Objeto contendo o usuário autenticado</returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post(string login, string senha)
        {
            if(string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(senha)) 
            {
                return new BadRequestObjectResult(new 
                {
                    message = "Informe o login e a senha!"
                });
            }

            var usuario = _loginApplication.Autenticar(login, senha);

            if (usuario == null) 
            {
                return new NotFoundObjectResult(new 
                { 
                    message = "Login e/ou senha inválidos!" 
                });
            }

            return Ok(usuario);
        }

        //TODO: Rotas para teste de autorização, remover!
        [HttpGet]
        [Route("cliente")]
        [Authorize(Roles = "Cliente")]
        public string Cliente() => "Cliente";

        [HttpGet]
        [Route("operador")]
        [Authorize(Roles = "Operador")]
        public string Operador() => "Operador";
    }
}