using AZ.Infrastructure.DataAccess;
using AZ.Infrastructure.Entities;
using AZ.Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Repositories
{
    public class UserSessionRepository : Repository<UserSession>, IUserSessionRepository
    {
        public UserSessionRepository(AZDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<UserSession> GetByJtiAsync(string jti)
        {
            return await _context.UserSessions.FirstOrDefaultAsync(x => x.Jti == jti);
        }

        public async Task<UserSession> GetByRefreshToken(string refreshToken)
        {
            return await _context.UserSessions
                    .Include(s => s.User)
                        .ThenInclude(t => t.UserRoles)
                            .ThenInclude(a => a.Role)
                    .FirstOrDefaultAsync(s => s.RefreshToken == refreshToken);
        }
    }
}
