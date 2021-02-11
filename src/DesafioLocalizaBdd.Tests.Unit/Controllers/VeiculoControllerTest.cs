using DesafioLocalizaBdd.Api.Controllers;
using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;
using DesafioLocalizaBdd.Domain.ValueObjects.Veiculo;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DesafioLocalizaBdd.Tests.Unit.Controllers
{
    public class VeiculoControllerTest : BaseControllerTest
    {
        private VeiculoController _veiculoController;

        private readonly Mock<IVeiculoApplication> _veiculoApplicationMock = new Mock<IVeiculoApplication>();
        private readonly Mock<IVeiculoRepositorio> _veiculoRepositorioMock = new Mock<IVeiculoRepositorio>();

        private readonly Veiculo _veiculo = new Veiculo("QUI1104", new Marca("Ford"), new Modelo("Focus"), 2020, 5, 
                                                        new Combustivel(DesafioLocalizaBdd.Domain.ValueObjects.Veiculo.TipoCombustivel.gasolina),
                                                        400,
                                                        new Categoria(DesafioLocalizaBdd.Domain.ValueObjects.Veiculo.TipoCategoria.completo));
        
        private readonly Veiculo _veiculo2 = new Veiculo("OPQ4578", new Marca("Pegeout"), new Modelo("302"), 2019, 5, 
                                                         new Combustivel(DesafioLocalizaBdd.Domain.ValueObjects.Veiculo.TipoCombustivel.gasolina),
                                                         350,
                                                         new Categoria(DesafioLocalizaBdd.Domain.ValueObjects.Veiculo.TipoCategoria.completo));

        private readonly List<Veiculo> _veiculos;

        public VeiculoControllerTest()
        {
            _veiculos = new List<Veiculo>() { _veiculo, _veiculo2 };
        }

        [Fact]
        public void Obter_Veiculo_Sucesso()
        {
            //Arrange
            var guid = new Guid("a61e52c5-7c25-4fa8-a8f3-8d793d319199");
            

            _veiculoRepositorioMock.Setup(x => x.Obter(It.IsAny<Guid>())).Returns(_veiculo);

            _veiculoController = new VeiculoController(_veiculoApplicationMock.Object, _veiculoRepositorioMock.Object);

            //Act
            var resultado = _veiculoController.Get(guid);

            //Assert
            resultado.Should().BeOfType(typeof(OkObjectResult));
            var conteudo = GetOkObject<Veiculo>(resultado);
            conteudo.Should().BeSameAs(_veiculo);
        }

        [Fact]
        public void Obter_Veiculo_NaoEncontrado()
        {
            //Arrange
            var guid = new Guid("d0feaa4e-f5aa-474a-9863-9d6b2964977e");

            _veiculoRepositorioMock.Setup(x => x.Obter(It.IsAny<Guid>())).Returns((Veiculo)null);

            _veiculoController = new VeiculoController(_veiculoApplicationMock.Object, _veiculoRepositorioMock.Object);

            //Act
            var resultado = _veiculoController.Get(guid);

            //Assert
            resultado.Should().BeOfType(typeof(NotFoundObjectResult));
        }

        [Fact]
        public void Listar_Veiculos_Sucesso()
        {
            //Arrange
            _veiculoRepositorioMock.Setup(x => x.Listar()).Returns(_veiculos);

            _veiculoController = new VeiculoController(_veiculoApplicationMock.Object, _veiculoRepositorioMock.Object);

            //Act
            var resultado = _veiculoController.List();

            //Assert
            resultado.Should().BeOfType(typeof(OkObjectResult));
            var conteudo = GetOkObject<IEnumerable<Veiculo>>(resultado);
            conteudo.Should().BeSameAs(_veiculos);
        }

        [Fact]
        public void Cadastrar_Veiculo_Sucesso()
        {
            var veiculoModel = new VeiculoModel()
            {
                Placa = "HEL0774",
                Marca = "VolksWagen",
                Modelo = "Fox",
                Ano = 2020,
                ValorHora = 2,
                Combustivel = Application.Models.TipoCombustivel.gasolina,
                LimitePortaMalas = 350,
                Categoria = Application.Models.TipoCategoria.completo
            };

            int combustivel = (int)veiculoModel.Combustivel;
            int categoria = (int)veiculoModel.Categoria;

            var veiculo = new Veiculo(veiculoModel.Placa, new Marca(veiculoModel.Marca),
                new Modelo(veiculoModel.Modelo), veiculoModel.Ano, veiculoModel.ValorHora,
                new Combustivel((DesafioLocalizaBdd.Domain.ValueObjects.Veiculo.TipoCombustivel)combustivel),
                veiculoModel.LimitePortaMalas,
                new Categoria((DesafioLocalizaBdd.Domain.ValueObjects.Veiculo.TipoCategoria)categoria));

            _veiculoApplicationMock.Setup(x => x.Cadastrar(veiculoModel)).Returns(veiculo);

            _veiculoController = new VeiculoController(_veiculoApplicationMock.Object, _veiculoRepositorioMock.Object);

            var resultado = _veiculoController.Post(veiculoModel);

            //Assert
            resultado.Should().BeOfType(typeof(CreatedResult));
            var conteudo = GetCreatedObject<Veiculo>(resultado);
            conteudo.Should().BeSameAs(veiculo);
        }

        [Fact]
        public void Cadastrar_Veiculo_DadosInvalidos()
        {
            var veiculoModel = new VeiculoModel()
            {
                Placa = "HEL",
                Marca = "VolksWagen",
                Modelo = "Fox",
                Ano = 2000,
                ValorHora = 2,
                Combustivel = DesafioLocalizaBdd.Application.Models.TipoCombustivel.gasolina,
                LimitePortaMalas = 350,
                Categoria = DesafioLocalizaBdd.Application.Models.TipoCategoria.completo
            };

            _veiculoApplicationMock.Setup(x => x.Cadastrar(veiculoModel)).Returns((Veiculo)null);

            _veiculoController = new VeiculoController(_veiculoApplicationMock.Object, _veiculoRepositorioMock.Object);

            var resultado = _veiculoController.Post(veiculoModel);

            //Assert
            resultado.Should().BeOfType(typeof(BadRequestObjectResult));
        }
    }
}
