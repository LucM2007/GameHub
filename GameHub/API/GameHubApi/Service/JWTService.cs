using GameHubApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace GameHubApi.Service
{
    public class JWTService
    {
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtSecurityTokenHandler _jwtHandler = new();

        public JWTService(string jwtSecret)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSecret));

            _signingCredentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);
        }

        public string GiveToken(Accounts account)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, account.UserName),
                new Claim(ClaimTypes.NameIdentifier, account.AccountId.ToString()),
                new Claim(ClaimTypes.Role, account.Role.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "GameHubApi",
                audience: "GameHubApi",
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: _signingCredentials);
            return _jwtHandler.WriteToken(token);
        }
    }
}


