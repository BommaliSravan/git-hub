using EmployeeApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApplication.DataAccess
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.Salary).HasColumnName("Salary");

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
