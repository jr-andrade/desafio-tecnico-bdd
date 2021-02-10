using DesafioLocalizaBdd.Api.Controllers;
using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.Entidades;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesafioLocalizaBdd.Tests.Unit.Controller
{
    public class ClienteControllerTest : BaseControllerTest
    {
        [Fact]
        public void CadastrarCliente_Sucesso() 
        {
            //Arrange
            ClienteModel model = new ClienteModel()
            { 
                Nome = "Cliente Teste",
                Cpf = "012345678989",
                Aniversario = new DateTime(2000,01,01),
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

            Guid guid = new Guid();
            Cliente cliente = new Cliente(guid, model.Cpf, model.Aniversario);

            Mock<IClienteApplication> _clienteApplicationMock = new Mock<IClienteApplication>();
            _clienteApplicationMock.Setup(x => x.Cadastrar(It.IsAny<ClienteModel>()))
                .Returns(cliente);

            var clienteController = new ClienteController(_clienteApplicationMock.Object);

            //Act
            var resultado = clienteController.Post(model);

            //Assert
            resultado.Should().BeOfType(typeof(OkObjectResult));
            var conteudo = GetOkObject<Cliente>(resultado);
            conteudo.Should().BeSameAs(cliente);
        }
    }
}
