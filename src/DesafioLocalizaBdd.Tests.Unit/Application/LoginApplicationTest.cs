using DesafioLocalizaBdd.Application;
using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace DesafioLocalizaBdd.Tests.Unit.Application
{
    public class LoginApplicationTest
    {
        [Fact]
        public void Autenticar_Cliente_Sucesso()
        {
            //Arrange
            //Criar usu�rio fict�cio
            var guid = new Guid();
            var usuario = new Usuario(guid, "09784494604", "123456", "Jos� Vicente", Perfil.Cliente);

            //Mock reposit�rio usu�rio
            Mock<IUsuarioRepositorio> _usuarioRepositorio = new Mock<IUsuarioRepositorio>();
            _usuarioRepositorio.Setup(x => x.Obter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(usuario);

            //Criar cliente fict�cio
            var cliente = new Cliente(guid, "09784494604", new DateTime(1989, 06, 22));

            //Mock reposit�rio cliente
            Mock<IClienteRepositorio> _clienteRepositorio = new Mock<IClienteRepositorio>();
            _clienteRepositorio.Setup(x => x.Obter(It.IsAny<Guid>()))
                .Returns(cliente);

            //Mock reposit�rio operador
            Mock<IOperadorRepositorio> _operadorRepositorio = new Mock<IOperadorRepositorio>();

            //Criar token fict�cio
            var token = "xyztoken";

            //Mock servi�o autentica��o
            Mock<ITokenService> _tokenService = new Mock<ITokenService>();
            _tokenService.Setup(x => x.GerarToken(It.IsAny<Usuario>()))
                .Returns(token);

            //Act
            //Obter usu�rio autenticado
            LoginApplication application = new LoginApplication(_usuarioRepositorio.Object, _clienteRepositorio.Object, _operadorRepositorio.Object, _tokenService.Object);

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
            var usuario = new Usuario(guid, "130364", "123456", "Jos� Vicente", Perfil.Operador);

            //Mock reposit�rio usu�rio
            Mock<IUsuarioRepositorio> _usuarioRepositorio = new Mock<IUsuarioRepositorio>();
            _usuarioRepositorio.Setup(x => x.Obter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(usuario);

            //Mock reposit�rio cliente
            Mock<IClienteRepositorio> _clienteRepositorio = new Mock<IClienteRepositorio>();

            //Criar operador fict�cio
            var operador = new Operador(guid, "130364");

            //Mock reposit�rio operador
            Mock<IOperadorRepositorio> _operadorRepositorio = new Mock<IOperadorRepositorio>();
            _operadorRepositorio.Setup(x => x.Obter(It.IsAny<Guid>()))
                .Returns(operador);

            //Criar token fict�cio
            var token = "xyztoken";

            //Mock servi�o autentica��o
            Mock<ITokenService> _tokenService = new Mock<ITokenService>();
            _tokenService.Setup(x => x.GerarToken(It.IsAny<Usuario>()))
                .Returns(token);

            //Act
            //Obter usu�rio autenticado
            LoginApplication application = new LoginApplication(_usuarioRepositorio.Object, _clienteRepositorio.Object, _operadorRepositorio.Object, _tokenService.Object); 

            Usuario usuarioAutenticado = application.Autenticar("130364", "123456");

            //Assert
            //Verificar se usu�rio est� autenticado
            Assert.NotEmpty(usuarioAutenticado.Token);
            //Verificar se usu�rio � cliente
            Assert.True(usuarioAutenticado is Operador);
        }

        [Fact]
        public void Autenticar_LoginOuSenhaInvalidos() 
        {
            //Mock reposit�rio usu�rio
            Mock<IUsuarioRepositorio> _usuarioRepositorio = new Mock<IUsuarioRepositorio>();
            _usuarioRepositorio.Setup(x => x.Obter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((Usuario)null);

            //Mock reposit�rio cliente
            Mock<IClienteRepositorio> _clienteRepositorio = new Mock<IClienteRepositorio>();

            //Mock reposit�rio operador
            Mock<IOperadorRepositorio> _operadorRepositorio = new Mock<IOperadorRepositorio>();

            //Mock servi�o autentica��o
            Mock<ITokenService> _tokenService = new Mock<ITokenService>();

            //Act
            //Obter usu�rio autenticado
            LoginApplication application = new LoginApplication(_usuarioRepositorio.Object, _clienteRepositorio.Object, _operadorRepositorio.Object, _tokenService.Object);

            Action act = () => application.Autenticar("09784494604", "123456");

            //Assert
            // Dever� lan�ar exce��o de login/senha inv�lidos
            act.Should().Throw<Exception>("login ou senha inv�lidos");
        }
    }
}
