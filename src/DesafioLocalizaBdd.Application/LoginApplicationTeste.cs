using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;
using System;

namespace DesafioLocalizaBdd.Application
{
    public class LoginApplicationTeste : ILoginApplication
    {
        private readonly ITokenService _tokenService;

        public LoginApplicationTeste(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        public Usuario Autenticar(string login, string senha)
        {
            var usuario = new Usuario(new Guid(), "09784494604", "1234", "José", "Cliente");
            
            var token = _tokenService.GerarToken(usuario);

            usuario.Autenticar(token);

            return usuario;
        }
    }
}
