using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.ValueObjects.Cliente;
using System;
using Xunit;

namespace DesafioLocalizaBdd.Tests.Unit.Domain.Entidades
{
    public class ClienteTest
    {
        [Fact]
        public void CriarCliente_Sucesso() 
        {
            var cliente = new Cliente("Cliente Teste", "09784494604", 
                                        new DateTime(1989, 06, 22),
                                        new Endereco(
                                                "31080170",
                                                "Rua Carmesia",
                                                1381,
                                                "Belo Horizonte",
                                                "Minas Gerais"
                                        ),
                                        "12345678"
                                       );

            Assert.True(cliente.Valid);
            Assert.Empty(cliente.Notifications);
        }

        [Theory]
        [InlineData("")]
        [InlineData("09784")]
        [InlineData("097844abc04")]
        public void CriarCliente_CPFInvalido(string cpf)
        {
            var cliente = new Cliente("Cliente Teste",
                                        cpf,
                                        new DateTime(1989, 06, 22),
                                        new Endereco(
                                                "31080170",
                                                "Rua Carmesia",
                                                1381,
                                                "Belo Horizonte",
                                                "Minas Gerais"
                                        ),
                                        "12345678"
                                       );

            Assert.True(cliente.Invalid);
            Assert.NotEmpty(cliente.Notifications);
            Assert.Contains(cliente.Notifications, n => n.Property == nameof(Cliente.Cpf));
        }

        [Fact]
        public void CriarCliente_EnderecoInvalido()
        {
            var cliente = new Cliente("Cliente Teste", "09784494604",
                                        new DateTime(1989, 06, 22),
                                        null,
                                        "12345678"
                                       );

            Assert.True(cliente.Invalid);
            Assert.NotEmpty(cliente.Notifications);
            Assert.Contains(cliente.Notifications, n => n.Property == nameof(Cliente.Endereco));
        }

        [Fact]
        public void CriarCliente_SenhaInvalida()
        {
            var cliente = new Cliente("Cliente Teste", "09784494604",
                                        new DateTime(1989, 06, 22),
                                        new Endereco(
                                                "31080170",
                                                "Rua Carmesia",
                                                1381,
                                                "Belo Horizonte",
                                                "Minas Gerais"
                                        ),
                                        "12345"
                                       );

            Assert.True(cliente.Invalid);
            Assert.NotEmpty(cliente.Notifications);
            Assert.Contains(cliente.Notifications, n => n.Property == nameof(Cliente.Senha));
        }

        [Fact]
        public void CriarCliente_Menor21Anos()
        {
            var cliente = new Cliente("Cliente Teste", "09784494604",
                                        new DateTime(2002, 06, 22),
                                        new Endereco(
                                                "31080170",
                                                "Rua Carmesia",
                                                1381,
                                                "Belo Horizonte",
                                                "Minas Gerais"
                                        ),
                                        "12345678"
                                       );

            Assert.True(cliente.Invalid);
            Assert.NotEmpty(cliente.Notifications);
            Assert.Contains(cliente.Notifications, n => n.Property == nameof(Cliente.Aniversario));
        }

        [Fact]
        public void CriarCliente_Maior70Anos()
        {
            var cliente = new Cliente("Cliente Teste", "09784494604",
                                        new DateTime(1945, 06, 22),
                                        new Endereco(
                                                "31080170",
                                                "Rua Carmesia",
                                                1381,
                                                "Belo Horizonte",
                                                "Minas Gerais"
                                        ),
                                        "12345678"
                                       );

            Assert.True(cliente.Invalid);
            Assert.NotEmpty(cliente.Notifications);
            Assert.Contains(cliente.Notifications, n => n.Property == nameof(Cliente.Aniversario));
        }
       
    }
}
