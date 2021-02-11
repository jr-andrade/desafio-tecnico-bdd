using DesafioLocalizaBdd.Application;
using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace DesafioLocalizaBdd.Tests.Unit.Applications
{
    public class LoginApplicationTest
    {
        private readonly Mock<IUsuarioRepositorio> _usuarioRepositorioMock = new Mock<IUsuarioRepositorio>();
        private readonly Mock<IClienteRepositorio> _clienteRepositorioMock = new Mock<IClienteRepositorio>();
        private readonly Mock<IOperadorRepositorio> _operadorRepositorioMock = new Mock<IOperadorRepositorio>();
        private readonly Mock<ITokenService> _tokenServiceMock = new Mock<ITokenService>();

        [Fact]
        public void Autenticar_Cliente_Sucesso()
        {
            //Arrange
            //Criar usuário fictício
            var guid = new Guid();
            var usuario = new Usuario(guid, "09784494604", "123456", "José Vicente", "Cliente");

            //Mock repositório usuário
            _usuarioRepositorioMock.Setup(x => x.Obter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(usuario);

            //Criar cliente fictício
            var cliente = new Cliente(guid, "09784494604", new DateTime(1989, 06, 22));

            //Mock repositório cliente
            _clienteRepositorioMock.Setup(x => x.Obter(It.IsAny<Guid>()))
                .Returns(cliente);

            //Criar token fictício
            var token = "xyztoken";

            //Mock serviço autenticação
            _tokenServiceMock.Setup(x => x.GerarToken(It.IsAny<Usuario>()))
                .Returns(token);

            //Act
            //Obter usuário autenticado
            LoginApplication application = new LoginApplication(_usuarioRepositorioMock.Object, _clienteRepositorioMock.Object, _operadorRepositorioMock.Object, _tokenServiceMock.Object);

            Usuario usuarioAutenticado = application.Autenticar("09784494604", "123456");

            //Assert
            //Verificar se usuário está autenticado
            Assert.NotEmpty(usuarioAutenticado.Token);
            //Verificar se usuário é cliente
            Assert.True(usuarioAutenticado is Cliente);
        }

        [Fact]
        public void Autenticar_Operador_Sucesso()
        {
            //Arrange
            //Criar usuário fictício
            var guid = new Guid();
            var usuario = new Usuario(guid, "130364", "123456", "José Vicente", "Operador");

            //Mock repositório usuário
            _usuarioRepositorioMock.Setup(x => x.Obter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(usuario);

            //Criar operador fictício
            var operador = new Operador(guid, "130364");

            //Mock repositório operador
            _operadorRepositorioMock.Setup(x => x.Obter(It.IsAny<Guid>()))
                .Returns(operador);

            //Criar token fictício
            var token = "xyztoken";

            //Mock serviço autenticação
            _tokenServiceMock.Setup(x => x.GerarToken(It.IsAny<Usuario>()))
                .Returns(token);

            //Act
            //Obter usuário autenticado
            LoginApplication application = new LoginApplication(_usuarioRepositorioMock.Object, _clienteRepositorioMock.Object, _operadorRepositorioMock.Object, _tokenServiceMock.Object); 

            Usuario usuarioAutenticado = application.Autenticar("130364", "123456");

            //Assert
            //Verificar se usuário está autenticado
            Assert.NotEmpty(usuarioAutenticado.Token);
            //Verificar se usuário é operador
            Assert.True(usuarioAutenticado is Operador);
        }

        [Fact]
        public void Autenticar_LoginOuSenhaInvalidos() 
        {
            //Mock repositório usuário
            _usuarioRepositorioMock.Setup(x => x.Obter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((Usuario)null);

            //Act
            //Obter usuário autenticado
            LoginApplication application = new LoginApplication(_usuarioRepositorioMock.Object, _clienteRepositorioMock.Object, _operadorRepositorioMock.Object, _tokenServiceMock.Object);

            Usuario usuarioAutenticado = application.Autenticar("09784494604", "123456");

            //Assert
            // Verificar se usuário autenticado é nulo
            usuarioAutenticado.Should().BeNull();
        }
    }
}
