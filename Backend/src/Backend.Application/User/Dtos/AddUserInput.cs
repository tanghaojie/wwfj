using Backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend
{
    public class AddUserInput
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

    }
}
