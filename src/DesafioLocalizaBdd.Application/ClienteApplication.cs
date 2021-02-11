using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Application.Models;
using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;

namespace DesafioLocalizaBdd.Application
{
    /// <summary>
    /// Aplicação responsável pelo cadastro de clientes
    /// </summary>
    public class ClienteApplication : IClienteApplication
    {
        private readonly IClienteRepositorio _clienteRepository;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="clienteRepository"></param>
        public ClienteApplication(IClienteRepositorio clienteRepository, IUsuarioRepositorio usuarioRepositorio)
        {
            _clienteRepository = clienteRepository;
            _usuarioRepositorio = usuarioRepositorio;
        }

        /// <summary>
        /// Cadastra um cliente
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Objeto contendo o cliente cadastrado</returns>
        public Cliente Cadastrar(ClienteModel model)
        {
            var cliente = new Cliente(model.Nome, model.Cpf, model.Aniversario,
                                        new Domain.ValueObjects.Cliente.Endereco(
                                            model.Endereco.Cep,
                                            model.Endereco.Logradouro,
                                            model.Endereco.Numero,
                                            model.Endereco.Complemento,
                                            model.Endereco.Cidade,
                                            model.Endereco.Estado
                                        ),
                                        model.Senha);

            if (cliente.Valid)
            {
                cliente = _clienteRepository.Cadastrar(cliente);

                _usuarioRepositorio.Cadastrar(cliente);

                return cliente;
            }

            return null;
        }
    }
}
