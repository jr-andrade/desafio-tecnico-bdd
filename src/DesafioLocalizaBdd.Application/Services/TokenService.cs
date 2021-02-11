using DesafioLocalizaBdd.Application.Interfaces;
using DesafioLocalizaBdd.Domain.Entidades;
using DesafioLocalizaBdd.Domain.Helper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafioLocalizaBdd.Application.Services
{
    /// <summary>
    /// Serviço para geração do token de autenticação
    /// </summary>
    public class TokenService : ITokenService
    {
        /// <summary>
        /// Gera um token para o usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public string GerarToken(Usuario usuario)
        {
            var handler = new JwtSecurityTokenHandler();
            var chave = Encoding.ASCII.GetBytes(Constantes.CHAVE_TOKEN_AUTENTICACAO);
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
