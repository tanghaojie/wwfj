using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Web.Host.Dtos
{
    public class AuthenticateOutput
    {
        public string Username { get; set; }

        public string Phone { get; set; }

        public string Realname { get; set; }

        public string AccessToken { get; set; }

        public int ExpireInSeconds { get; set; }

        public int UserId { get; set; }

        //public int? Role { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string RegionIndex { get; set; }

    }
}
