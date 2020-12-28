using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Entities
{
    public class Option : AuditedEntity
    {
        [Required]
        public string OptionType { get; set; }
        public string[] Values { get; set; }
    }
} 
