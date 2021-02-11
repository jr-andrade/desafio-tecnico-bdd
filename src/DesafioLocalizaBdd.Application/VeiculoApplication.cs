using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;
using DesafioLocalizaBdd.Domain.ValueObjects.Veiculo;

namespace DesafioLocalizaBdd.Application
{
    /// <summary>
    /// Aplicação responsável pelo cadastro de veículos
    /// </summary>
    public class VeiculoApplication : IVeiculoApplication
    {
        private readonly IVeiculoRepositorio _veiculoRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="veiculoRepositorio"></param>
        public VeiculoApplication(IVeiculoRepositorio veiculoRepositorio)
        {
            _veiculoRepositorio = veiculoRepositorio;
        }

        /// <summary>
        /// Cadastra um veículo
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Objeto contendo o veículo cadastrado</returns>
        public Veiculo Cadastrar(VeiculoModel model)
        {
            int combustivel = (int)model.Combustivel;
            int categoria = (int)model.Categoria;

            var veiculo = new Veiculo(model.Placa, new Marca(model.Marca), new Modelo(model.Modelo), model.Ano, model.ValorHora,
                new Combustivel((Domain.ValueObjects.Veiculo.TipoCombustivel)combustivel), model.LimitePortaMalas,
                new Categoria((Domain.ValueObjects.Veiculo.TipoCategoria)categoria));

            if (veiculo.Valid)
            {
                return _veiculoRepositorio.Cadastrar(veiculo);
            }

            return null;
        }
    }
}
