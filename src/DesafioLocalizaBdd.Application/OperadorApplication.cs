using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;

namespace DesafioLocalizaBdd.Application
{
    /// <summary>
    /// Aplicação responsável pelo cadastro de operadores
    /// </summary>
    public class OperadorApplication : IOperadorApplication
    {
        private readonly IOperadorRepositorio _operadorRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="operadorRepositorio"></param>
        /// <param name="usuarioRepositorio"></param>
        public OperadorApplication(IOperadorRepositorio operadorRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _operadorRepositorio = operadorRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        /// <summary>
        /// Cadastra um operador
        /// </summary>
        /// <param name="operadorModel"></param>
        /// <returns></returns>
        public Operador Cadastrar(OperadorModel operadorModel)
        {
            var operador = new Operador(operadorModel.Nome, operadorModel.Matricula, operadorModel.Senha);

            if(operador.Valid)
            {
                var id = _operadorRepositorio.Cadastrar(operador);

                operador.AtualizarId(id);

                _usuarioRepositorio.Cadastrar(operador);
                
                return operador;
            }

            return null;
        }
    }
}
