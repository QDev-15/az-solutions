using AZ.Core.DTOs;
using AZ.Core.Enums;
using AZ.Infrastructure.DataAccess;
using AZ.Infrastructure.Entities;
using AZ.Infrastructure.Interfaces.IRepositories;
using AZ.Infrastructure.Interfaces.IServices;
using AZ.Infrastructure.Interfaces.IProviders;
using AZ.Infrastructure.Providers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AZ.Infrastructure.Extentions;
using Microsoft.AspNetCore.Http;
using Azure.Core;

namespace AZ.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AppSettingsJwt _appSettingJwt;
        private readonly IMappingProvider _mappingProvider;
        private readonly ILogQueueProvider _logs;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserSessionRepository _userSessionRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IUserRepository userRepository, ITokenService tokenService, IPasswordHasher<User> passwordHasher, IHttpContextAccessor httpContextAccessor,
            AppSettingsJwt appSettingsJwt, IMappingProvider mappingProvider, ILogQueueProvider logs, IUserSessionRepository userSessionRepository,
            IRoleRepository roleRepository)
        {
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
            _appSettingJwt = appSettingsJwt;
            _mappingProvider = mappingProvider;
            _logs = logs;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _userSessionRepository = userSessionRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request, string ipAddress, string userAgent, string timezone)
        {
            try
            {
                var user = await _userRepository.GetByUserNameAsync(request.UsernameOrEmail);
                if (user == null ||
                    _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password) != PasswordVerificationResult.Success)
                {
                    throw new UnauthorizedAccessException("Invalid credentials.");
                }
                var jti = Guid.NewGuid().ToString();
                var accessToken = _tokenService.GenerateAccessToken(user, jti);
                var refreshToken = _tokenService.GenerateRefreshToken();
                var userContext = _httpContextAccessor.HttpContext?.User;
                
                var session = new UserSession
                {
                    UserId = user.Id,
                    RefreshToken = refreshToken,
                    RefreshTokenExpiry = DateTime.UtcNow.AddDays(_appSettingJwt.RefreshTokenExpirationDays),
                    AccessToken = accessToken,
                    CreatedAt = DateTime.UtcNow,
                    IpAddress = ipAddress,
                    UserAgent = userAgent,
                    TimeZone = timezone,
                    Jti = jti
                };

                await _userSessionRepository.AddAsync(session);
                await _userSessionRepository.SaveChangesAsync();

                return new AuthResponse
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    ExpiryTime = DateTime.UtcNow.AddMinutes(_appSettingJwt.AccessTokenExpirationMinutes),
                    User = _mappingProvider.ReturnUserModel(user)
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

        public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
        {
            try
            {
                var session = await _userSessionRepository.GetByRefreshToken(refreshToken);

                if (session == null || !session.IsActive)
                    throw new UnauthorizedAccessException("Invalid or expired refresh token.");

                var jti = Guid.NewGuid().ToString();
                var newAccessToken = _tokenService.GenerateAccessToken(session.User, jti);
                var newRefreshToken = _tokenService.GenerateRefreshToken();
                var userContext = _httpContextAccessor.HttpContext?.User;
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
                    UserAgent = session.UserAgent,
                    TimeZone = session.TimeZone,
                    Jti = jti
                };

                await _userSessionRepository.AddAsync(newSession);
                await _userSessionRepository.SaveChangesAsync();
                return new AuthResponse
                {
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken
                };
            }
            catch (Exception ex)
            {
                _logs.LogError(ex.Message);
                return null;
            }
            

        }

        public async Task<bool> LogoutAsync(string refreshToken)
        {
            try
            {
                var session = await _userSessionRepository.GetByRefreshToken(refreshToken);
                if (session != null)
                {
                    session.RevokedAt = DateTime.UtcNow;
                    await _userSessionRepository.SaveChangesAsync();
                }
                return true;
            } catch(Exception ex)
            {
                return false;
            }
            
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            var user = await _userRepository.GetByUserNameAsync(request.Username);
            if (user != null)
                throw new Exception("Username or Email already exists.");

            var newUser = new User
            {
                Username = request.Username,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = "", // Will be hashed below
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Status = UserStatus.Active
            };

            newUser.PasswordHash = _passwordHasher.HashPassword(newUser, request.Password);


            // Optionally assign default role
            var defaultRole = await _roleRepository.GetByTypeAsync("User");
            if (defaultRole != null)
            {
                newUser.UserRoles.Add(new UserRole { User = newUser, Role = defaultRole });
            }
            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync();
            return true;
        }
    }

}
