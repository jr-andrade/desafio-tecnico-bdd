using DesafioLocalizaBdd.Application;
using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;
using DesafioLocalizaBdd.Domain.ValueObjects.Veiculo;
using FluentAssertions;
using Moq;
using System;
using Xunit;
using TipoCategoria = DesafioLocalizaBdd.Application.Models.TipoCategoria;
using TipoCombustivel = DesafioLocalizaBdd.Application.Models.TipoCombustivel;

namespace DesafioLocalizaBdd.Tests.Unit.Applications
{
    public class VeiculoApplicationTest
    {
        private VeiculoApplication _application;

        private Mock<IVeiculoRepositorio> _repositorio = new Mock<IVeiculoRepositorio>();

        [Fact]
        public void Cadastrar_Veiculo_Sucesso()
        {
            //Arrange
            var model = new VeiculoModel()
            {
                Placa = "HEL0774",
                Marca = "VolksWagen",
                Modelo = "Fox",
                Ano = 2020,
                ValorHora = 2,
                Combustivel = TipoCombustivel.gasolina,
                LimitePortaMalas = 350,
                Categoria = TipoCategoria.completo
            };

            var guid = new Guid("270842ec-2b88-4e30-aca0-15fccdaeaf3d");
            var veiculoCadastrado = new Veiculo(guid, model.Placa, new Marca(model.Marca), new Modelo(model.Modelo), 2020, 2,
                                                        new Combustivel(DesafioLocalizaBdd.Domain.ValueObjects.Veiculo.TipoCombustivel.gasolina),
                                                        350,
                                                        new Categoria(DesafioLocalizaBdd.Domain.ValueObjects.Veiculo.TipoCategoria.completo));

            _repositorio.Setup(x => x.Cadastrar(It.IsAny<Veiculo>())).Returns(veiculoCadastrado);

            _application = new VeiculoApplication(_repositorio.Object);

            //Act

            var resultado = _application.Cadastrar(model);

            //Assert
            resultado.Should().BeEquivalentTo(veiculoCadastrado);

        }

        [Fact]
        public void Cadastrar_Veiculo_DadosInvalidos()
        {
            //Arrange
            var model = new VeiculoModel()
            {
                Placa = "HEL",
                Marca = "VolksWagen",
                Modelo = "Fox",
                Ano = 2020,
                ValorHora = 2,
                Combustivel = TipoCombustivel.gasolina,
                LimitePortaMalas = 350,
                Categoria = TipoCategoria.completo
            };

            _application = new VeiculoApplication(_repositorio.Object);

            //Act
            var resultado = _application.Cadastrar(model);

            //Assert
            resultado.Should().BeNull();
        }
    }
}
