using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.DAL
{
    public class ZorginstellingDbContext : IdentityDbContext
    {
        public ZorginstellingDbContext(DbContextOptions<ZorginstellingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Certificaat> Certificaten { get; set; }
        public DbSet<Contract> Contracten { get; set; }
        public DbSet<Medewerker> Medewerkers { get; set; }
        public DbSet<Rol> Rollen { get; set; }
	    	public DbSet<DienstProfiel> DienstProfielen { get; set; }
    		public DbSet<Rooster> Roosters { get; set; }
    		public DbSet<Dienst> Diensten { get; set; }
        public DbSet<MedewerkerRol> MedewerkersRollen { get; set; }

	    	protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Certificaat>().ToTable("Certificaat");
            modelBuilder.Entity<Contract>().ToTable("Contract");
            modelBuilder.Entity<Medewerker>().ToTable("Medewerker");
            modelBuilder.Entity<Rol>().ToTable("Rol");
	      		modelBuilder.Entity<DienstProfiel>().ToTable("DienstProfiel");
	      		modelBuilder.Entity<Dienst>().ToTable("Dienst");
      			modelBuilder.Entity<Rooster>().ToTable("Rooster");

            modelBuilder.Entity<MedewerkerRol>().HasKey(e => new { e.MedewerkerId, e.RolId });
        }
    }
}