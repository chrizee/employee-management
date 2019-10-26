using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        private const int SeedSize = 4;
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {            
        }

        public DbSet<Employee> Employees { get; set; }

        //this method is called when creating the migration for the project, we can register seeders here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //this calls an extension method declared in another class to see the database. This reduces the code we have here in this and makes it neat
            modelBuilder.Seed(SeedSize);

            //enforce ON DELETE RESTRICT on all foreign key constraints
            foreach(var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
