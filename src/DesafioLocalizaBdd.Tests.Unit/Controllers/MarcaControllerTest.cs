using DesafioLocalizaBdd.Api.Controllers;
using DesafioLocalizaBdd.Domain.Interfaces;
using DesafioLocalizaBdd.Domain.ValueObjects.Veiculo;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace DesafioLocalizaBdd.Tests.Unit.Controllers
{
    public class MarcaControllerTest : BaseControllerTest
    {
        private MarcaController _marcaController;

        private readonly Mock<IMarcaRepositorio> _marcaRepositorioMock = new Mock<IMarcaRepositorio>();

        private readonly Marca _marca = new Marca("Ford");
        private readonly Marca _marca2 = new Marca("Fiat");
        private readonly List<Marca> _marcas;

        public MarcaControllerTest()
        {
            _marcas = new List<Marca>() { _marca, _marca2 };
        }

        [Fact]
        public void Obter_Marca_Sucesso()
        {
            //Arrange
            var marca = "Ford";

            _marcaRepositorioMock.Setup(x => x.Obter(marca)).Returns(_marca);

            _marcaController = new MarcaController(_marcaRepositorioMock.Object);

            //Act
            var resultado = _marcaController.Get(marca);

            //Assert
            resultado.Should().BeOfType(typeof(OkObjectResult));
            var conteudo = GetOkObject<Marca>(resultado);
            conteudo.Should().BeSameAs(_marca);
        }

        [Fact]
        public void Obter_Marca_NaoEncontrada()
        {
            //Arrange
            var marca = "Jeep";

            _marcaRepositorioMock.Setup(x => x.Obter(marca)).Returns((Marca)null);

            _marcaController = new MarcaController(_marcaRepositorioMock.Object);

            //Act
            var resultado = _marcaController.Get(marca);

            //Assert
            resultado.Should().BeOfType(typeof(NotFoundObjectResult));
        }

        [Fact]
        public void Listar_Marcas_Sucesso()
        {
            //Arrange
            _marcaRepositorioMock.Setup(x => x.Listar()).Returns(_marcas);

            _marcaController = new MarcaController(_marcaRepositorioMock.Object);

            //Act
            var resultado = _marcaController.List();

            //Assert
            resultado.Should().BeOfType(typeof(OkObjectResult));
            var conteudo = GetOkObject<IEnumerable<Marca>>(resultado);
            conteudo.Should().BeSameAs(_marcas);
        }

        [Fact]
        public void Cadastrar_Marca_Sucesso()
        {
            //Arrange
            var marca = "Fiat";

            Marca marcaObject = new Marca(marca);

            _marcaRepositorioMock.Setup(x => x.Cadastrar(marca)).Returns(marcaObject);

            _marcaController = new MarcaController(_marcaRepositorioMock.Object);

            var resultado = _marcaController.Post(marca);

            //Assert
            resultado.Should().BeOfType(typeof(CreatedResult));
            var conteudo = GetCreatedObject<Marca>(resultado);
            conteudo.Should().Be(marcaObject);
        }

        [Fact]
        public void Cadastrar_Marca_DadosInvalidos()
        {
            //Arrange
            _marcaController = new MarcaController(_marcaRepositorioMock.Object);

            //Act
            var resultado = _marcaController.Post("");

            //Assert
            resultado.Should().BeOfType(typeof(BadRequestObjectResult));
        }
    }
}
