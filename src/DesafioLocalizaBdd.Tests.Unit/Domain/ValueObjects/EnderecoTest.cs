using DesafioLocalizaBdd.Domain.ValueObjects.Cliente;
using Xunit;

namespace DesafioLocalizaBdd.Tests.Unit.Domain.ValueObjects
{
    public class EnderecoTest
    {
        [Fact]
        public void Criar_Endereco_Sucesso()
        {
            var endereco = new Endereco("31080170",
                                        "Rua Carmesia",
                                        1381,
                                        "Apto 302",
                                        "Belo Horizonte",
                                        "Minas Gerais"
                                        );

            Assert.True(endereco.Valid);
            Assert.Empty(endereco.Notifications);
        }

        [Theory]
        [InlineData("", "", "", "")]
        public void Criar_Endereco_Invalido(string logradouro, string complemento, string cidade, string estado)
        {
            var endereco = new Endereco("31080170",
                                        logradouro,
                                        0,
                                        complemento,
                                        cidade,
                                        estado
                                        );

            Assert.False(endereco.Valid);
            Assert.NotEmpty(endereco.Notifications);
            Assert.Contains(endereco.Notifications, n => n.Property == nameof(Endereco.Logradouro));
            Assert.Contains(endereco.Notifications, n => n.Property == nameof(Endereco.Cidade));
            Assert.Contains(endereco.Notifications, n => n.Property == nameof(Endereco.Estado));
        }

        [Theory]
        [InlineData("")]
        [InlineData("31080")]
        [InlineData("31080abc")]
        public void Criar_Endereco_CEPInvalido(string cep)
        {
            var endereco = new Endereco(cep,
                                        "Rua Carmesia",
                                        1381,
                                        "Apto 302",
                                        "Belo Horizonte",
                                        "Minas Gerais"
                                        );

            Assert.False(endereco.Valid);
            Assert.NotEmpty(endereco.Notifications);
            Assert.Contains(endereco.Notifications, n => n.Property == nameof(Endereco.Cep));
        }        

        [Fact]
        public void Criar_Endereco_NumeroInvalido()
        {
            var endereco = new Endereco("31080170",
                                        "Rua Carmesia",
                                        0,
                                        "Apto 302",
                                        "Belo Horizonte",
                                        "Minas Gerais"
                                        );

            Assert.False(endereco.Valid);
            Assert.NotEmpty(endereco.Notifications);
            Assert.Contains(endereco.Notifications, n => n.Property == nameof(Endereco.Numero));
        }
    }
}
