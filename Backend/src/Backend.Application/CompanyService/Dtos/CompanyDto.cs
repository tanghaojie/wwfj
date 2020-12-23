using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.CompanyService.Dtos
{
    public class CompanyDto : EntityDto
    {
        public string Name { get; set; }

        public string RegisteredLocation { get; set; }

        public string UnifiedSocialCreditCode { get; set; }

        public string ResponsiblePerson { get; set; }

        public string ContactInfo { get; set; }

        public DateTime CreationTime { get; set; } 
    }
}
