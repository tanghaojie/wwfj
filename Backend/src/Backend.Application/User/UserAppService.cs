using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using Backend.Dtos;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public async Task<int> AddUser(AddUserInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Username) || string.IsNullOrWhiteSpace(input.Password))
            {
                throw new UserFriendlyException("请输入用户名或密码");
            }
            if (!new Regex(@"^[a-zA-Z\u4e00-\u9fa5][a-zA-Z0-9\u4e00-\u9fa5_]{1,13}$").Match(input.Username).Success)
            {
                throw new UserFriendlyException("请输入字母或中文开头，只包含字母中文数字下划线，长度为2~12字符的用户名");
            }
            if (!new Regex(@"^[0-9a-zA-Z]\w{5,17}$").Match(input.Password).Success)
            {
                throw new UserFriendlyException("以字母开头，长度在6~18之间，只能包含字母、数字和下划线的密码");
            }
            if (!string.IsNullOrWhiteSpace(input.Phone) && !new Regex(@"^1[345789]\d{9}$").Match(input.Phone).Success)
            {
                throw new UserFriendlyException("手机号错误");
            }
            if (_userRepository.Count(x => x.Username == input.Username) > 0)
            {
                throw new UserFriendlyException("用户名已存在");
            }
            if (!string.IsNullOrWhiteSpace(input.Phone) && _userRepository.Count(x => x.Phone == input.Phone) > 0)
            {
                throw new UserFriendlyException("电话已存在");
            }
            return await _userRepository.InsertAndGetIdAsync(ObjectMapper.Map<User>(input));
        }

        public async Task<List<UserOutput>> GetUser()
        {
            var list = await _userRepository.GetAll().OrderByDescending(x => x.Id).ToListAsync();
            return ObjectMapper.Map<List<UserOutput>>(list);
        }

        public async Task<PagedResultDto<UserOutput>> GetAllUserList(GetAllUserListInput input)
        {
            if (input.MaxResultCount > 30) { input.MaxResultCount = 30; }

            var data = _userRepository.GetAll();
            if (input.Locked.HasValue)
            {
                data = data.Where(x => x.Locked == input.Locked.Value);
            }
            var count = await data.CountAsync();
            var list = await data.OrderByDescending(x => x.CreationTime).Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();

            var output = ObjectMapper.Map<List<UserOutput>>(list);

            return new PagedResultDto<UserOutput>
            {
                Items = output,
                TotalCount = count
            };
        }

        public async Task DeletaUser(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task ResetPassword(int id)
        {
            var user = await _userRepository.GetAsync(id);
            user.Password = "123456";
        }
    }
}
