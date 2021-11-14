using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Models
{
    public class Employee
    {
        [Key]
        public long Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string title { set; get; }
        [Required]
        public string EmpNumber { set; get; }

        public Nullable< long> DeptId { set; get; }


    }
}
