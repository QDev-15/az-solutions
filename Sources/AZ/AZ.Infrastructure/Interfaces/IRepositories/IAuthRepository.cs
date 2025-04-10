using AZ.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Interfaces.IRepositories
{
    public interface IAuthRepository
    {
        Task<AuthResponse> LoginAsync(LoginRequest request, string ipAddress, string userAgent, string timezone);
        Task<bool> RegisterAsync(RegisterRequest request);
        Task<bool> RefreshTokenAsync(string refreshToken);
        Task<bool> LogoutAsync(string currentRefreshToken);
    }
}
