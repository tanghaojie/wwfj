using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Backend.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public interface IUserAppService : IApplicationService
    {
        Task<bool> ChangeUserLock(ChangeUserLockInput input);

        Task<int> AddUser(AddUserInput input);

        Task<List<UserOutput>> GetUser();

        Task<PagedResultDto<UserOutput>> GetAllUserList(GetAllUserListInput input);

        Task<bool> DeleteUser(DeleteUserInput input);

        Task<bool> ResetPassword(ResetPasswordInput input);
    }
}
