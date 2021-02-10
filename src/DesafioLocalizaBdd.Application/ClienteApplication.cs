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
        /// <param name="clienteModel"></param>
        /// <returns>Objeto contendo o cliente cadastrado</returns>
        public Cliente Cadastrar(ClienteModel clienteModel)
        {
            var cliente = new Cliente(clienteModel.Nome, clienteModel.Cpf, clienteModel.Aniversario,
                                        new Domain.ValueObjects.Cliente.Endereco(
                                            clienteModel.Endereco.Cep,
                                            clienteModel.Endereco.Logradouro,
                                            clienteModel.Endereco.Numero,
                                            clienteModel.Endereco.Complemento,
                                            clienteModel.Endereco.Cidade,
                                            clienteModel.Endereco.Estado
                                        ), clienteModel.Senha);

            if (cliente.Valid)
            {
                var id = _clienteRepository.Cadastrar(cliente);

                cliente.AtualizarId(id);

                _usuarioRepositorio.Cadastrar(cliente);

                return cliente;
            }

            return null;
        }
    }
}
