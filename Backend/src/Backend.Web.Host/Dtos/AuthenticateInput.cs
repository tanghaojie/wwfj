using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Web.Host.Dtos
{
    public class AuthenticateInput
    {
        [Required]
        public string UsernameOrPhone { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
