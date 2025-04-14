using AZ.Core.DTOs;
using AZ.Infrastructure.Entities;
using AZ.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AZ.Infrastructure.Interfaces.IProviders;

namespace AZ.Infrastructure.Providers
{
    public class MappingProvider : IMappingProvider
    {
        private readonly ITimeZoneProvider _timeZoneProvider;

        public MappingProvider(ITimeZoneProvider timeZoneProvider)
        {
            _timeZoneProvider = timeZoneProvider;
        }

        public UserResponse ReturnModel(User user)
        {
            if (user == null) return new UserResponse();
            var uresponse = new UserResponse()
            {
                Id = user.Id,
                Avatar = user.Avatar?.FilePath,
                Thumbnail = user.Avatar?.Thumbnail,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Status = user.Status.ToString(),
                CreatedAt = ToLocal(user.CreatedAt),
                UpdatedAt = ToLocal(user.UpdatedAt)
            };
            return uresponse;
        }

        public DateTime ToLocal(DateTime time)
        {
            return DateTimeHelper.ConvertUtcToLocal(time, _timeZoneProvider.GetTimeZoneId());
        }

        public DateTime ToUTC(DateTime time)
        {
            return DateTimeHelper.ConvertLocalToUtc(time, _timeZoneProvider.GetTimeZoneId());
        }
    }
}
