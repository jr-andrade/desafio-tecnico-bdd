using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioLocalizaBdd.Infrastructure.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private static List<Usuario> _usuarios = new List<Usuario>() {
                new Usuario(new Guid("3af04235-077e-4791-a693-a386a9a4d9a0"),
                        "09784494604",
                        "12345678",
                        "Cliente Teste",
                        "Cliente"
                ),
                new Usuario(new Guid("26f734ca-d410-4955-9076-13b7ffeee0fb"),
                        "09773660656",
                        "12345678",
                        "Cliente Teste2",
                        "Cliente"
                ),
                new Usuario(new Guid("b6aec0a9-31de-4355-ac17-bb4b57115496"),
                        "130364",
                        "12345678",
                        "Operador Teste",
                        "Operador"
                ),
                new Usuario(new Guid("7d75b9cd-0624-4506-a7f1-85270297afd3"),
                        "130365",
                        "12345678",
                        "Operador Teste2",
                        "Operador"
                )
        };

        public void Cadastrar(Usuario usuario)
        {
            var usuarioCadastrado = new Usuario(usuario.Id, usuario.Login, usuario.Senha, usuario.Nome, usuario.Perfil);
            _usuarios.Add(usuarioCadastrado);
        }

        public Usuario Obter(string login, string senha)
        {
            return _usuarios.FirstOrDefault(u => u.Login == login && u.Senha == senha);
        }
    }
}
