using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Timesheets.Models;

namespace Timesheets.Data
{
    public class ApplicationDbContext : IdentityDbContext<MyUser> //use the custom User
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
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<DepartmentProject>()
                 .HasKey(t => new { t.DepartmentId, t.ProjectId });
            modelBuilder.Entity<DepartmentProject>()
                 .HasOne(dp => dp.Department)
                 .WithMany(d => d.Projects)
                 .HasForeignKey(dp => dp.DepartmentId);
 				   //.OnDelete(DeleteBehavior.Cascade);   // Setup CASCADE ON DELETE
            modelBuilder.Entity<DepartmentProject>()
                 .HasOne(pt => pt.Project)
                 .WithMany(t => t.Departments)
                 .HasForeignKey(pt => pt.ProjectId);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.DepartmentHead)
                .WithOne(u => u.Department)
                .HasForeignKey<Department>(ad => ad.DepartmentHeadId);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name="Admin", NormalizedName="ADMIN"},
                new IdentityRole() { Name="Employee", NormalizedName="EMPLOYEE"},
                new IdentityRole() { Name="Manager", NormalizedName="MANAGER"}
                );
        }
    
    }
}
