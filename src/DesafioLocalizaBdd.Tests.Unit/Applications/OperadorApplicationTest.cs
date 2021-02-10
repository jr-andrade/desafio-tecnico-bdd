using DesafioLocalizaBdd.Application;
using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace DesafioLocalizaBdd.Tests.Unit.Applications
{
    public class OperadorApplicationTest
    {
        [Fact]
        public void Cadastrar_Operador_Sucesso()
        {
            //Arrange
            var guid = new Guid("e203f137-db86-44fa-b7c9-c331414611cd");
            Mock<IOperadorRepositorio> operadorRepositorioMock = new Mock<IOperadorRepositorio>();
            operadorRepositorioMock.Setup(x => x.Cadastrar(It.IsAny<Operador>())).Returns(guid);

            Mock<IUsuarioRepositorio> usuarioRepositorioMock = new Mock<IUsuarioRepositorio>();
            usuarioRepositorioMock.Setup(x => x.Cadastrar(It.IsAny<Usuario>())).Verifiable();

            var application = new OperadorApplication(operadorRepositorioMock.Object, usuarioRepositorioMock.Object);

            var operadorModel = new OperadorModel()
            {
                Nome = "Operador Teste",
                Matricula = "130364",
                Senha = "12345678"
            };

            //Act
            var operador = application.Cadastrar(operadorModel);

            //Assert
            operador.Should().NotBeNull();
            operador.Id.Should().Be(guid);
        }

        [Fact]
        public void Cadastrar_Operador_DadosInvalidos()
        {
            //Arrange
            Mock<IOperadorRepositorio> operadorRepositorioMock = new Mock<IOperadorRepositorio>();
            operadorRepositorioMock.Setup(x => x.Cadastrar(It.IsAny<Operador>())).Returns(new Guid("e203f137-db86-44fa-b7c9-c331414611cd"));

            Mock<IUsuarioRepositorio> usuarioRepositorioMock = new Mock<IUsuarioRepositorio>();
            usuarioRepositorioMock.Setup(x => x.Cadastrar(It.IsAny<Usuario>())).Verifiable();

            var application = new OperadorApplication(operadorRepositorioMock.Object, usuarioRepositorioMock.Object);

            var operadorModel = new OperadorModel()
            {
                Nome = "Operador Teste",
                Matricula = "130364",
                Senha = "12345"
            };

            //Act
            var operador = application.Cadastrar(operadorModel);

            //Assert
            operador.Should().BeNull();
        }
    }
}
