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
    public class ModeloControllerTest : BaseControllerTest
    {
        private ModeloController _modeloController;

        private readonly Mock<IModeloRepositorio> _modeloRepositorioMock = new Mock<IModeloRepositorio>();

        private readonly Modelo _modelo = new Modelo("Fusion");
        private readonly Modelo _modelo2 = new Modelo("Fiesta");
        private readonly List<Modelo> _modelos;

        public ModeloControllerTest()
        {
            _modelos = new List<Modelo>() { _modelo, _modelo2 };
        }

        [Fact]
        public void Obter_Modelo_Sucesso()
        {
            //Arrange
            var modelo = "Fiesta";

            _modeloRepositorioMock.Setup(x => x.Obter(modelo)).Returns(_modelo2);

            _modeloController = new ModeloController(_modeloRepositorioMock.Object);

            //Act
            var resultado = _modeloController.Get(modelo);

            //Assert
            resultado.Should().BeOfType(typeof(OkObjectResult));
            var conteudo = GetOkObject<Modelo>(resultado);
            conteudo.Should().BeSameAs(_modelo2);
        }

        [Fact]
        public void Obter_Modelo_NaoEncontrado()
        {
            //Arrange
            var modelo = "Argo";

            _modeloRepositorioMock.Setup(x => x.Obter(modelo)).Returns((Modelo)null);

            _modeloController = new ModeloController(_modeloRepositorioMock.Object);

            //Act
            var resultado = _modeloController.Get(modelo);

            //Assert
            resultado.Should().BeOfType(typeof(NotFoundObjectResult));
        }

        [Fact]
        public void Listar_Modelos_Sucesso()
        {
            //Arrange
            _modeloRepositorioMock.Setup(x => x.Listar()).Returns(_modelos);

            _modeloController = new ModeloController(_modeloRepositorioMock.Object);

            //Act
            var resultado = _modeloController.List();

            //Assert
            resultado.Should().BeOfType(typeof(OkObjectResult));
            var conteudo = GetOkObject<IEnumerable<Modelo>>(resultado);
            conteudo.Should().BeSameAs(_modelos);
        }

        [Fact]
        public void Cadastrar_Modelo_Sucesso()
        {
            //Arrange
            var modelo = "Argo";

            Modelo modeloObject = new Modelo(modelo);

            _modeloRepositorioMock.Setup(x => x.Cadastrar(modelo)).Returns(modeloObject);

            _modeloController = new ModeloController(_modeloRepositorioMock.Object);

            var resultado = _modeloController.Post(modelo);

            //Assert
            resultado.Should().BeOfType(typeof(CreatedResult));
            var conteudo = GetCreatedObject<Modelo>(resultado);
            conteudo.Should().Be(modeloObject);
        }

        [Fact]
        public void Cadastrar_Modelo_DadosInvalidos()
        {
            //Arrange
            _modeloController = new ModeloController(_modeloRepositorioMock.Object);

            //Act
            var resultado = _modeloController.Post("");

            //Assert
            resultado.Should().BeOfType(typeof(BadRequestObjectResult));
        }
    }
}
