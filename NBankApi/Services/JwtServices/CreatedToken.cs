using Microsoft.Extensions.Configuration;
using NBankApi.Models.JwtTokens;
using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NBankApi.Services.JwtServices
{
    public class CreatedToken
    {
        private IConfiguration _configuration;
        public CreatedToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }
            public string CrearToken(string id, string rol)
        {
            Jwt jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            var claims = new[]
            {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("id", id),
                        new Claim("Rol", rol)
                    };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                signingCredentials: singIn);
            string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenStr;
        }
    }
}
