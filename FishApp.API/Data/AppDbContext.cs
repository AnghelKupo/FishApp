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
        public DbSet<Especie> Especies { get; set; }
        public DbSet<ConfiguracionReproduccion> ConfiguracionesReproduccion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pez>(entity =>
            {
                entity.ToTable("Pez");
                entity.HasIndex(p => p.Codigo).IsUnique();
                entity.Property(p => p.FechaRegistro).HasDefaultValueSql("GETDATE()");

                entity.HasOne(p => p.Especie)
                    .WithMany(e => e.Peces)
                    .HasForeignKey(p => p.EspecieId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Estanque>(entity =>
            {
                entity.ToTable("Estanque");
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<PezEstanque>(entity =>
            {
                entity.ToTable("PezEstanque");
                entity.Property(pe => pe.FechaEntrada).HasDefaultValueSql("GETDATE()");

                entity.HasOne(pe => pe.Pez)
                    .WithMany(p => p.PecesEstanques)
                    .HasForeignKey(pe => pe.IdPez)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(pe => pe.Estanque)
                    .WithMany(e => e.PecesEstanques)
                    .HasForeignKey(pe => pe.IdEstanque)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Especie>(entity =>
            {
                entity.ToTable("Especie");
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(200);
            });

            // ConfiguracionReproduccion: máximo un registro por combinación EspecieId + Sexo
            modelBuilder.Entity<ConfiguracionReproduccion>(entity =>
            {
                entity.ToTable("ConfiguracionReproduccion");
                entity.HasIndex(c => new { c.EspecieId, c.Sexo }).IsUnique();

                entity.HasOne(c => c.Especie)
                    .WithMany(e => e.ConfiguracionesReproduccion)
                    .HasForeignKey(c => c.EspecieId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
