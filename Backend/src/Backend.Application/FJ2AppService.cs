﻿using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Backend.Dtos;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Backend.JTAuthenticate;
using Backend.Dtos2;

namespace Backend
{

    public class FJ2AppService : BackendAppServiceBase, IFJ2AppService
    {
        private readonly IRepository<FJ2> _fj2Repository;
        //private readonly IRepository<User> _userRepository;

        public FJ2AppService(IRepository<FJ2> fj2Repository, IRepository<User> userRepository)
        {
            _fj2Repository = fj2Repository;
            //_userRepository = userRepository;
        }

        public async Task<int> Commit(FJ2NewInput input)
        {
            var e = ObjectMapper.Map<FJ2>(input);
            return await _fj2Repository.InsertOrUpdateAndGetIdAsync(e);
        }

        public async Task<FJ2Output> Get(int id)
        {
            var en = await _fj2Repository.GetAsync(id);
            return ObjectMapper.Map<FJ2Output>(en);
        }

        public virtual async Task<PagedResultDto<FJ2Output>> GetAllList(GetAllList2Input input)
        {
            if (input.MaxResultCount > 30) { input.MaxResultCount = 30; }

            var data = _fj2Repository.GetAll().Where(x => x.AllFinish == input.AllFinish);
            if (!string.IsNullOrWhiteSpace(input.RegionName))
            {
                data = data.Where(q => q.RegionName == input.RegionName);
            }
            if (!string.IsNullOrWhiteSpace(input.Search))
            {
                data = data.Where(x => x.ProjName.Contains(input.Search) || x.ProjCompany.Contains(input.Search));
            }

            var count = await data.CountAsync();
            var list = await data.OrderByDescending(x => x.CreationTime).Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();

            var output = ObjectMapper.Map<List<FJ2Output>>(list);

            return new PagedResultDto<FJ2Output>
            {
                Items = output,
                TotalCount = count
            };
        }

    }
}