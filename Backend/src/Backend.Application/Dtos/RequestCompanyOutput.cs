using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Dtos
{
    public class RequestCompanyOutput : EntityDto
    {
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
