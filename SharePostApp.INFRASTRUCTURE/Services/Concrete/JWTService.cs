using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SharePostApp.Core.Settings;
using SharePostApp.INFRASTRUCTURE.Services.Abstract;

namespace SharePostApp.INFRASTRUCTURE.Services.Concrete
{
    public class JWTService : IJWTService
    {
        private JwtSettings _settings;
        public JWTService(IConfiguration configuration)
        {
            _settings = configuration.GetSection("JWTSettings").Get<JwtSettings>();
        }

        public string CreateToken(long userId)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToString(), ClaimValueTypes.Integer64)
            };

            var expires = now.AddMinutes(_settings.Expiry);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey)),
                SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                issuer: _settings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return token;
        }
    }
}
