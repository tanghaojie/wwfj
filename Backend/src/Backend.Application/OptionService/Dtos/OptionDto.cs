using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.OptionService.Dtos
{
    public class OptionDto : EntityDto
    {
        [Required]
        public string OptionType { get; set; }
        public string[] Values { get; set; }
    }
}
