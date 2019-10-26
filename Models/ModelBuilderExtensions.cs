using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder, int seedSize)
        {
            Employee[] seedEmployee = new Employee[seedSize];
            for (int i = 0; i < seedSize; i++)
            {
                seedEmployee[i] = new Employee
                {
                    Id = i + 1,
                    Name = "chris",
                    Department = Dept.IT,
                    Email = "okoro" + (i + 1) + "@gmail.com"
                };
            }

            modelBuilder.Entity<Employee>().HasData(seedEmployee);
        }
    }
}
