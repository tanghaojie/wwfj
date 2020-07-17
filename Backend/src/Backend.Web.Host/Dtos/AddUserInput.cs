using Backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Web.Host.Dtos
{
    public class AddUserInput
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Department Department { get; set; }

        public string Phone { get; set; }

        public string Realname { get; set; }

        public string RegionCode { get; set; } // 所属行政区

        public string RegionName { get; set; }
        public string RegionIndex { get; set; }

        //public Role Role { get; set; } = Role.AllRegion | Role.Write | Role.Read;
    }
}
