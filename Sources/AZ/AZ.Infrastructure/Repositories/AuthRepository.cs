using AZ.Core.DTOs;
using AZ.Core.Enums;
using AZ.Infrastructure.DataAccess;
using AZ.Infrastructure.Entities;
using AZ.Infrastructure.Interfaces.IRepositories;
using AZ.Infrastructure.Interfaces.IServices;
using AZ.Infrastructure.Interfaces.Providers;
using AZ.Infrastructure.Providers;
using AZ.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AZDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AppSettingsJwt _appSettingJwt;
        private readonly IMappingProvider _mappingProvider;
        private readonly ILogQueueProvider _logs;

        public AuthRepository(AZDbContext context, ITokenService tokenService, IPasswordHasher<User> passwordHasher,
            AppSettingsJwt appSettingsJwt, MappingProvider mappingProvider, ILogQueueProvider logs)
        {
            _context = context;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
            _appSettingJwt = appSettingsJwt;
            _mappingProvider = mappingProvider;
            _logs = logs;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request, string ipAddress, string userAgent, string timezone)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == request.UsernameOrEmail || u.Email == request.UsernameOrEmail);

                if (user == null ||
                    _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password) != PasswordVerificationResult.Success)
                {
                    throw new UnauthorizedAccessException("Invalid credentials.");
                }

                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                var session = new UserSession
                {
                    UserId = user.Id,
                    RefreshToken = refreshToken,
                    RefreshTokenExpiry = DateTime.UtcNow.AddDays(_appSettingJwt.RefreshTokenExpirationDays),
                    AccessToken = accessToken,
                    CreatedAt = DateTime.UtcNow,
                    IpAddress = ipAddress,
                    UserAgent = userAgent,
                    TimeZone = timezone
                };

                _context.UserSessions.Add(session);
                await _context.SaveChangesAsync();

                return new AuthResponse
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    ExpiryTime = DateTime.UtcNow.AddMinutes(_appSettingJwt.AccessTokenExpirationMinutes),
                    User = _mappingProvider.ReturnModel(user)
                };
            } catch(Exception ex)
            {
                _logs.LogError(ex.Message);
                return new AuthResponse
                {
                    AccessToken = null,
                    RefreshToken = null
                };
            }
        }

        public async Task<bool> RefreshTokenAsync(string refreshToken)
        {
            try
            {
                var session = await _context.UserSessions
                    .Include(s => s.User)
                    .FirstOrDefaultAsync(s => s.RefreshToken == refreshToken && s.IsActive);

                if (session == null || session.RefreshTokenExpiry <= DateTime.UtcNow)
                    throw new UnauthorizedAccessException("Invalid or expired refresh token.");

                var newAccessToken = _tokenService.GenerateAccessToken(session.User);
                var newRefreshToken = _tokenService.GenerateRefreshToken();

                // Revoke old session
                session.RevokedAt = DateTime.UtcNow;

                var newSession = new UserSession
                {
                    UserId = session.User.Id,
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken,
                    RefreshTokenExpiry = DateTime.UtcNow.AddDays(_appSettingJwt.RefreshTokenExpirationDays),
                    CreatedAt = DateTime.UtcNow,
                    IpAddress = session.IpAddress,
                    UserAgent = session.UserAgent
                };

                _context.UserSessions.Add(newSession);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            

        }

        public async Task<bool> LogoutAsync(string refreshToken)
        {
            try
            {
                var session = await _context.UserSessions.FirstOrDefaultAsync(s => s.RefreshToken == refreshToken);
                if (session != null)
                {
                    session.RevokedAt = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                }
                return true;
            } catch(Exception ex)
            {
                return false;
            }
            
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            if (await _context.Users.AnyAsync(u => u.Username == request.Username || u.Email == request.Email))
                throw new Exception("Username or Email already exists.");

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = "", // Will be hashed below
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Status = UserStatus.Active
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);
            _context.Users.Add(user);

            // Optionally assign default role
            var defaultRole = await _context.Roles.FirstOrDefaultAsync(r => r.RoleType == "User");
            if (defaultRole != null)
            {
                _context.UserRoles.Add(new UserRole { User = user, Role = defaultRole });
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }

}
