using DesafioLocalizaBdd.Domain.Entidades;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DesafioLocalizaBdd.Tests.Integration
{
    public class LoginControllerIntegrationTest : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        public HttpClient _client { get; }

        public LoginControllerIntegrationTest(WebApplicationFactory<Api.Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact]
        public void ObterCliente_Unauthorized()
        {
            var response =  _client.GetAsync("/api/login/cliente").Result;
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task ObterCliente_OK()
        {
            //Autentica
            var response = await _client.PostAsync("/api/login?login=09784494604&senha=123456", null);

            //Verifica se a autenticação ocorreu com sucesso
            var jsonstring = await response.Content.ReadAsStringAsync();
            var usuario = JsonConvert.DeserializeObject<Usuario>(jsonstring);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            usuario.Token.Should().NotBeEmpty();

            //Valida rota autenticada
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {usuario.Token}");
            var response1 = _client.GetAsync("/api/login/cliente").Result;
            response1.StatusCode.Should().Be(HttpStatusCode.OK);
        }        
    }
}
