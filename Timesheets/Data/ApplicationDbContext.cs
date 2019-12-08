using System;
using System.Collections.Generic;
using System.Text;
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
                 .HasForeignKey(dp => dp.ProjectId);
 				   .OnDelete(DeleteBehavior.Cascade);   // Setup CASCADE ON DELETE
            modelBuilder.Entity<ProductCategory>()
                 .HasOne(pt => pt.Category)
                 .WithMany(t => t.Products)
                 .HasForeignKey(pt => pt.CategoryId);
        }
    
    }
}
