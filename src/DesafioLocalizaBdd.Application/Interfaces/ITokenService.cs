using DesafioLocalizaBdd.Domain.Entidades;

namespace DesafioLocalizaBdd.Application.Interfaces
{
    /// <summary>
    /// Interface para o Serviço de Token
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Gera um token para o usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>String contendo o token gerado</returns>
        public string GerarToken(Usuario usuario);
    }
}
