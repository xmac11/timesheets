using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Timesheets.Models;

namespace Timesheets.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Department> Deparments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectDepartment> ProjectsDepartments { get; set; }
        public DbSet<User> Employees { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // many-to-many (Deparment - Related Projects)
            builder.Entity<ProjectDepartment>()
                .HasKey(pd => new { pd.ProjectId, pd.DepartmentId });

            builder.Entity<ProjectDepartment>()
                .HasOne(pd => pd.Project)
                .WithMany(p => p.RelatedDeparments)
                .HasForeignKey(pd => pd.ProjectId);

            builder.Entity<ProjectDepartment>()
                .HasOne(pd => pd.Department)
                .WithMany(d => d.RelatedProjects)
                .HasForeignKey(pd => pd.DepartmentId);

            // one-to-many (Owned Projects - Deparment)
            builder.Entity<Department>()
                .HasMany(d => d.OwnedProjects)
                .WithOne(p => p.OwnerDeparment)
                .HasForeignKey(p => p.OwnerDeparmentId)
                .OnDelete(DeleteBehavior.Restrict); // https://stackoverflow.com/questions/41711772/entity-framework-core-cascade-delete-one-to-many-relationship

            // one-to-many (Department-User)
            builder.Entity<Department>()
                .HasMany(d => d.Users)
                .WithOne(u => u.Department)
                .HasForeignKey(u => u.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // one-to-many (Timesheet-User)
            builder.Entity<Timesheet>()
                .HasMany(t => t.Users)
                .WithOne(u => u.Timesheet)
                .HasForeignKey(u => u.TimesheetId)
                .OnDelete(DeleteBehavior.Restrict);

            // one-to-many (Project - Timesheet)
            builder.Entity<Project>()
                .HasMany(p => p.Timesheets)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
