using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Entities
{
    public class User : Entity, IHasCreationTime
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public string Phone { get; set; }


        public string Realname { get; set; }

        public string RegionCode { get; set; } // 所属行政区
        public string RegionName { get; set; }
        public string RegionIndex { get; set; }


        [Required]
        public bool Locked { get; set; } = true;

        [Required]
        public DateTime CreationTime { get; set; } = DateTime.Now;


    }

}
