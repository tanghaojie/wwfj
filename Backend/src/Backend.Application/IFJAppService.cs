using Abp.Application.Services.Dto;
using Backend.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public interface IFJAppService
    {
        Task<int> Commit(NewInput input);

        int X();


        Task<FJOutput> Get(int id);

        Task<PagedResultDto<FJOutput>> GetAllList(GetAllInput input);



        Task<PagedResultDto<FJOutput>> GetPendingList(PagedResultRequestDto input);
        Task<PagedResultDto<FJOutput>> GetFinishedList(PagedResultRequestDto input);
    }
}
