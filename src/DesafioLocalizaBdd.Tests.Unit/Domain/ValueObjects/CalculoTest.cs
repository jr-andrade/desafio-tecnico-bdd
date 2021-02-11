using DesafioLocalizaBdd.Domain.ValueObjects.Locacao;
using System;
using Xunit;

namespace DesafioLocalizaBdd.Tests.Unit.Domain.ValueObjects
{
    public class CalculoTest
    {
        [Fact]
        public void Criar_Calculo_Sucesso()
        {
            var calculo = new Calculo(3, new DateTime(2021,03,01), new DateTime(2021, 03,03));

            Assert.True(calculo.Valid);
            Assert.Empty(calculo.Notifications);
            Assert.NotEqual(0, calculo.ValorTotal);
        }

        [Fact]
        public void Criar_Calculo_ValorInvalido()
        {
            var calculo = new Calculo(0, new DateTime(2021, 03, 01), new DateTime(2021, 03, 03));

            Assert.False(calculo.Valid);
            Assert.Equal(0, calculo.ValorTotal);
            Assert.NotEmpty(calculo.Notifications);
            Assert.Contains(calculo.Notifications, n => n.Property == nameof(Calculo.ValorHora));
        }

        [Fact]
        public void Criar_Calculo_DataInicioInvalida()
        {
            var calculo = new Calculo(3, new DateTime(2020, 03, 01), new DateTime(2021, 03, 03));

            Assert.False(calculo.Valid);
            Assert.Equal(0, calculo.ValorTotal);
            Assert.NotEmpty(calculo.Notifications);
            Assert.Contains(calculo.Notifications, n => n.Property == nameof(Calculo.Inicio));
        }

        [Fact]
        public void Criar_Calculo_DataFinalInvalida()
        {
            var calculo = new Calculo(3, new DateTime(2021, 03, 01), new DateTime(2021, 02, 01));

            Assert.False(calculo.Valid);
            Assert.Equal(0, calculo.ValorTotal);
            Assert.NotEmpty(calculo.Notifications);
            Assert.Contains(calculo.Notifications, n => n.Property == nameof(Calculo.Final));
        }
    }
}
