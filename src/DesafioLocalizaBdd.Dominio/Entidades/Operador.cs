namespace DesafioLocalizaBdd.Domain.Entidades
{
    /// <summary>
    /// Entidade de domínio que representa um Operador
    /// Operador também é um usuário
    /// </summary>
    public class Operador : Usuario
    {
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        /// <param name="matricula"></param>
        /// <param name="token"></param>
        public Operador(string matricula, string token) : base(token)
        {
            Matricula = matricula;
        }

        /// <summary>
        /// Matricula
        /// </summary>
        public string Matricula { get; set; }
    }
}
