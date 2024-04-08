using EM.Core.interfaces;
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
        public DateOnly StartDate { get; set; }
        public bool Active { get; set; }
        public DateOnly BirthDate { get; set; }
        public bool Male { get; set; }
        [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.[a-zA-Z]{2,}$")]
        public string Email { get; set; }
        public List<EmployeeRole> Roles { get; set; }
        //public class ValidateBirthDateAttribute : ValidationAttribute
        //{
        //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //    {
        //        DateOnly birthDate = (DateOnly)value;
        //        if (birthDate.Year > DateTime.Now.AddYears(-16).Year)
        //            return new ValidationResult(ErrorMessage);
        //        return ValidationResult.Success;
        //    }
        //}



    }

}

