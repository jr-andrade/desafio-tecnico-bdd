using DesafioLocalizaBdd.Domain.Entidades;

namespace DesafioLocalizaBdd.Application.Interfaces
{
    /// <summary>
    /// Interface para a aplicação de Login
    /// </summary>
    public interface ILoginApplication
    {
        /// <summary>
        /// Autentica um usuário
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <returns>Objeto representacional da entidade Usuário</returns>
        public Usuario Autenticar(string login, string senha);
    }
}
