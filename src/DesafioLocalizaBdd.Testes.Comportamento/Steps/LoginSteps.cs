using DesafioLocalizaBdd.Api.Controllers;
using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.ValueObjects.Cliente;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioLocalizaBdd.Testes.Comportamento.Steps
{
    [Binding]
    public class LoginSteps
    {
        private LoginController _loginController;
        private readonly Mock<ILoginApplication> _loginApplication = new Mock<ILoginApplication>();

        private string _login;
        private string _senha;
        private Usuario _usuario;

        [Given(@"que o usuário informou o login '(.*)' e a senha '(.*)'")]
        public void DadoQueOUsuarioInformouOLoginEASenha(string login, string senha)
        {
            _login = login;
            _senha = senha;
        }

        #region Perfil Cliente

        [Given(@"que os dados de entrada estão válidos e correspondem a um cliente cadastrado")]
        public void DadoQueOsDadosDeEntradaEstaoValidosECorrespondemAUmClienteCadastrado()
        {
            var cliente = new Cliente(new Guid(), "Cliente Teste", _login, new DateTime(1989, 06, 22), 
                                    new Endereco(
                                                "31080170",
                                                "Rua Carmesia",
                                                1381,
                                                "Apto 302",
                                                "Belo Horizonte",
                                                "Minas Gerais"
                                        ),
                                        "12345678");
            var token = "xyzToken";
            cliente.Autenticar(token);

            _loginApplication.Setup(x => x.Autenticar(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(cliente);
        }

        [Then(@"o usuário será autenticado como um cliente")]
        public void EntaoOUsuarioSeraAutenticadoComoUmCliente()
        {
            _loginController = new LoginController(_loginApplication.Object);

            var resultadoLogin = _loginController.Post(_login, _senha);

            _usuario = GetOkObject<Usuario>(resultadoLogin);

            //Usuário deverá possuir token de autenticação
            _usuario.Token.Should().NotBeNull();

            //Usuário deverá ser um cliente
            Assert.True(_usuario is Cliente);
            ((Cliente)_usuario).Cpf.Should().NotBeNullOrEmpty();
        }
        #endregion

        #region Perfil Operador

        [Given(@"que os dados de entrada estão válidos e correspondem a um operador do sistema")]
        public void DadoQueOsDadosDeEntradaEstaoValidosECorrespondemAUmOperadorDoSistema()
        {
            var operador = new Operador(new Guid(), "Operador Teste", _login, _senha);
            var token = "xyzToken";
            operador.Autenticar(token);

            _loginApplication.Setup(x => x.Autenticar(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(operador);
        }

        [Then(@"o usuário será autenticado como um operador do sistema")]
        public void EntaoOUsuarioSeraAutenticadoComoUmOperadorDoSistema()
        {
            _loginController = new LoginController(_loginApplication.Object);

            var resultadoLogin = _loginController.Post(_login, _senha);

            _usuario = GetOkObject<Usuario>(resultadoLogin);

            //Usuário deverá possuir token de autenticação
            _usuario.Token.Should().NotBeNull();

            //Usuário deverá ser um operador
            Assert.True(_usuario is Operador);
            ((Operador)_usuario).Matricula.Should().NotBeNullOrEmpty();
        }
        #endregion

        protected T GetOkObject<T>(IActionResult result)
        {
            var okObjectResult = (OkObjectResult)result;
            return (T)okObjectResult.Value;
        }
    }
}
