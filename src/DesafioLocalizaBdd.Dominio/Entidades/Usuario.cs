namespace DesafioLocalizaBdd.Domain.Entidades
{
    /// <summary>
    /// Entidade de domínio que representa um Usuário do sistema
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="token"></param>
        public Usuario(string token)
        {
            Token = token;
        }
        
        /// <summary>
        /// Login
        /// </summary>
        public string Login { get; private set; }
        
        /// <summary>
        /// Senha
        /// </summary>
        public string Senha { get; private set; }

        /// <summary>
        /// Token de autenticação
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; private set; }
    }
}
