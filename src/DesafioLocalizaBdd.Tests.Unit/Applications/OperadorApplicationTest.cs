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
        private readonly Mock<IOperadorRepositorio> _operadorRepositorioMock = new Mock<IOperadorRepositorio>();
        private readonly Mock<IUsuarioRepositorio> _usuarioRepositorioMock = new Mock<IUsuarioRepositorio>();

        [Fact]
        public void Cadastrar_Operador_Sucesso()
        {
            //Arrange
            var guid = new Guid("e203f137-db86-44fa-b7c9-c331414611cd");
            var operador = new Operador(guid, "Operador Teste", "130364", "12345678");

            _operadorRepositorioMock.Setup(x => x.Cadastrar(It.IsAny<Operador>())).Returns(operador);
            
            _usuarioRepositorioMock.Setup(x => x.Cadastrar(It.IsAny<Usuario>())).Verifiable();

            var application = new OperadorApplication(_operadorRepositorioMock.Object, _usuarioRepositorioMock.Object);

            var operadorModel = new OperadorModel()
            {
                Nome = "Operador Teste",
                Matricula = "130364",
                Senha = "12345678"
            };

            //Act
            var operadorCadastrado = application.Cadastrar(operadorModel);

            //Assert
            operadorCadastrado.Should().NotBeNull();
            operadorCadastrado.Should().BeEquivalentTo(operador);
        }

        [Fact]
        public void Cadastrar_Operador_DadosInvalidos()
        {
            //Arrange
            var application = new OperadorApplication(_operadorRepositorioMock.Object, _usuarioRepositorioMock.Object);

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
