using DesafioLocalizaBdd.Api.Controllers;
using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Domain.Entidades;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace DesafioLocalizaBdd.Tests.Unit.Controllers
{
    public class LoginControllerTest : BaseControllerTest
    {
        private readonly Mock<ILoginApplication> applicationMock = new Mock<ILoginApplication>();

        [Fact]
        public void Login_Sucesso()
        {
            //Arrange
            var cliente = new Cliente(new Guid(), "09784494604", new DateTime(1989, 06, 22));
            var token = "xyzToken";
            cliente.Autenticar(token);

            applicationMock.Setup(x => x.Autenticar(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(cliente);

            var controller = new LoginController(applicationMock.Object);

            //Act
            var resultadoLogin = controller.Post("09784494604", "123456");
            var usuario = GetOkObject<Usuario>(resultadoLogin);

            //Assert
            usuario.Token.Should().NotBeNull();
        }

        [Theory]
        [InlineData("","")]
        [InlineData("130364", "")]
        [InlineData("", "123456")]
        public void Login_BadRequest(string login, string senha)
        {
            //Arrange
            var controller = new LoginController(applicationMock.Object);

            //Act
            var resultado = controller.Post(login, senha);

            //Assert
            resultado.Should().BeOfType(typeof(BadRequestObjectResult));
        }

        [Fact]
        public void Login_CredenciaisInvalidas()
        {
            //Arrange
            applicationMock.Setup(x => x.Autenticar(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((Usuario)null);

            var controller = new LoginController(applicationMock.Object);

            //Act
            var resultado = controller.Post("09784494604", "987654");

            //Assert
            resultado.Should().BeOfType(typeof(NotFoundObjectResult));
        }
    }
}
