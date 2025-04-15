using AZ.Infrastructure.Entities;
using AZ.Infrastructure.Interfaces.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly AppSettingsJwt _appSettingJwt;

        public TokenService(IConfiguration configuration, AppSettingsJwt appSettingJwt)
        {
            _configuration = configuration;
            _appSettingJwt = appSettingJwt;
        }

        public string GenerateAccessToken(User user, string jti)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.UserRoles?.FirstOrDefault()!.Role.Name),
                new Claim(ClaimTypes.GivenName, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("avatar", user.Avatar?.FilePath??""),
                new Claim(JwtRegisteredClaimNames.Jti, jti),
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettingJwt.Key!));

            var token = new JwtSecurityToken(
                issuer: _appSettingJwt.Issuer,// _configuration["Jwt:Issuer"],
                audience: _appSettingJwt.Audience, //_configuration["Jwt:Audience"],
                expires: DateTime.UtcNow.AddMinutes(_appSettingJwt.AccessTokenExpirationMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomBytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettingJwt.Key)),// _configuration["Jwt:Secret"]!)),
                ValidateLifetime = false // vì token đã hết hạn
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
                return securityToken is JwtSecurityToken jwtSecurityToken &&
                       jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase)
                       ? principal
                       : null;
            }
            catch
            {
                return null;
            }
        }
    }

}
