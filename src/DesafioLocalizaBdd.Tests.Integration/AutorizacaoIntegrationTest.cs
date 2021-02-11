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
    public class AutorizacaoIntegrationTest : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        public HttpClient _client { get; }

        public AutorizacaoIntegrationTest(WebApplicationFactory<Api.Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task CadastrarMarca_Unauthorized()
        {
            //Tenta cadastrar uma marca
            var response = await _client.PostAsync("/marcas?marca=fiat", null);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task CadastrarMarca_Forbidden()
        {
            //Autentica
            var response = await _client.PostAsync("/login?login=09784494604&senha=12345678", null);

            //Verifica se a autenticação ocorreu com sucesso
            var jsonstring = await response.Content.ReadAsStringAsync();
            var usuario = JsonConvert.DeserializeObject<Usuario>(jsonstring);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            usuario.Token.Should().NotBeEmpty();

            //acesso com autenticação de cliente
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {usuario.Token}");
            var response1 = await _client.PostAsync("/marcas?marca=fiat", null);
            response1.StatusCode.Should().Be(HttpStatusCode.Forbidden);            
        }

        [Fact]
        public async Task CadastrarMarca_Ok()
        {
            //Autentica
            var response = await _client.PostAsync("/login?login=123456&senha=12345678", null);

            //Verifica se a autenticação ocorreu com sucesso
            var jsonstring = await response.Content.ReadAsStringAsync();
            var usuario = JsonConvert.DeserializeObject<Usuario>(jsonstring);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            usuario.Token.Should().NotBeEmpty();

            //acesso com autenticação de cliente
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {usuario.Token}");
            var response1 = await _client.PostAsync("/marcas?marca=Fiat", null);
            response1.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task download()
        {
            //Autentica
            var response = await _client.GetAsync("/locacoes/download");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}
