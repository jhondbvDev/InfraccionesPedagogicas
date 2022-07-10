using InfraccionesPedagogicas.Application.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Infrastructure.Identity
{
    public class TokenService : ITokenService
    {

        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _expiryMinutes;
        public TokenService(string key,string issueer, string audience, string expiryMinutes)
        {
            _key = key;
            _issuer = issueer;
            _audience = audience;
            _expiryMinutes = expiryMinutes;
        }
        public string GenerateJWTToken(string userId, string name,string userName, IList<string> roles)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {

                new Claim(ClaimTypes.Name, name),
                new Claim("UserId", userId),
                new Claim("email", userName)
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));


            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_expiryMinutes)),
                signingCredentials: signingCredentials
           );

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodedToken;
        }
    }
}
