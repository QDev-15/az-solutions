using AZ.Core.DTOs;
using AZ.Infrastructure.Extentions;
using AZ.Infrastructure.Interfaces.IProviders;
using AZ.Infrastructure.Interfaces.IRepositories;
using AZ.Infrastructure.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Infrastructure.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IMappingProvider mapping, ILogQueueProvider log, IUserRepository userRepository) : base(log, mapping)
        {
            _userRepository = userRepository;
        }
        public async Task<UserResponse> GetById(int id)
        {
            try
            {
                if (id <= 0) throw new Exception("invalid get user");
                var user = await _userRepository.GetByIdAsync(id);
                return _mapping.ReturnUserModel(user);
            } catch(Exception ex)
            {
                _log.LogError("not user found: " + ex.Message, ex.Source, ex.StackTrace);
                throw new Exception("not user found");
            }
        }
    }
}
