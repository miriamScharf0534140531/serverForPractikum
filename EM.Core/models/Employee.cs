using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EM.Core.models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string? LastName { get; set; }
        [Required]
        [MinLength(9)]
        [MaxLength(9)]
        public string? TZ { get; set; }
        public DateTime StartDate { get; set; }
        ///
        public bool Active { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Male { get; set; }
        public List<EmployeeRole> Roles { get; set; }
    
    }
}
