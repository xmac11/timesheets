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

            builder.Entity<ProjectDepartment>()
                .HasKey(pd => new { pd.ProjectId, pd.DepartmentId });
        }
    }
}
