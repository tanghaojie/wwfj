using Abp.Application.Services.Dto;
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

namespace Backend
{

    public class FJAppService : BackendAppServiceBase, IFJAppService
    {
        private readonly IRepository<FJ> _fjRepository;
        private readonly IRepository<User> _userRepository;

        public FJAppService(IRepository<FJ> fjRepository, IRepository<User> userRepository)
        {
            _fjRepository = fjRepository;
            _userRepository = userRepository;
        }

        public async Task<int> Commit(NewInput input)
        {
            var e = ObjectMapper.Map<FJ>(input);
            return await _fjRepository.InsertOrUpdateAndGetIdAsync(e);
        }

        public virtual int X()
        {
            return 1;
        }


        public async Task<FJOutput> Get(int id)
        {
            var uid = AbpSession.UserId;
            var en = await _fjRepository.GetAsync(id);
            return ObjectMapper.Map<FJOutput>(en);
        }

        [JTAuthenticateAttribute]
        public virtual async Task<PagedResultDto<FJOutput>> GetAllList(GetAllInput input)
        {
            var data = _fjRepository.GetAll().Where(
                x =>
             input.States.Contains(x.State)
                );

            var count = await data.CountAsync();
            var list = await data.OrderByDescending(x => x.CreationTime).Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();

            var output = ObjectMapper.Map<List<FJOutput>>(list);

            return new PagedResultDto<FJOutput>
            {
                Items = output,
                TotalCount = count
            };
        }

        [JTAuthenticateAttribute]
        public virtual async Task<PagedResultDto<FJOutput>> GetPendingList(PagedResultRequestDto input)
        {
            var user = await _userRepository.GetAsync((int)AbpSession.UserId.Value);

            var data = _fjRepository.GetAll().Where(
                x =>
            x.State == State.New ||
            x.State == State.Protocoled ||
            x.State == State.Exploring ||
            x.State == State.Diging
                );

            if (user.Department == Department.KanTanYeWu)
            {
                data = data.Where(x => x.RegionCode == user.RegionCode);
            }

            var count = await data.CountAsync();
            var list = await data.OrderByDescending(x => x.CreationTime).Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();

            var output = ObjectMapper.Map<List<FJOutput>>(list);

            return new PagedResultDto<FJOutput>
            {
                Items = output,
                TotalCount = count
            };
        }
        [JTAuthenticateAttribute]
        public virtual async Task<PagedResultDto<FJOutput>> GetFinishedList(PagedResultRequestDto input)
        {
            var user = await _userRepository.GetAsync((int)AbpSession.UserId.Value);

            var data = _fjRepository.GetAll().Where(
                x =>
            x.State == State.UnProtocoled ||
            x.State == State.UnDig ||
            x.State == State.Diged
                );

            if (user.Department == Department.KanTanYeWu)
            {
                data = data.Where(x => x.RegionCode == user.RegionCode);
            }

            var count = await data.CountAsync();
            var list = await data.OrderByDescending(x => x.CreationTime).Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();

            var output = ObjectMapper.Map<List<FJOutput>>(list);

            return new PagedResultDto<FJOutput>
            {
                Items = output,
                TotalCount = count
            };
        }
    }
}
