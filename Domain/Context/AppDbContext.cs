using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet for the existing table
        public DbSet<PersonDetail> Person_Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional: Fluent API configuration for the table
            modelBuilder.Entity<PersonDetail>()
                .ToTable("Person_Details") // Map to the correct SQL table name
                .HasKey(p => p.Id); // Set the primary key if not auto-configured

            base.OnModelCreating(modelBuilder);
        }
    }
}
