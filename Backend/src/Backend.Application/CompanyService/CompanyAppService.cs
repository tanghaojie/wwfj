using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Backend.Entities;
using Abp.Application.Services;
using Backend.CompanyService.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.UI;

namespace Backend.CompanyService
{
    public class CompanyAppService : AsyncCrudAppService<Company, CompanyDto, int, GetAllInput>, ICompanyAppService
    {
        public CompanyAppService(IRepository<Company> companyRepository) : base(companyRepository)
        {

        }

        public override async Task<CompanyDto> CreateAsync(CompanyDto input)
        {
            CheckCreatePermission();

            if ((await Repository.GetAll().Where(x => x.Name == input.Name).CountAsync()) > 0)
            {
                throw new UserFriendlyException(200, $"{input.Name }：企业名称重复");
            }
            return await base.CreateAsync(input);
        }


        protected override IQueryable<Company> CreateFilteredQuery(GetAllInput input)
        {
            if (string.IsNullOrWhiteSpace(input.NameFilter))
            {
                return base.CreateFilteredQuery(input);
            }
            return base.CreateFilteredQuery(input).Where(x => x.Name.Contains(input.NameFilter));
        }
    }
}
