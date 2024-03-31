﻿using EM.Core.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EM.Core
{
    public class EMContext : DbContext
    {

        public EMContext(DbContextOptions<EMContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>()
            //    .HasOne(e => e.EmployeeCharacteristics)
            //    .WithOne(e => e.Employee)
            //    .HasForeignKey<EmployeeCharacteristics>(e => e.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Roles)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId)
                .HasPrincipalKey(e => e.Id);

            //modelBuilder.Entity<EmployeeRole>()
            //           .HasOne(er => er.Role)
            //           .WithMany()
            //           .HasForeignKey(er => er.RoleId);
        }
        public DbSet<Employee> Employees { get; set; }
        //public DbSet<EmployeeCharacteristics> EmployeeCharcteristics { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}