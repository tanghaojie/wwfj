using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Backend.Entities;
using Backend.OptionService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Backend.OptionService
{
    public class OptionAppService : AsyncCrudAppService<Option, OptionDto, int>, IOptionAppService
    {
        public OptionAppService(IRepository<Option> optionRepository) : base(optionRepository)
        {

        }

        public async Task<OptionDto> GetByType(string type)
        {
            CheckGetPermission();

            var entity = await Repository.FirstOrDefaultAsync(x => x.OptionType == type);
            return MapToEntityDto(entity);
        }

        //protected override IQueryable<Company> CreateFilteredQuery(GetAllInput input)
        //{
        //    return base.CreateFilteredQuery(input);
        //}
    }
}
