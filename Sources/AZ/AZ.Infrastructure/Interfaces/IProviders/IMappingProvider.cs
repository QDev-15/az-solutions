using AZ.Core.DTOs;
using AZ.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Interfaces.IProviders
{
    public interface IMappingProvider
    {
        DateTime ToLocal(DateTime time);
        DateTime ToUTC(DateTime time);
        UserResponse ReturnModel(User user);
    }
}
