using EM.Core.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EM.Core.DTO
{
    public class EmployeeRoleDTO
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public bool Managerial { get; set; }
        public DateOnly JobStartDate { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public Employee? Employee { get; set; }
    }
}
