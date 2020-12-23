using Abp.Application.Services;
using Backend.CompanyService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.CompanyService
{
    public interface ICompanyAppService : IApplicationService, IAsyncCrudAppService<CompanyDto, int, GetAllInput>
    {
       
    }
}
