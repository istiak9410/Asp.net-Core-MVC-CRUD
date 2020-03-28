using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ProjectMvcAspCore.Models
{
    public class EmployeeInfo
    { 
        
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string Designation { get; set; }


    }
}
