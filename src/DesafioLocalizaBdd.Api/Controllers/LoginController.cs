using DesafioLocalizaBdd.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioLocalizaBdd.Api.Controllers
{
    /// <summary>
    /// Serviço de Login
    /// </summary>
    [Route("api/[controller]")]
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
        public IActionResult Post(string login, string senha)
        {
            var usuario = _loginApplication.Autenticar(login, senha);

            return Ok(usuario);
        }
    }
}