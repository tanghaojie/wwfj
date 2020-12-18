using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Dtos
{
    public class ChangeUserLockInput : EntityDto
    {
        [Required]
        public bool Locked { get; set; }
    }
}
