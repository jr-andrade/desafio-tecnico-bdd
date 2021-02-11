using DesafioLocalizaBdd.Domain.Entidades;
using FluentAssertions;
using System;
using Xunit;

namespace DesafioLocalizaBdd.Tests.Unit.Domain.Entidades
{
    public class LocacaoTest
    {
        [Fact]
        public void Criar_Locacao_Sucesso()
        {
            var locacao = new Locacao(new Guid("35c68591-0e87-467e-b71f-da8c3971110a"), new Guid("67b7ebc4-fcf1-45fa-a35e-b0c68ec57b89"), 150, new DateTime(2021,03,01), new DateTime(2021, 03, 03));

            Assert.True(locacao.Valid);
            Assert.Empty(locacao.Notifications);
            locacao.DataAgendamento.Should().BeCloseTo(DateTime.Now);
        }

        [Fact]
        public void Criar_Locacao_ValorInvalido()
        {
            var locacao = new Locacao(new Guid("35c68591-0e87-467e-b71f-da8c3971110a"), new Guid("67b7ebc4-fcf1-45fa-a35e-b0c68ec57b89"), 0, new DateTime(2021, 03, 01), new DateTime(2021, 03, 03));

            Assert.False(locacao.Valid);
            Assert.NotEmpty(locacao.Notifications);
            Assert.Contains(locacao.Notifications, n => n.Property == nameof(Locacao.Valor));
        }

        [Fact]
        public void Criar_Locacao_DataInicialInvalida()
        {
            var locacao = new Locacao(new Guid("35c68591-0e87-467e-b71f-da8c3971110a"), new Guid("67b7ebc4-fcf1-45fa-a35e-b0c68ec57b89"), 150, new DateTime(2020, 03, 01), new DateTime(2021, 03, 03));

            Assert.False(locacao.Valid);
            Assert.NotEmpty(locacao.Notifications);
            Assert.Contains(locacao.Notifications, n => n.Property == nameof(Locacao.Inicio));
        }

        [Fact]
        public void Criar_Locacao_DataFinalInvalida()
        {
            var locacao = new Locacao(new Guid("35c68591-0e87-467e-b71f-da8c3971110a"), new Guid("67b7ebc4-fcf1-45fa-a35e-b0c68ec57b89"), 150, new DateTime(2021, 03, 01), new DateTime(2021, 02, 03));

            Assert.False(locacao.Valid);
            Assert.NotEmpty(locacao.Notifications);
            Assert.Contains(locacao.Notifications, n => n.Property == nameof(Locacao.Final));
        }
    }
}
