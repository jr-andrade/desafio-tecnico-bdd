using DesafioLocalizaBdd.Domain.ValueObjects.Veiculo;
using Flunt.Validations;
using System;

namespace DesafioLocalizaBdd.Domain.Entidades
{
    /// <summary>
    /// Entidade de domínio que representa um Veículo
    /// </summary>
    public class Veiculo : Entity
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="placa"></param>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="ano"></param>
        /// <param name="valorHora"></param>
        /// <param name="combustivel"></param>
        /// <param name="limitePortaMalas"></param>
        /// <param name="categoria"></param>
        public Veiculo(string placa, Marca marca, Modelo modelo, int ano, decimal valorHora, Combustivel combustivel, decimal limitePortaMalas, Categoria categoria)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            ValorHora = valorHora;
            Combustivel = combustivel;
            LimitePortaMalas = limitePortaMalas;
            Categoria = categoria;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(Placa, nameof(Placa), "Placa não pode ser nulo ou branco")
                .HasLen(Placa, 7, nameof(Placa), "CPF deve possuir 7 dígitos")

                .IsNotNull(Marca, nameof(Marca), "Marca não pode ser nula")

                .IsNotNull(Modelo, nameof(Modelo), "Modelo não pode ser nulo")

                .IsGreaterThan(Ano, 2017, nameof(Ano), "Veículo não pode ser de ano anterior a 2017")

                .IsNotNull(ValorHora, nameof(ValorHora), "Valor hora não pode ser nulo")
                .IsGreaterThan(ValorHora, 0, nameof(ValorHora), "Valor hora deve ser maior que 0")
                
                .IsNotNull(LimitePortaMalas, nameof(LimitePortaMalas), "Limite do porta malas não pode ser nulo")
                .IsGreaterThan(LimitePortaMalas, 0, nameof(LimitePortaMalas), "Limite do porta malas deve ser maior que 0")
                
            );

            if (Marca != null)
                AddNotifications(Marca);

            if (Modelo != null)
                AddNotifications(Modelo);

            AddNotifications(Combustivel);
            AddNotifications(Categoria);
        }

        /// <summary>
        /// Construtor (Utilizado pelo repositório)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="placa"></param>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="ano"></param>
        /// <param name="valorHora"></param>
        /// <param name="combustivel"></param>
        /// <param name="limitePortaMalas"></param>
        /// <param name="categoria"></param>
        public Veiculo(Guid id, string placa, Marca marca, Modelo modelo, int ano, decimal valorHora, Combustivel combustivel, decimal limitePortaMalas, Categoria categoria)
            :this(placa, marca, modelo, ano, valorHora, combustivel, limitePortaMalas, categoria)
        {
            Id = id;

            AddNotifications(new Contract()
               .Requires()
                .IsNotNull(Id, nameof(Id), "Id não pode ser nulo ou branco")
            );
        }

        /// <summary>
        /// Placa
        /// </summary>
        public string Placa { get; private set; }

        /// <summary>
        /// Marca
        /// </summary>
        public Marca Marca { get; private set; }

        /// <summary>
        /// Modelo
        /// </summary>
        public Modelo Modelo { get; set; }

        /// <summary>
        /// Ano
        /// </summary>
        public int Ano { get; private set; }

        /// <summary>
        /// Valor hora 
        /// </summary>
        public decimal ValorHora { get; set; }
        
        /// <summary>
        /// Combustível
        /// </summary>
        public Combustivel Combustivel { get; set; }

        /// <summary>
        /// Limite do porta malas
        /// </summary>
        public decimal LimitePortaMalas { get; set; }

        /// <summary>
        /// Categoria
        /// </summary>
        public Categoria Categoria { get; private set; }
    }
}
