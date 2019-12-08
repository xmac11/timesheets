using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Timesheets.Models;

namespace Timesheets.Data
{
    public class ApplicationDbContext : IdentityDbContext<MyUser>
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimesheetEntry> TimesheetEntries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Required for setting Identity
                                                // Below are required, to setup the ProductCategory weak entity
                                                // which connects one or more products to one or more categories
            modelBuilder.Entity<DepartmentProject>()
                 .HasKey(t => new { t.DepartmentId, t.ProjectId });
            modelBuilder.Entity<DepartmentProject>()
                 .HasOne(pt => pt.Department)
                 .WithMany(p => p.Projects)
                 .HasForeignKey(pt => pt.DepartmentId);
 				   //.OnDelete(DeleteBehavior.Cascade);   // Setup CASCADE ON DELETE
            modelBuilder.Entity<DepartmentProject>()
                 .HasOne(pt => pt.Project)
                 .WithMany(t => t.Departments)
                 .HasForeignKey(pt => pt.ProjectId);

            // TODO: Refactor this in order when saving user and including a Department.
            //       AspNetUsers.DepartmentId should get the correct value!
            modelBuilder.Entity<Department>()
                .HasOne(d => d.DepartmentHead)
                .WithOne(u => u.Department)
                .HasForeignKey<Department>(ad => ad.DepartmentHeadId);

            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole() { Name="Admin",NormalizedName="ADMIN" },
                    new IdentityRole() { Name="Employee", NormalizedName="EMPLOYEE" },
                    new IdentityRole() { Name="Manager", NormalizedName="MANAGER"}
                );

           
        }
    }
}

