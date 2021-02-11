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
    public class ClienteApplicationTest
    {
        private readonly Mock<IClienteRepositorio> _clienteRepositorioMock = new Mock<IClienteRepositorio>();
        private readonly Mock<IUsuarioRepositorio> _usuarioRepositorioMock = new Mock<IUsuarioRepositorio>();
        private ClienteApplication _application;

        [Fact]
        public void CadastrarCliente_Sucesso()
        {
            //Arrange
            var guid = new Guid("3a7cff8b-f06c-4c34-8cf1-72b94e2b1df5");
            var cliente = new Cliente(guid, "Cliente Teste", "09784494604",
                                       new DateTime(1989, 06, 22),
                                       new DesafioLocalizaBdd.Domain.ValueObjects.Cliente.Endereco(
                                               "31080170",
                                               "Rua Carmesia",
                                               1381,
                                               "Apto 302",
                                               "Belo Horizonte",
                                               "Minas Gerais"
                                       ),
                                       "12345678"
                                      );

           
            _clienteRepositorioMock.Setup(x => x.Cadastrar(It.IsAny<Cliente>())).Returns(cliente);
            _usuarioRepositorioMock.Setup(x => x.Cadastrar(It.IsAny<Usuario>())).Verifiable();

            _application = new ClienteApplication(_clienteRepositorioMock.Object, _usuarioRepositorioMock.Object);
            
            var clienteModel = new ClienteModel()
            {
                Nome = "Cliente Teste",
                Cpf = "09784494604",
                Aniversario = new DateTime(1989, 06, 22),
                Endereco = new Endereco()
                {
                    Cep = "31080170",
                    Logradouro = "Rua Carmesia",
                    Numero = 1381,
                    Complemento = "Apto 302",
                    Cidade = "Belo Horizonte",
                    Estado = "Minas Gerais"
                },
                Senha = "12345678"
            };

            //Act
            var clienteCadastrado = _application.Cadastrar(clienteModel);

            //Assert
            clienteCadastrado.Should().NotBeNull();
            clienteCadastrado.Should().BeEquivalentTo(cliente);
        }

        [Fact]
        public void CadastrarCliente_DadosInvalidos()
        {
            //Arrange
            _usuarioRepositorioMock.Setup(x => x.Cadastrar(It.IsAny<Usuario>())).Verifiable();

            _application = new ClienteApplication(_clienteRepositorioMock.Object, _usuarioRepositorioMock.Object);

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
            var cliente = _application.Cadastrar(clienteModel);

            //Assert
            cliente.Should().BeNull();
        }
    }
}
