using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.Models;
using mijnZorgRooster.DAL.Entities;

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
        public DbSet<Dienst> Diensten { get; set; }
        public DbSet<Rooster> Roosters { get; set; }
        public DbSet<MedewerkerRol> MedewerkersRollen { get; set; }
		public DbSet<RoosterDienstProfiel> RoosterDienstProfielen { get; set; }
		public DbSet<MedewerkerDienst> MedewerkerDiensten { get; set; }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Certificaat>().ToTable("Certificaat")
                .HasOne(c => c.Medewerker)
                .WithMany(m => m.Certificaten)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Contract>().ToTable("Contract");
            modelBuilder.Entity<Medewerker>().ToTable("Medewerker");
            modelBuilder.Entity<Rol>().ToTable("Rol");
            modelBuilder.Entity<DienstProfiel>().ToTable("DienstProfiel");
            modelBuilder.Entity<Dienst>().ToTable("Dienst")
                .HasOne(d => d.Rooster)
                .WithMany(r => r.Diensten)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Rooster>().ToTable("Rooster");
			modelBuilder.Entity<RoosterDienstProfiel>().HasKey(e => new { e.RoosterId, e.DienstProfielId });;
			modelBuilder.Entity<MedewerkerDienst>().HasKey(e => new { e.MedewerkerId, e.DienstId });
			modelBuilder.Entity<MedewerkerRol>().HasKey(e => new { e.MedewerkerId, e.RolId });

        }
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is ITrackable trackable)
                {
                    var now = DateTime.UtcNow;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.CurrentValues["WijzigingsDatum"] = now;
                            break;

                        case EntityState.Added:
                            entry.CurrentValues["AanmaakDatum"] = now;
                            entry.CurrentValues["WijzigingsDatum"] = now;
                            break;
                    }
                }
            }
        }
    }
}