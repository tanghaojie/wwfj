using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Entities
{
    public class RequestCompany : Entity, IHasCreationTime
    {
        public string Name { get; set; }
        [Required]
        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}
