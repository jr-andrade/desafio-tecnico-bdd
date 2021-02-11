using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.ValueObjects.Veiculo;
using Xunit;

namespace DesafioLocalizaBdd.Tests.Unit.Domain.Entidades
{
    public class VeiculoTest
    {
        [Fact]
        public void Criar_Veiculo_Sucesso()
        {
            var veiculo = new Veiculo("QUI1104", new Marca("Ford"), new Modelo("Focus"), 2020, 5, new Combustivel(TipoCombustivel.gasolina), 400, new Categoria(TipoCategoria.completo));

            Assert.True(veiculo.Valid);
            Assert.Empty(veiculo.Notifications);
        }

        [Theory]
        [InlineData("")]
        [InlineData("ABC")]
        [InlineData("ABCD123456789")]
        public void Criar_Veiculo_PlacaInvalida(string placa)
        {
            var veiculo = new Veiculo(placa, new Marca("Ford"), new Modelo("Focus"), 2020, 5, new Combustivel(TipoCombustivel.gasolina), 400, new Categoria(TipoCategoria.completo));

            Assert.True(veiculo.Invalid);
            Assert.NotEmpty(veiculo.Notifications);
            Assert.Contains(veiculo.Notifications, n => n.Property == nameof(Veiculo.Placa));
        }

        [Fact]
        public void Criar_Veiculo_MarcaInvalida()
        {
            var veiculo = new Veiculo("QUI1104", new Marca(""), new Modelo("Focus"), 2020, 5, new Combustivel(TipoCombustivel.gasolina), 400, new Categoria(TipoCategoria.completo));

            Assert.True(veiculo.Invalid);
            Assert.NotEmpty(veiculo.Notifications);
            Assert.Contains(veiculo.Notifications, n => n.Property == nameof(Veiculo.Marca.Nome));
        }

        [Fact]
        public void Criar_Veiculo_ModeloInvalido()
        {
            var veiculo = new Veiculo("QUI1104", new Marca("Ford"), new Modelo(""), 2020, 5, new Combustivel(TipoCombustivel.gasolina), 400, new Categoria(TipoCategoria.completo));

            Assert.True(veiculo.Invalid);
            Assert.NotEmpty(veiculo.Notifications);
            Assert.Contains(veiculo.Notifications, n => n.Property == nameof(Veiculo.Modelo.Nome));
        }

        [Fact]
        public void Criar_Veiculo_AnoInvalido()
        {
            var veiculo = new Veiculo("QUI1104", new Marca("Ford"), new Modelo("Focus"), 2010, 5, new Combustivel(TipoCombustivel.gasolina), 400, new Categoria(TipoCategoria.completo));

            Assert.True(veiculo.Invalid);
            Assert.NotEmpty(veiculo.Notifications);
            Assert.Contains(veiculo.Notifications, n => n.Property == nameof(Veiculo.Ano));
        }

        [Fact]
        public void Criar_Veiculo_ValorInvalido()
        {
            var veiculo = new Veiculo("QUI1104", new Marca("Ford"), new Modelo("Focus"), 2020, 0, new Combustivel(TipoCombustivel.gasolina), 400, new Categoria(TipoCategoria.completo));

            Assert.True(veiculo.Invalid);
            Assert.NotEmpty(veiculo.Notifications);
            Assert.Contains(veiculo.Notifications, n => n.Property == nameof(Veiculo.ValorHora));
        }

        [Fact]
        public void Criar_Veiculo_CombustivelInvalido()
        {
            var veiculo = new Veiculo("QUI1104", new Marca("Ford"), new Modelo("Focus"), 2020, 5, new Combustivel(0), 400, new Categoria(TipoCategoria.completo));

            Assert.True(veiculo.Invalid);
            Assert.NotEmpty(veiculo.Notifications);
            Assert.Contains(veiculo.Notifications, n => n.Property == nameof(Veiculo.Combustivel.TipoCombustivel));
        }

        [Fact]
        public void Criar_Veiculo_CapacidadeInvalida()
        {
            var veiculo = new Veiculo("QUI1104", new Marca("Ford"), new Modelo("Focus"), 2020, 5, new Combustivel(TipoCombustivel.gasolina), 0, new Categoria(TipoCategoria.completo));

            Assert.True(veiculo.Invalid);
            Assert.NotEmpty(veiculo.Notifications);
            Assert.Contains(veiculo.Notifications, n => n.Property == nameof(Veiculo.LimitePortaMalas));
        }

        [Fact]
        public void Criar_Veiculo_CategoriaInvalida()
        {
            var veiculo = new Veiculo("QUI1104", new Marca("Ford"), new Modelo("Focus"), 2020, 5, new Combustivel(TipoCombustivel.gasolina), 400, new Categoria(0));

            Assert.True(veiculo.Invalid);
            Assert.NotEmpty(veiculo.Notifications);
            Assert.Contains(veiculo.Notifications, n => n.Property == nameof(Veiculo.Categoria.TipoCategoria));
        }
    }
}
