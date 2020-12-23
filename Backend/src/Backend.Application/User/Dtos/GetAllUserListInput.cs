using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend
{
    public class GetAllUserListInput : PagedResultRequestDto
    {
        public bool? Locked { get; set; } = null;
    }
}
