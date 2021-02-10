using DesafioLocalizaBdd.Application;
using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace DesafioLocalizaBdd.Tests.Unit.Application
{
    public class ClienteApplicationTest
    {
        [Fact]
        public void CadastrarCliente_Sucesso()
        {
            //Arrange
            var guid = new Guid("3a7cff8b-f06c-4c34-8cf1-72b94e2b1df5");
            Mock<IClienteRepositorio> clienteRepositorioMock = new Mock<IClienteRepositorio>();
            clienteRepositorioMock.Setup(x => x.Cadastrar(It.IsAny<Cliente>())).Returns(guid);

            Mock<IUsuarioRepositorio> usuarioRepositorioMock = new Mock<IUsuarioRepositorio>();
            usuarioRepositorioMock.Setup(x => x.Cadastrar(It.IsAny<Usuario>())).Verifiable();

            ClienteApplication application = new ClienteApplication(clienteRepositorioMock.Object, usuarioRepositorioMock.Object);
            
            var clienteModel = new ClienteModel()
            {
                Nome = "Cliente Teste",
                Cpf = "01234567898",
                Aniversario = new DateTime(1989, 01, 01),
                Endereco = new Endereco()
                {
                    Cep = "31080170",
                    Logradouro = "Rua Direita",
                    Numero = 20,
                    Complemento = "Lado B",
                    Cidade = "Belo Horizonte",
                    Estado = "Minas Gerais"
                },
                Senha = "12345678"
            };

            //Act
            var cliente = application.Cadastrar(clienteModel);

            //Assert
            cliente.Should().NotBeNull();
            cliente.Id.Should().Be(guid);
        }

        [Fact]
        public void CadastrarCliente_DadosInvalidos()
        {
            //Arrange
            var guid = new Guid("3a7cff8b-f06c-4c34-8cf1-72b94e2b1df5");
            Mock<IClienteRepositorio> clienteRepositorioMock = new Mock<IClienteRepositorio>();
            clienteRepositorioMock.Setup(x => x.Cadastrar(It.IsAny<Cliente>())).Returns(guid);

            Mock<IUsuarioRepositorio> usuarioRepositorioMock = new Mock<IUsuarioRepositorio>();
            usuarioRepositorioMock.Setup(x => x.Cadastrar(It.IsAny<Usuario>())).Verifiable();

            ClienteApplication application = new ClienteApplication(clienteRepositorioMock.Object, usuarioRepositorioMock.Object);

            var clienteModel = new ClienteModel()
            {
                Nome = "Cliente Teste",
                Cpf = "01234567898",
                Aniversario = new DateTime(1989, 01, 01),
                Endereco = new Endereco()
                {
                    Cep = "31080170",
                    Logradouro = "Rua Direita",
                    Numero = 20,
                    Complemento = "Lado B",
                    Cidade = "Belo Horizonte",
                    Estado = "Minas Gerais"
                },
                Senha = "123456"
            };

            //Act
            var cliente = application.Cadastrar(clienteModel);

            //Assert
            cliente.Should().BeNull();
        }
    }
}
