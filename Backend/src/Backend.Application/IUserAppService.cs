using Abp.Application.Services;
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
    }
}
