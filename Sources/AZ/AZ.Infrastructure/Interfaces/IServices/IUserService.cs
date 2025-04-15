using AZ.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Interfaces.IServices
{
    public interface IUserService
    {
        Task<UserResponse> GetById(int id);
    }
}
