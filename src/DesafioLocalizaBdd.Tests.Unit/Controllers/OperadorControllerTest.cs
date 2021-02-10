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
    public class OperadorControllerTest : BaseControllerTest
    {
        private readonly Mock<IOperadorApplication> _operadorApplicationMock = new Mock<IOperadorApplication>();
        private readonly Mock<IOperadorRepositorio> _operadorRepositorioMock = new Mock<IOperadorRepositorio>();
        private OperadorController _operadorController;

        private readonly Operador _operador = new Operador("Operador Teste", "130364", "12345678");
        private readonly Operador _operador2 = new Operador("Operador Teste2", "130365", "32165498");
        private readonly List<Operador> _operadores;

        public OperadorControllerTest()
        {
            _operadores = new List<Operador>() { _operador, _operador2 };
        }

        [Fact]
        public void Obter_Operador_Sucesso()
        {
            //Arrange
            var guid = new Guid("6fcbab54-bb44-4cc4-8471-bc339ba5b097");
            _operador.AtualizarId(guid);
            _operadorRepositorioMock.Setup(x => x.Obter(It.IsAny<Guid>())).Returns(_operador);

            _operadorController = new OperadorController(_operadorApplicationMock.Object, _operadorRepositorioMock.Object);

            //Act
            var resultado = _operadorController.Get(guid);

            //Assert
            resultado.Should().BeOfType(typeof(OkObjectResult));
            var conteudo = GetOkObject<Operador>(resultado);
            conteudo.Should().BeSameAs(_operador);
        }

        [Fact]
        public void Obter_Operador_NaoEncontrado()
        {
            //Arrange
            var guid = new Guid("3140bed0-44b9-446a-9e38-b616b5f3ff71");

            _operadorRepositorioMock.Setup(x => x.Obter(It.IsAny<Guid>())).Returns((Operador)null);

            _operadorController = new OperadorController(_operadorApplicationMock.Object, _operadorRepositorioMock.Object);

            //Act
            var resultado = _operadorController.Get(guid);

            //Assert
            resultado.Should().BeOfType(typeof(NotFoundObjectResult));
        }

        [Fact]
        public void Listar_Operadores_Sucesso()
        {
            //Arrange
            _operadorRepositorioMock.Setup(x => x.Listar()).Returns(_operadores);
            _operadorController = new OperadorController(_operadorApplicationMock.Object, _operadorRepositorioMock.Object);

            //Act
            var resultado = _operadorController.List();

            //Assert
            resultado.Should().BeOfType(typeof(OkObjectResult));
            var conteudo = GetOkObject<IEnumerable<Operador>>(resultado);
            conteudo.Should().BeSameAs(_operadores);
        }

        [Fact]
        public void CadastrarOperador_Sucesso()
        {
            //Arrange
            var model = new OperadorModel()
            {
                Nome = "Operador Teste",
                Matricula = "130364"
            };

            Guid guid = new Guid("48c671bf-6ca1-4da0-8238-ca3f97050ec0");
            _operador.AtualizarId(guid);

            _operadorApplicationMock.Setup(x => x.Cadastrar(It.IsAny<OperadorModel>()))
                .Returns(_operador);

            _operadorRepositorioMock.Setup(x => x.Cadastrar(It.IsAny<Operador>())).Verifiable();

            _operadorController = new OperadorController(_operadorApplicationMock.Object, _operadorRepositorioMock.Object);

            //Act
            var resultado = _operadorController.Post(model);

            //Assert
            resultado.Should().BeOfType(typeof(OkObjectResult));
            var conteudo = GetOkObject<Operador>(resultado);
            conteudo.Should().BeSameAs(_operador);
        }

        [Fact]
        public void CadastrarOperador_DadosInvalidos()
        {
            //Arrange
            var model = new OperadorModel()
            {
                Nome = "Operador Teste",
                Matricula = "13036456"
            };

            _operadorApplicationMock.Setup(x => x.Cadastrar(It.IsAny<OperadorModel>()))
                .Returns((Operador)null);

            _operadorRepositorioMock.Setup(x => x.Cadastrar(It.IsAny<Operador>())).Verifiable();

            _operadorController = new OperadorController(_operadorApplicationMock.Object, _operadorRepositorioMock.Object);

            //Act
            var resultado = _operadorController.Post(model);

            //Assert
            resultado.Should().BeOfType(typeof(BadRequestObjectResult));
        }
    }
}
