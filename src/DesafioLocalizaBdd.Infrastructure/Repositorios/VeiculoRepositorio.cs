using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;
using DesafioLocalizaBdd.Domain.ValueObjects.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioLocalizaBdd.Infrastructure.Repositorios
{
    public class VeiculoRepositorio : IVeiculoRepositorio
    {
        private static List<Veiculo> _veiculos = new List<Veiculo>() {
            new Veiculo(new Guid("3fc8ae87-d130-45ae-ac98-a1895cf87743"), "QUI1104", new Marca("Ford"), new Modelo("Focus"), 2020, 5, new Combustivel(TipoCombustivel.gasolina), 400, new Categoria(TipoCategoria.completo)),
            new Veiculo(new Guid("e6287488-f18b-488f-94bb-5256c0b274bb"), "QUI1104", new Marca("Ford"), new Modelo("Focus"), 2020, 5, new Combustivel(TipoCombustivel.gasolina), 400, new Categoria(TipoCategoria.completo)),
            new Veiculo(new Guid("c705d61a-646f-4fd9-9156-c3d21daafbff"), "QUI1104", new Marca("Ford"), new Modelo("Focus"), 2020, 5, new Combustivel(TipoCombustivel.gasolina), 400, new Categoria(TipoCategoria.completo))
        };

        public Veiculo Cadastrar(Veiculo veiculo)
        {
            var guid = Guid.NewGuid();
            var veiculoCadastrado = new Veiculo(guid, veiculo.Placa, veiculo.Marca, veiculo.Modelo, veiculo.Ano, veiculo.ValorHora, veiculo.Combustivel, veiculo.LimitePortaMalas, veiculo.Categoria);
            _veiculos.Add(veiculoCadastrado);

            return veiculoCadastrado;
        }

        public IEnumerable<Veiculo> Listar()
        {
            return _veiculos;
        }

        public Veiculo Obter(Guid id)
        {
            return _veiculos.FirstOrDefault(v => v.Id == id);
        }
    }
}
