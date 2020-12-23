using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Entities
{
    public class Company : Entity, IHasCreationTime
    {
        [Required]
        public string Name { get; set; }

        public string RegisteredLocation { get; set; }

        public string UnifiedSocialCreditCode { get; set; }

        public string ResponsiblePerson { get; set; }

        public string ContactInfo { get; set; }

        [Required]
        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}
