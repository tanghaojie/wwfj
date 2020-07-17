using Abp.Application.Services.Dto;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Dtos
{
    public class GetAllInput : PagedResultRequestDto
    {
        public State[] States { get; set; }
    }
}
