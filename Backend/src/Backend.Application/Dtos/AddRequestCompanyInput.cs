using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Dtos
{
    public class AddRequestCompanyInput
    {
        [Required]
        public string Name { get; set; }
    }
}
