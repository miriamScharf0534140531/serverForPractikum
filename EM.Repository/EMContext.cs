using EM.Core.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Data
{
    public class EMContext:DbContext
    {
        public EMContext(DbContextOptions<EMContext> options) : base(options)
        {
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                    .HaveConversion<DateOnlyConverter>()
                    .HaveColumnType("date");
        }
        public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
        {
            public DateOnlyConverter() : base(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d))
            { }
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>()
        //        .HasMany(e => e.Roles)
        //        .WithOne(e => e.Employee)
        //        .HasForeignKey(e => e.EmployeeId)
        //        .HasPrincipalKey(e => e.Id);
        //}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
    
}
}
