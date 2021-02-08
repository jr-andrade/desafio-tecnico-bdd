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
            //Criar usuário fictício
            var guid = new Guid();
            var usuario = new Usuario(guid, "09784494604", "123456", "José Vicente", Perfil.Cliente);

            //Mock repositório usuário
            Mock<IUsuarioRepositorio> _usuarioRepositorio = new Mock<IUsuarioRepositorio>();
            _usuarioRepositorio.Setup(x => x.Obter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(usuario);

            //Criar cliente fictício
            var cliente = new Cliente(guid, "09784494604", new DateTime(1989, 06, 22));

            //Mock repositório cliente
            Mock<IClienteRepositorio> _clienteRepositorio = new Mock<IClienteRepositorio>();
            _clienteRepositorio.Setup(x => x.Obter(It.IsAny<Guid>()))
                .Returns(cliente);

            //Mock repositório operador
            Mock<IOperadorRepositorio> _operadorRepositorio = new Mock<IOperadorRepositorio>();

            //Criar token fictício
            var token = "xyztoken";

            //Mock serviço autenticação
            Mock<ITokenService> _tokenService = new Mock<ITokenService>();
            _tokenService.Setup(x => x.GerarToken(It.IsAny<Usuario>()))
                .Returns(token);

            //Act
            //Obter usuário autenticado
            LoginApplication application = new LoginApplication(_usuarioRepositorio.Object, _clienteRepositorio.Object, _operadorRepositorio.Object, _tokenService.Object);

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
            var usuario = new Usuario(guid, "130364", "123456", "José Vicente", Perfil.Operador);

            //Mock repositório usuário
            Mock<IUsuarioRepositorio> _usuarioRepositorio = new Mock<IUsuarioRepositorio>();
            _usuarioRepositorio.Setup(x => x.Obter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(usuario);

            //Mock repositório cliente
            Mock<IClienteRepositorio> _clienteRepositorio = new Mock<IClienteRepositorio>();

            //Criar operador fictício
            var operador = new Operador(guid, "130364");

            //Mock repositório operador
            Mock<IOperadorRepositorio> _operadorRepositorio = new Mock<IOperadorRepositorio>();
            _operadorRepositorio.Setup(x => x.Obter(It.IsAny<Guid>()))
                .Returns(operador);

            //Criar token fictício
            var token = "xyztoken";

            //Mock serviço autenticação
            Mock<ITokenService> _tokenService = new Mock<ITokenService>();
            _tokenService.Setup(x => x.GerarToken(It.IsAny<Usuario>()))
                .Returns(token);

            //Act
            //Obter usuário autenticado
            LoginApplication application = new LoginApplication(_usuarioRepositorio.Object, _clienteRepositorio.Object, _operadorRepositorio.Object, _tokenService.Object); 

            Usuario usuarioAutenticado = application.Autenticar("130364", "123456");

            //Assert
            //Verificar se usuário está autenticado
            Assert.NotEmpty(usuarioAutenticado.Token);
            //Verificar se usuário é cliente
            Assert.True(usuarioAutenticado is Operador);
        }

        [Fact]
        public void Autenticar_LoginOuSenhaInvalidos() 
        {
            //Mock repositório usuário
            Mock<IUsuarioRepositorio> _usuarioRepositorio = new Mock<IUsuarioRepositorio>();
            _usuarioRepositorio.Setup(x => x.Obter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((Usuario)null);

            //Mock repositório cliente
            Mock<IClienteRepositorio> _clienteRepositorio = new Mock<IClienteRepositorio>();

            //Mock repositório operador
            Mock<IOperadorRepositorio> _operadorRepositorio = new Mock<IOperadorRepositorio>();

            //Mock serviço autenticação
            Mock<ITokenService> _tokenService = new Mock<ITokenService>();

            //Act
            //Obter usuário autenticado
            LoginApplication application = new LoginApplication(_usuarioRepositorio.Object, _clienteRepositorio.Object, _operadorRepositorio.Object, _tokenService.Object);

            Action act = () => application.Autenticar("09784494604", "123456");

            //Assert
            // Deverá lançar exceção de login/senha inválidos
            act.Should().Throw<Exception>("login ou senha inválidos");
        }
    }
}
