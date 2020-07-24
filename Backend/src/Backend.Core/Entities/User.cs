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
        [Required]
        public Department Department { get; set; }

        public string Phone { get; set; }


        public string Realname { get; set; }

        public string RegionCode { get; set; } // 所属行政区
        public string RegionName { get; set; }
        public string RegionIndex { get; set; }

        //public Role Role { get; set; } = Role.AllRegion | Role.Write | Role.Read;

        [Required]
        public bool Locked { get; set; } = true;



        [Required]
        public DateTime CreationTime { get; set; } = DateTime.Now;


    }

    public enum Role
    {
        No = 0,
        AllRegion = 1,
        Write = 2,
        Read = 4
    }
    public enum Department
    {
        KanTanYeWu = 0,
        KanTanBan = 1,
        FaJueXianChangeFuZeRen = 2,
        WenBaoChu = 3,
        Other = 4
    }
}
