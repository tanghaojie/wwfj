using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Backend.Dtos;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class RequestCompanyAppService : BackendAppServiceBase, IRequestCompanyAppService
    {
        private readonly IRepository<RequestCompany> _rcRepository;

        public RequestCompanyAppService(IRepository<RequestCompany> rcRepository)
        {
            _rcRepository = rcRepository;
        }

        public async Task<List<RequestCompanyOutput>> GetAllList()
        {
            var list = await _rcRepository.GetAll().OrderByDescending(x => x.Id).ToListAsync();
            return ObjectMapper.Map<List<RequestCompanyOutput>>(list);
        }

        public async Task<int> Add(AddRequestCompanyInput input)
        {
            var e = ObjectMapper.Map<RequestCompany>(input);
            return await _rcRepository.InsertOrUpdateAndGetIdAsync(e);
        }
    }
}
