namespace DesafioLocalizaBdd.Application.Models
{
    /// <summary>
    /// Modelo representacional de um veículo
    /// </summary>
    public class VeiculoModel
    {
        /// <summary>
        /// Placa
        /// </summary>
        public string Placa { get; set; }

        /// <summary>
        /// Marca
        /// </summary>
        public string Marca { get; set; }

        /// <summary>
        /// Modelo
        /// </summary>
        public string Modelo { get; set; }

        /// <summary>
        /// Ano
        /// </summary>
        public int Ano { get; set; }

        /// <summary>
        /// Valor hora
        /// </summary>
        public decimal ValorHora { get; set; }

        /// <summary>
        /// Combustível
        /// </summary>
        public TipoCombustivel Combustivel { get; set; }

        /// <summary>
        /// Limite do porta malas
        /// </summary>
        public decimal LimitePortaMalas { get; set; }

        /// <summary>
        /// Categoria
        /// </summary>
        public TipoCategoria Categoria { get; set; }
    }

    /// <summary>
    /// Tipos de combustível
    /// </summary>
    public enum TipoCombustivel
    {
        gasolina = 1,
        alcool,
        diesel
    }

    /// <summary>
    /// Categorias
    /// </summary>

    public enum TipoCategoria
    {
        basico = 1,
        completo,
        luxo
    }
}
