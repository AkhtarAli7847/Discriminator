using DiscriminatorExample.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DiscriminatorExample.Data
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Staff> Staff { get; set; }
        private readonly IConfiguration _configuration;

        public SchoolDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>()
                .HasDiscriminator<string>("StaffType")
                .HasValue<Teacher>("Teacher")
                .HasValue<Administrator>("Administrator");
        }
    }
}
