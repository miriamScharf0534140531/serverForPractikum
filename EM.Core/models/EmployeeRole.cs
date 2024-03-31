using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EM.Core.models
{
    public class EmployeeRole
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        //public Role? Role { get; set; }
        public bool Managerial { get; set; }
        public DateTime JobStartDate { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public Employee? Employee { get; set; }
    }
}