using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Infrastructure.Configuration;
using Api.Infrastructure.Extensions;
using Api.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace Api.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtConfig _jwtConfig;

        public JwtHandler(JwtConfig jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }

        public JwtViewModel CreateToken(string userId, string role)
        {
            var now = DateTime.UtcNow;

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString(), ClaimValueTypes.Integer64)
            };

            var expires = now.AddMinutes(_jwtConfig.ExpiryMinutes);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key)), SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtViewModel
            {
                Token = token,
                Expires = expires.ToTimestamp()
            };
        }

    }
}