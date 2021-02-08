using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;
using System;

namespace DesafioLocalizaBdd.Application
{
    /// <summary>
    /// Aplicação responsável por realizar a autenticação do usuário
    /// </summary>
    public class LoginApplication : ILoginApplication
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IOperadorRepositorio _operadorRepositorio;
        private readonly ITokenService _tokenService;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        public LoginApplication(IUsuarioRepositorio usuarioRepositorio, IClienteRepositorio clienteRepositorio, IOperadorRepositorio operadorRepositorio, ITokenService tokenService)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _clienteRepositorio = clienteRepositorio;
            _operadorRepositorio = operadorRepositorio;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Autentica um usuário
        /// </summary>
        /// <param name="login"></param>
        /// <param name="senha"></param>
        /// <returns>Especialização de usuário, podendo ser um cliente ou um operador</returns>
        public Usuario Autenticar(string login, string senha)
        {
            var usuario = _usuarioRepositorio.Obter(login, senha);

            if(usuario == null)
            {
                //TODO: Alterar para NotFoundException
                throw new Exception("login ou senha inválidos");
            }

            Usuario usuarioAutenticado;

            if (usuario.Perfil == Perfil.Cliente)
            {
                usuarioAutenticado = _clienteRepositorio.Obter(usuario.Id);
            }
            else
            {
                usuarioAutenticado = _operadorRepositorio.Obter(usuario.Id);
            }

            var token = _tokenService.GerarToken(usuario);

            usuarioAutenticado.Autenticar(token);

            return usuarioAutenticado;
        }
    }
}
