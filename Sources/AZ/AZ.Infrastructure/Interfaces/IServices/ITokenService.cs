using AZ.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Interfaces.IServices
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user, string jti);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    }
}
