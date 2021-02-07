using Api.Seguridad.Core.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Seguridad.Core.JWTLogic
{
    public class JwtGenerator : IJwtGenerator
    {
        public Task<string> CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("username", user.UserName),
                new Claim("name", user.Name),
                new Claim("apellido", user.Surname)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PxGIbVY9zg6aQFEQuKc61nbIX0kFHvba"));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = credential
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);

            return Task.Run(() => tokenHandler.WriteToken(token));
        }
    }
}
