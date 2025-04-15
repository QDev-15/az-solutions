using AZ.Infrastructure.DataAccess;
using AZ.Infrastructure.Entities;
using AZ.Infrastructure.Interfaces.IRepositories;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AZDbContext _dbContext;
        public UserRepository(AZDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);            
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _dbContext.Users
                .Include(i => i.UserRoles)
                    .ThenInclude(r => r.Role)
                .Include(i => i.Avatar)
                .FirstOrDefaultAsync(u => u.Username.ToLower() == userName.ToLower() || u.Email.ToLower() == userName.ToLower());
        }
    }
}
