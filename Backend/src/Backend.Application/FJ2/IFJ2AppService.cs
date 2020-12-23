using Abp.Application.Services.Dto;
using Backend.Dtos;
using Backend.Dtos2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public interface IFJ2AppService
    {
        Task<int> Commit(FJ2NewInput input);


        Task<FJ2Output> Get(int id);

        Task<PagedResultDto<FJ2Output>> GetAllList(GetAllList2Input input);


    }
}
