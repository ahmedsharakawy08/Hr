using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Models
{
    public class Department
    {
        [Key]
        public long Id { set; get; }
        [Required]
        public string Name { set; get; }
     

    }
}
