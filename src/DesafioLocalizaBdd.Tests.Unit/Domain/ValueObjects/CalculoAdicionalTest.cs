using DesafioLocalizaBdd.Domain.ValueObjects.Locacao;
using Xunit;

namespace DesafioLocalizaBdd.Tests.Unit.Domain.ValueObjects
{
    public class CalculoAdicionalTest
    {
        [Fact]
        public void Criar_CalculoAdicional_SemCobranca_Sucesso()
        {
            var calculo = new CalculoAdicional(150, true, true, false, false);

            Assert.True(calculo.Valid);
            Assert.Empty(calculo.Notifications);
            Assert.Equal(0, calculo.ValorAdicional);
        }

        [Fact]
        public void Criar_CalculoAdicional_ComCobranca_Sucesso()
        {
            var calculo = new CalculoAdicional(150, false, true, true, false);

            Assert.True(calculo.Valid);
            Assert.Empty(calculo.Notifications);
            Assert.Equal(90, calculo.ValorAdicional);
        }

        [Fact]
        public void Criar_CalculoAdicional_ValorBaseInvalido()
        {
            var calculo = new CalculoAdicional(0, false, true, true, false);

            Assert.True(calculo.Invalid);
            Assert.NotEmpty(calculo.Notifications);
            Assert.Contains(calculo.Notifications, n => n.Property == nameof(CalculoAdicional.ValorBase));
        }
    }
}
