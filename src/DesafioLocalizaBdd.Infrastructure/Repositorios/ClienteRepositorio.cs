using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;
using DesafioLocalizaBdd.Domain.ValueObjects.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioLocalizaBdd.Infrastructure.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private static List<Cliente> _clientes = new List<Cliente>() {
            new Cliente(new Guid("3af04235-077e-4791-a693-a386a9a4d9a0"),
                        "Cliente Teste", 
                        "09784494604",
                        new DateTime(1989, 06, 22),
                        new Endereco(
                            "31080170",
                            "Rua Carmesia",
                            1381,
                            "Apto 302",
                            "Belo Horizonte",
                            "Minas Gerais"),
                        "12345678" 
                ),
            new Cliente(new Guid("26f734ca-d410-4955-9076-13b7ffeee0fb"),
                        "Cliente Teste2",
                        "09773660656",
                        new DateTime(1990, 06, 15),
                        new Endereco(
                            "31080170",
                            "Rua Carmesia",
                            1381,
                            "Apto 302",
                            "Belo Horizonte",
                            "Minas Gerais"),
                        "12345678"
                )
        };
    

        public Cliente Cadastrar(Cliente cliente)
        {
            var guid = Guid.NewGuid();
            var clienteCadastrado = new Cliente(guid, cliente.Nome, cliente.Cpf, cliente.Aniversario, cliente.Endereco, cliente.Senha);
            _clientes.Add(clienteCadastrado);
            return clienteCadastrado;
        }

        public IEnumerable<Cliente> Listar()
        {
            return _clientes;
        }

        public Cliente Obter(Guid id)
        {
            return _clientes.FirstOrDefault(c => c.Id == id);
        }
    }
}
