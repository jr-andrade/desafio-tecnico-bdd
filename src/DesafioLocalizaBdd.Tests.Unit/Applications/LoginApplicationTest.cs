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
            //Criar usu�rio fict�cio
            var guid = new Guid();
            var usuario = new Usuario(guid, "09784494604", "123456", "Jos� Vicente", "Cliente");

            //Mock reposit�rio usu�rio
            _usuarioRepositorioMock.Setup(x => x.Obter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(usuario);

            //Criar cliente fict�cio
            var cliente = new Cliente(guid, "09784494604", new DateTime(1989, 06, 22));

            //Mock reposit�rio cliente
            _clienteRepositorioMock.Setup(x => x.Obter(It.IsAny<Guid>()))
                .Returns(cliente);

            //Criar token fict�cio
            var token = "xyztoken";

            //Mock servi�o autentica��o
            _tokenServiceMock.Setup(x => x.GerarToken(It.IsAny<Usuario>()))
                .Returns(token);

            //Act
            //Obter usu�rio autenticado
            LoginApplication application = new LoginApplication(_usuarioRepositorioMock.Object, _clienteRepositorioMock.Object, _operadorRepositorioMock.Object, _tokenServiceMock.Object);

            Usuario usuarioAutenticado = application.Autenticar("09784494604", "123456");

            //Assert
            //Verificar se usu�rio est� autenticado
            Assert.NotEmpty(usuarioAutenticado.Token);
            //Verificar se usu�rio � cliente
            Assert.True(usuarioAutenticado is Cliente);
        }

        [Fact]
        public void Autenticar_Operador_Sucesso()
        {
            //Arrange
            //Criar usu�rio fict�cio
            var guid = new Guid();
            var usuario = new Usuario(guid, "130364", "123456", "Jos� Vicente", "Operador");

            //Mock reposit�rio usu�rio
            _usuarioRepositorioMock.Setup(x => x.Obter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(usuario);

            //Criar operador fict�cio
            var operador = new Operador(guid, "130364");

            //Mock reposit�rio operador
            _operadorRepositorioMock.Setup(x => x.Obter(It.IsAny<Guid>()))
                .Returns(operador);

            //Criar token fict�cio
            var token = "xyztoken";

            //Mock servi�o autentica��o
            _tokenServiceMock.Setup(x => x.GerarToken(It.IsAny<Usuario>()))
                .Returns(token);

            //Act
            //Obter usu�rio autenticado
            LoginApplication application = new LoginApplication(_usuarioRepositorioMock.Object, _clienteRepositorioMock.Object, _operadorRepositorioMock.Object, _tokenServiceMock.Object); 

            Usuario usuarioAutenticado = application.Autenticar("130364", "123456");

            //Assert
            //Verificar se usu�rio est� autenticado
            Assert.NotEmpty(usuarioAutenticado.Token);
            //Verificar se usu�rio � operador
            Assert.True(usuarioAutenticado is Operador);
        }

        [Fact]
        public void Autenticar_LoginOuSenhaInvalidos() 
        {
            //Mock reposit�rio usu�rio
            _usuarioRepositorioMock.Setup(x => x.Obter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((Usuario)null);

            //Act
            //Obter usu�rio autenticado
            LoginApplication application = new LoginApplication(_usuarioRepositorioMock.Object, _clienteRepositorioMock.Object, _operadorRepositorioMock.Object, _tokenServiceMock.Object);

            Usuario usuarioAutenticado = application.Autenticar("09784494604", "123456");

            //Assert
            // Verificar se usu�rio autenticado � nulo
            usuarioAutenticado.Should().BeNull();
        }
    }
}
