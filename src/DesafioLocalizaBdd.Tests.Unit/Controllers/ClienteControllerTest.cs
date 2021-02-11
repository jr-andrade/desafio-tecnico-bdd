using DesafioLocalizaBdd.Api.Controllers;
using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DesafioLocalizaBdd.Tests.Unit.Controllers
{
    public class ClienteControllerTest : BaseControllerTest
    {
        private readonly Mock<IClienteApplication> _clienteApplicationMock = new Mock<IClienteApplication>();
        private readonly Mock<IClienteRepositorio> _clienteRepositorioMock = new Mock<IClienteRepositorio>();
        private ClienteController _clienteController;

        private readonly Cliente _cliente = new Cliente(new Guid("d0feaa4e-f5aa-474a-9863-9d6b2964977e"), "Cliente Teste", "01234567898", new DateTime(1989, 01, 01),
                                    new DesafioLocalizaBdd.Domain.ValueObjects.Cliente.Endereco(
                                        "31080170",
                                        "Rua Direita",
                                        20,
                                        "Lado B",
                                        "Belo Horizonte",
                                        "Minas Gerais"),
                                    "12345678"
                                  );

        private readonly Cliente _cliente2 = new Cliente(new Guid("a61e52c5-7c25-4fa8-a8f3-8d793d319199"), "Cliente Teste 2", "98765432123", new DateTime(1995, 01, 01),
                                        new DesafioLocalizaBdd.Domain.ValueObjects.Cliente.Endereco(
                                            "31080170",
                                            "Rua Direita",
                                            20,
                                            "Lado B",
                                            "Belo Horizonte",
                                            "Minas Gerais"),
                                        "12345678"
                                      );

        private readonly List<Cliente> _clientes;

        public ClienteControllerTest()
        {
            _clientes = new List<Cliente>() { _cliente, _cliente2 };
        }
        
        [Fact]
        public void Obter_Cliente_Sucesso()
        {
            //Arrange
            var guid = new Guid("d0feaa4e-f5aa-474a-9863-9d6b2964977e");

            _clienteRepositorioMock.Setup(x => x.Obter(guid)).Returns(_cliente);

            _clienteController = new ClienteController(_clienteApplicationMock.Object, _clienteRepositorioMock.Object);

            //Act
            var resultado = _clienteController.Get(guid);

            //Assert
            resultado.Should().BeOfType(typeof(OkObjectResult));
            var conteudo = GetOkObject<Cliente>(resultado);
            conteudo.Should().BeSameAs(_cliente);
        }

        [Fact]
        public void Obter_Cliente_NaoEncontrado()
        {
            //Arrange
            var guid = new Guid("270842ec-2b88-4e30-aca0-15fccdaeaf3d");
            
            _clienteRepositorioMock.Setup(x => x.Obter(guid)).Returns((Cliente)null);

            _clienteController = new ClienteController(_clienteApplicationMock.Object, _clienteRepositorioMock.Object);

            //Act
            var resultado = _clienteController.Get(guid);

            //Assert
            resultado.Should().BeOfType(typeof(NotFoundObjectResult));
        }

        [Fact]
        public void Listar_Clientes_Sucesso()
        {
            //Arrange
            _clienteRepositorioMock.Setup(x => x.Listar()).Returns(_clientes);
            _clienteController = new ClienteController(_clienteApplicationMock.Object, _clienteRepositorioMock.Object);

            //Act
            var resultado = _clienteController.List();

            //Assert
            resultado.Should().BeOfType(typeof(OkObjectResult));
            var conteudo = GetOkObject<IEnumerable<Cliente>>(resultado);
            conteudo.Should().BeSameAs(_clientes);
        }

        [Fact]
        public void CadastrarCliente_Sucesso() 
        {
            //Arrange
            ClienteModel model = new ClienteModel()
            { 
                Nome = "Cliente Teste",
                Cpf = "01234567898",
                Aniversario = new DateTime(1989,01,01),
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

            Guid guid = new Guid("a61e52c5-7c25-4fa8-a8f3-8d793d319199");
            
            _clienteApplicationMock.Setup(x => x.Cadastrar(It.IsAny<ClienteModel>()))
                .Returns(_cliente2);
            
            _clienteRepositorioMock.Setup(x => x.Cadastrar(It.IsAny<Cliente>())).Verifiable();

            _clienteController = new ClienteController(_clienteApplicationMock.Object, _clienteRepositorioMock.Object);

            //Act
            var resultado = _clienteController.Post(model);

            //Assert
            resultado.Should().BeOfType(typeof(OkObjectResult));
            var conteudo = GetOkObject<Cliente>(resultado);
            conteudo.Should().BeSameAs(_cliente2);
        }

        [Fact]
        public void CadastrarCliente_DadosInvalidos()
        {
            //Arrange
            ClienteModel model = new ClienteModel()
            {
                Nome = "Cliente Teste",
                Cpf = "01234567898",
                Aniversario = new DateTime(1989, 01, 01),
                Endereco = null,
                Senha = "12345678"
            };

            _clienteApplicationMock.Setup(x => x.Cadastrar(It.IsAny<ClienteModel>()))
                .Returns((Cliente)null);

            _clienteRepositorioMock.Setup(x => x.Cadastrar(It.IsAny<Cliente>())).Verifiable();

            _clienteController = new ClienteController(_clienteApplicationMock.Object, _clienteRepositorioMock.Object);

            //Act
            var resultado = _clienteController.Post(model);

            //Assert
            resultado.Should().BeOfType(typeof(BadRequestObjectResult));
        }
    }
}
