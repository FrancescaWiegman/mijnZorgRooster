using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Data
{
    public class ZorginstellingContext :DbContext
    {
        public ZorginstellingContext(DbContextOptions<ZorginstellingContext> options) : base(options)
        {
        }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Medewerker> Medewerkers { get; set; }
        public DbSet<Roll> Rolls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Certificate>().ToTable("Certificate");
            modelBuilder.Entity<Contract>().ToTable("Contract");
            modelBuilder.Entity<Medewerker>().ToTable("Medewerker");
            modelBuilder.Entity<Roll>().ToTable("Roll");

        }
    }
}

