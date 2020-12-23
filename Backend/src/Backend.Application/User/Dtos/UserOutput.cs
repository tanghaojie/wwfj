using Abp.Application.Services.Dto;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend
{
    public class UserOutput : EntityDto
    {
        public string Username { get; set; }

        public string Phone { get; set; }


        public string Realname { get; set; }

        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string RegionIndex { get; set; }

        public bool Locked { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}
