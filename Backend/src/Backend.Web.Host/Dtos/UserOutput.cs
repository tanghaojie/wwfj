using Abp.Application.Services.Dto;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Web.Host.Dtos
{
    public class UserOutput : EntityDto
    {
        public string Username { get; set; }

        public Department Department { get; set; }

        public string DepartmentStr {
            get {
                switch (Department)
                {
                    case Department.FaJueXianChangeFuZeRen:
                        return "发掘现场负责人";
                    case Department.KanTanBan:
                        return "勘探办";
                    case Department.KanTanYeWu:
                        return "勘探业务部门";
                    case Department.Other:
                        return "其他";
                    case Department.WenBaoChu:
                        return "文保处";
                    default:
                        return "获取部门信息错误";
                }
            }
        }

        public string Phone { get; set; }


        public string Realname { get; set; }

        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string RegionIndex { get; set; }

        public bool Locked { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}
