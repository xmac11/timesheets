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
        }
    }
}
