namespace DesafioLocalizaBdd.Domain.Entidades
{
    /// <summary>
    /// Entidade de domínio que representa um Cliente
    /// Cliente também é um Usuário
    /// </summary>
    public class Cliente : Usuario
    {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="token"></param>
        public Cliente(string cpf, string token) : base(token)
        {
            Cpf = cpf;
        }
        /// <summary>
        /// CPF
        /// </summary>
        public string Cpf { get; private set; }
    }
}
