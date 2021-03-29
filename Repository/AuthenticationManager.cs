using Microsoft.IdentityModel.Tokens;
using ServiceBookingJwt.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBookingJwt.Repository
{
    public class AuthenticationManager:IAuthenticationManager
    {
        private readonly ServiceBookingContext users = new ServiceBookingContext();

        private readonly string tokenKey;
        public AuthenticationManager(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }
        public string Authenticate(string username, string password)
        {
            if (!users.UserServiceInfos.Any(u => u.Username == username && u.Password == password))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
