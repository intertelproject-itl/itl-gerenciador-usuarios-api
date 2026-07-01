using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace itl_gerenciador_usuarios_api.Services.v1.Encrypt
{
    public class JwtTokenService(IConfiguration config)
    {
        private readonly IConfiguration _config = config;

        public LoginResponseDTO GerarToken(UsuarioModel usuario)
        {
            var jwt = _config.GetSection("Jwt");
            var key = jwt["Key"]!;
            var issuer = jwt["Issuer"]!;
            var audience = jwt["Audience"]!;
            var expireMinutes = int.Parse(jwt["ExpireMinutes"]!);

            var now = DateTime.UtcNow;
            var expires = now.AddMinutes(expireMinutes);

            var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, usuario.IdUsuario.ToString()),
            new(JwtRegisteredClaimNames.Email, usuario.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new("idUsuario", usuario.IdUsuario.ToString()),
        };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new LoginResponseDTO { AccessToken = tokenString, Expiration = expires, Usuario = usuario };
        }
    }
}
