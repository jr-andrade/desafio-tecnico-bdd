using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioLocalizaBdd.Infrastructure.Repositorios
{
    public class OperadorRepositorio : IOperadorRepositorio
    {
        private static List<Operador> _operadores = new List<Operador>()
        {
            new Operador(new Guid("b6aec0a9-31de-4355-ac17-bb4b57115496"), "Operador Teste", "130364", "12345678"),
            new Operador(new Guid("7d75b9cd-0624-4506-a7f1-85270297afd3"), "Operador Teste2", "130365", "12345678")
        };

        public Operador Cadastrar(Operador operador)
        {
            var guid = Guid.NewGuid();
            var operadorCadastrado = new Operador(guid, operador.Nome, operador.Matricula, operador.Senha);
            _operadores.Add(operadorCadastrado);
            return operadorCadastrado;
        }

        public IEnumerable<Operador> Listar()
        {
            return _operadores;
        }

        public Operador Obter(Guid id)
        {
            return _operadores.FirstOrDefault(o => o.Id == id);
        }
    }
}
