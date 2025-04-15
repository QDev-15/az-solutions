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
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(AZDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<Role> GetByTypeAsync(string roleType)
        {
           return await _context.Roles.FirstOrDefaultAsync(r => r.RoleType.ToLower() == roleType.ToLower());
        }
    }
}
