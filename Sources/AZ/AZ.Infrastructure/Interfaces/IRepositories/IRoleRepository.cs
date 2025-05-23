﻿using AZ.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Interfaces.IRepositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetByTypeAsync(string roleType);
    }
}
