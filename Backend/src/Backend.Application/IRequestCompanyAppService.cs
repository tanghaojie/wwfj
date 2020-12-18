using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Backend.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public interface IRequestCompanyAppService : IApplicationService
    {
        Task<List<RequestCompanyOutput>> GetAllList();

        Task<int> Add(AddRequestCompanyInput input);
    }
}
