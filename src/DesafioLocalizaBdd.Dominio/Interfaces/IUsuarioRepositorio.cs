using DesafioLocalizaBdd.Domain.Entidades;

namespace DesafioLocalizaBdd.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de usuários
    /// </summary>
    public interface IUsuarioRepositorio
    {
        /// <summary>
        /// Obtém um usuário
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <returns>Objeto contendo o usuário obtido</returns>
        public Usuario Obter(string login, string senha);
    }
}
