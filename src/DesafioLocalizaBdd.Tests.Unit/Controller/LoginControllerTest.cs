using DesafioLocalizaBdd.Api.Controllers;
using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Domain.Entidades;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace DesafioLocalizaBdd.Tests.Unit.Controller
{
    public class LoginControllerTest
    {
        [Fact]
        public void Login_Sucesso()
        {
            var cliente = new Cliente(new Guid(), "09784494604", new DateTime(1989, 06, 22));
            var token = "xyzToken";
            cliente.Autenticar(token);

            Mock<ILoginApplication> application = new Mock<ILoginApplication>();

            application.Setup(x => x.Autenticar(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(cliente);

            var controller = new LoginController(application.Object);

            var resultadoLogin = controller.Post("09784494604", "123456");

            var usuario = GetOkObject<Usuario>(resultadoLogin);

            //Usuário deverá possuir token de autenticação
            usuario.Token.Should().NotBeNull();

        }

        [Fact]
        public void Login_BadRequest()
        {
            Mock<ILoginApplication> application = new Mock<ILoginApplication>();
            var controller = new LoginController(application.Object);

            var resultado = controller.Post("", "");

            resultado.Should().BeOfType(typeof(BadRequestResult));

        }

        protected T GetOkObject<T>(IActionResult result)
        {
            var okObjectResult = (OkObjectResult)result;
            return (T)okObjectResult.Value;
        }
    }
}
