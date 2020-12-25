using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Configuration.Dtos
{
    public class ChangeUiThemeInput
    {
        [Required]
        public string Theme { get; set; }
    }
}
