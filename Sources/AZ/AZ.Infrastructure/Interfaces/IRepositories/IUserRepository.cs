using AZ.Core.DTOs;
using AZ.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Interfaces.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetByUserNameAsync(string userName);
    }
}
