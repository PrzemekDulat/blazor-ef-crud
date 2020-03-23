using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEFcrud.Data
{
    public class EmployeeInfo
    {

        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
