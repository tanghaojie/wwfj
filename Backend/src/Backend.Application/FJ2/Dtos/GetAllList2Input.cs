using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Dtos2
{
    public class GetAllList2Input : PagedResultRequestDto
    {
        public bool AllFinish { get; set; } = false;
        public string RegionName { get; set; }
        public string Search { get; set; }
    }
}
