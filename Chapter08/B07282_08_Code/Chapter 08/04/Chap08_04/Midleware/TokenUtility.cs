using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Chap08_04.Midleware
{
    public class TokenUtility
    {
        private const string JwtKey = "abcdefghijklmnopqrstuvwxyz";
        private const string TokenIssuer = "gaurav-arora.com";


        public JwtSecurityToken GenerateToken(string userName, string userId)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, userId)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(TokenIssuer,
                TokenIssuer,
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            return token;
        }
    }
}