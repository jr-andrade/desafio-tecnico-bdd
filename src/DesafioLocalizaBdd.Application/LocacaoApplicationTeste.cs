using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Domain.Entidades;
using System;

namespace DesafioLocalizaBdd.Application
{
    public class LocacaoApplicationTeste : ILocacaoApplication
    {
        public Locacao Agendar(Guid veiculoId, Guid clienteId, DateTime inicio, DateTime fim)
        {
            return new Locacao(new Guid(), new Guid(), 10, new DateTime(2021, 03, 01), new DateTime(2021, 03, 02));
        }

        public decimal Estimar(Guid veiculoId, DateTime inicio, DateTime fim)
        {
            return 10;
        }
    }
}
