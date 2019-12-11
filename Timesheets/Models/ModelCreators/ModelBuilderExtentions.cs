﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data;

namespace Timesheets.Models.ModelCreators
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // seed Departments
            modelBuilder.Entity<Department>().HasData(
                    new Department
                    {
                        Id = 1,
                        Name = "IT"
                    },

                    new Department
                    {
                        Id = 2,
                        Name = "R&D"
                    },

                    new Department
                    {
                        Id = 3,
                        Name = "Human Resources"
                    },

                    new Department
                    {
                        Id = 4,
                        Name = "Accounting"
                    }
                );

            // seed Projects
            modelBuilder.Entity<Project>().HasData(
                    new Project
                    {
                        Id = 1,
                        Name = "App Develpment",
                        OwnerDeptId = 1
                    }
                ); 
        }
    }
}
