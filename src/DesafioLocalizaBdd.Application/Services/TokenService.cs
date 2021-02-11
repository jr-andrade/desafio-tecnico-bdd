using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Domain.Entidades;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafioLocalizaBdd.Application.Services
{
    //TODO: Mover para camada Application

    /// <summary>
    /// Serviço para geração do token de autenticação
    /// </summary>
    public class TokenService : ITokenService
    {
        private readonly string chavePrivada = "fedaf7d8863b48e197b9287d492b708e";

        //TODO: Verificar concorrência. Estático? Lock? Verificar se usuário já possui token?

        /// <summary>
        /// Gera um token para o usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public string GerarToken(Usuario usuario)
        {
            var handler = new JwtSecurityTokenHandler();
            var chave = Encoding.ASCII.GetBytes(chavePrivada);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Perfil.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
    }
}
