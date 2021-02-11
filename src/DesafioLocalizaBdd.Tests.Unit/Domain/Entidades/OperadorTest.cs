using DesafioLocalizaBdd.Domain.Entidades;
using Xunit;

namespace DesafioLocalizaBdd.Tests.Unit.Domain.Entidades
{
    public class OperadorTest
    {
        [Fact]
        public void Criar_Operador_Sucesso()
        {
            var operador = new Operador("Operador Teste", "130364", "12345678");

            Assert.True(operador.Valid);
            Assert.Empty(operador.Notifications);
        }

        [Theory]
        [InlineData("")]
        [InlineData("A")]
        public void Criar_Operador_NomeInvalido(string nome)
        {
            var operador = new Operador(nome, "130364", "12345678");

            Assert.False(operador.Valid);
            Assert.NotEmpty(operador.Notifications);
            Assert.Contains(operador.Notifications, n => n.Property == nameof(Operador.Nome)); ;
        }

        [Theory]
        [InlineData("")]
        [InlineData("123")]
        [InlineData("123456789")]
        [InlineData("123abc")]
        public void Criar_Operador_MatriculaInvalida(string matricula)
        {
            var operador = new Operador("Operador Teste", matricula, "12345678");

            Assert.False(operador.Valid);
            Assert.NotEmpty(operador.Notifications);
            Assert.Contains(operador.Notifications, n => n.Property == nameof(Operador.Matricula)); ;
        }

        [Theory]
        [InlineData("")]
        [InlineData("123456")]
        public void Criar_Operador_SenhaInvalida(string senha)
        {
            var operador = new Operador("Operador Teste", "130364", senha);

            Assert.False(operador.Valid);
            Assert.NotEmpty(operador.Notifications);
            Assert.Contains(operador.Notifications, n => n.Property == nameof(Operador.Senha));
        }
    }
}
