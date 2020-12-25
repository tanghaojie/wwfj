using Abp.Application.Services;
using Backend.OptionService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.OptionService
{
    public interface IOptionAppService : IApplicationService, IAsyncCrudAppService<OptionDto, int>
    {
        Task<OptionDto> GetByType(string type);
    }
}
