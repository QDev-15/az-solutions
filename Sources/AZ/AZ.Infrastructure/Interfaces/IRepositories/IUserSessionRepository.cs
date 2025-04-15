using AZ.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Interfaces.IRepositories
{
    public interface IUserSessionRepository : IRoleRepository<UserSession>
    {
        Task<UserSession> GetByRefreshToken(string refreshToken);
        Task<UserSession> GetByJtiAsync(string jti);
    }
}
