using Microsoft.EntityFrameworkCore;
using FishApp.API.Models;

namespace FishApp.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pez> Peces { get; set; }
        public DbSet<Estanque> Estanques { get; set; }
        public DbSet<PezEstanque> PecesEstanques { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pez>(entity =>
            {
                entity.ToTable("Pez");
                entity.Property(p => p.FechaRegistro).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Estanque>(entity =>
            {
                entity.ToTable("Estanque");
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<PezEstanque>(entity =>
            {
                entity.ToTable("PezEstanque");

                entity.HasOne(pe => pe.Pez)
                    .WithMany(p => p.PecesEstanques)
                    .HasForeignKey(pe => pe.IdPez)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(pe => pe.Estanque)
                    .WithMany(e => e.PecesEstanques)
                    .HasForeignKey(pe => pe.IdEstanque)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
