using Abp.Domain.Repositories;
using Backend.Dtos;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class UserAppService : BackendAppServiceBase, IUserAppService
    {
        private readonly IRepository<User> _userRepository;

        public UserAppService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> ChangeUserLock(ChangeUserLockInput input)
        {
            var user = await _userRepository.FirstOrDefaultAsync(input.Id);
            if (user == null) { return true; }
            user.Locked = input.Locked;
            return true;
        }
    }
}
