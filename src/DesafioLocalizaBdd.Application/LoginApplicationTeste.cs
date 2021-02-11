using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Domain.Entidades;
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
            Usuario usuario;

            if (login == "09784494604")
                usuario = new Usuario(new Guid("67b7ebc4-fcf1-45fa-a35e-b0c68ec57b89"), "09784494604", senha, "José Cliente", "Cliente");

            else usuario = new Usuario(new Guid("35c68591-0e87-467e-b71f-da8c3971110a"), "130364", senha, "José Operador", "Operador");
            
            var token = _tokenService.GerarToken(usuario);

            usuario.Autenticar(token);

            return usuario;
        }
    }
}
