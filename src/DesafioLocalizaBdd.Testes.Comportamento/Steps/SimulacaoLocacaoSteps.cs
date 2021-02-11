using DesafioLocalizaBdd.Api.Controllers;
using DesafioLocalizaBdd.Application;
using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Application.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using TechTalk.SpecFlow;

namespace DesafioLocalizaBdd.Tests.Behavior.Steps
{
    [Binding]
    public class SimulacaoLocacaoSteps
    {
        private Mock<ILocacaoApplication> _locacaoApplication = new Mock<ILocacaoApplication>();
        private LocacaoController _controller;
        private Guid _id;
        private DateTime _inicio;
        private DateTime _fim;
        private decimal valorEstimado;

        public SimulacaoLocacaoSteps()
        {
            _locacaoApplication.Setup(x => x.Estimar(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(300);
            _controller = new LocacaoController(_locacaoApplication.Object);
        }

        [Given(@"que eu desejo locar o veiculo '(.*)' de '(.*)' a '(.*)'")]
        public void DadoQueEuDesejoLocarOVeiculoDeA(Guid id, DateTime inicio, DateTime fim)
        {
            _id = id;
            _inicio = inicio;
            _fim = fim;
        }


        [Then(@"o valor estimado da locacao sera de '(.*)' reais")]
        public void EntaoOValorEstimadoDaLocacaoSeraDeReais(decimal valor)
        {
            var resultado = _controller.Get(_id, _inicio, _fim);
            valorEstimado = GetOkObject<decimal>(resultado);
            valorEstimado.Should().Be(valor);
        }

        protected T GetOkObject<T>(IActionResult result)
        {
            var okObjectResult = (OkObjectResult)result;
            return (T)okObjectResult.Value;
        }
    }
}
