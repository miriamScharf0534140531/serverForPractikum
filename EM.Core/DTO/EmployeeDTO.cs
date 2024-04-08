using EM.Core.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Core.DTO
{
    public class EmployeeDTO
    {
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
        [RegularExpression("^[0-9]*$", ErrorMessage = "The TZ must contain only digits.")]
        public string? TZ { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        public bool Male { get; set; }
        [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.[a-zA-Z]{2,}$")]
        public string Email { get; set; }
        [Required]
        public List<EmployeeRoleDTO> Roles { get; set; }
    }
}
