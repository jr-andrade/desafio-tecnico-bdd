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

        #region Cadastro
        [Fact]
        public async Task CadastrarMarca_Unauthorized()
        {
            //Tenta cadastrar uma marca
            var response = await _client.PostAsync("/marcas/fiat", null);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task CadastrarMarca_Forbidden()
        {
            //Autentica
            var response = await _client.PostAsync("/login/09784494604/12345678", null);

            //Verifica se a autenticação ocorreu com sucesso
            var jsonstring = await response.Content.ReadAsStringAsync();
            var usuario = JsonConvert.DeserializeObject<Usuario>(jsonstring);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            usuario.Token.Should().NotBeEmpty();

            //acesso com autenticação de cliente
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {usuario.Token}");
            var response1 = await _client.PostAsync("/marcas/Pegeout", null);
            response1.StatusCode.Should().Be(HttpStatusCode.Forbidden);            
        }

        [Fact]
        public async Task CadastrarMarca_Autorizado()
        {
            //Autentica
            var response = await _client.PostAsync("/login/130364/12345678", null);

            //Verifica se a autenticação ocorreu com sucesso
            var jsonstring = await response.Content.ReadAsStringAsync();
            var usuario = JsonConvert.DeserializeObject<Usuario>(jsonstring);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            usuario.Token.Should().NotBeEmpty();

            //acesso com autenticação de cliente
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {usuario.Token}");
            var response1 = await _client.PostAsync("/marcas/Pegeout", null);
            response1.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task CadastrarModelo_Unauthorized()
        {
            //Tenta cadastrar uma marca
            var response = await _client.PostAsync("/modelos/C4", null);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task CadastrarModelo_Forbidden()
        {
            //Autentica
            var response = await _client.PostAsync("/login/09784494604/12345678", null);

            //Verifica se a autenticação ocorreu com sucesso
            var jsonstring = await response.Content.ReadAsStringAsync();
            var usuario = JsonConvert.DeserializeObject<Usuario>(jsonstring);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            usuario.Token.Should().NotBeEmpty();

            //acesso com autenticação de cliente
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {usuario.Token}");
            var response1 = await _client.PostAsync("/modelos/C4", null);
            response1.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }

        [Fact]
        public async Task CadastrarModelo_Autorizado()
        {
            //Autentica
            var response = await _client.PostAsync("/login/130364/12345678", null);

            //Verifica se a autenticação ocorreu com sucesso
            var jsonstring = await response.Content.ReadAsStringAsync();
            var usuario = JsonConvert.DeserializeObject<Usuario>(jsonstring);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            usuario.Token.Should().NotBeEmpty();

            //acesso com autenticação de cliente
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {usuario.Token}");
            var response1 = await _client.PostAsync("/marcas/C4", null);
            response1.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        #endregion

        #region Locacao

        [Fact]
        public async Task SimularLocacao()
        {
            var response = await _client.GetAsync("/locacoes/simular?veiculoId=3fc8ae87-d130-45ae-ac98-a1895cf87743&inicio=2021-03-10&fim=2021-03-15");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task AgendarLocacao_NaoAutorizado()
        {
            var response = await _client.PostAsync("/locacoes/agendar?veiculoId=3fc8ae87-d130-45ae-ac98-a1895cf87743&inicio=2021-03-10&fim=2021-03-15", null);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task AgendarLocacao_Autorizado()
        {
            //Autentica
            var response = await _client.PostAsync("/login/09784494604/12345678", null);

            //Verifica se a autenticação ocorreu com sucesso
            var jsonstring = await response.Content.ReadAsStringAsync();
            var usuario = JsonConvert.DeserializeObject<Usuario>(jsonstring);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            usuario.Token.Should().NotBeEmpty();

            //acesso com autenticação de cliente
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {usuario.Token}");
            var response1 = await _client.PostAsync("/locacoes/agendar?veiculoId=3fc8ae87-d130-45ae-ac98-a1895cf87743&inicio=2021-03-10&fim=2021-03-15", null);
            response1.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

    }
}
