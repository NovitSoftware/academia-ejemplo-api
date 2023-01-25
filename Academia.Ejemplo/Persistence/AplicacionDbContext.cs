using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Academia.Ejemplo.Persistence
{
    public partial class AplicacionDbContext : DbContext
    {
        public AplicacionDbContext()
        {
        }

        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aldeano> Aldeano { get; set; } = null!;
        public virtual DbSet<Edificio> Edificio { get; set; } = null!;
        public virtual DbSet<Jugador> Jugador { get; set; } = null!;
        public virtual DbSet<Militar> Militar { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aldeano>(entity =>
            {
                entity.HasKey(e => e.IdAldeano);

                entity.Property(e => e.Categoria)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Edificio>(entity =>
            {
                entity.HasKey(e => e.IdEdificio);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.HasKey(e => e.IdJugador);

                entity.Property(e => e.Civilizacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasMany(d => d.IdAldeano)
                    .WithMany(p => p.IdJugador)
                    .UsingEntity<Dictionary<string, object>>(
                        "AldeanoJugador",
                        l => l.HasOne<Aldeano>().WithMany().HasForeignKey("IdAldeano").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AldeanoJugador_Aldeano"),
                        r => r.HasOne<Jugador>().WithMany().HasForeignKey("IdJugador").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AldeanoJugador_Jugador"),
                        j =>
                        {
                            j.HasKey("IdJugador", "IdAldeano");

                            j.ToTable("AldeanoJugador");
                        });

                entity.HasMany(d => d.IdEdificio)
                    .WithMany(p => p.IdJugador)
                    .UsingEntity<Dictionary<string, object>>(
                        "EdificioJugador",
                        l => l.HasOne<Edificio>().WithMany().HasForeignKey("IdEdificio").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EdificioJugador_Edificio"),
                        r => r.HasOne<Jugador>().WithMany().HasForeignKey("IdJugador").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EdificioJugador_Jugador"),
                        j =>
                        {
                            j.HasKey("IdJugador", "IdEdificio");

                            j.ToTable("EdificioJugador");
                        });

                entity.HasMany(d => d.IdMilitar)
                    .WithMany(p => p.IdJugador)
                    .UsingEntity<Dictionary<string, object>>(
                        "MilitarJugador",
                        l => l.HasOne<Militar>().WithMany().HasForeignKey("IdMilitar").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MilitarJugador_Militar"),
                        r => r.HasOne<Jugador>().WithMany().HasForeignKey("IdJugador").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MilitarJugador_Jugador"),
                        j =>
                        {
                            j.HasKey("IdJugador", "IdMilitar");

                            j.ToTable("MilitarJugador");

                            j.IndexerProperty<int>("IdMilitar").HasColumnName("IdMIlitar");
                        });
            });

            modelBuilder.Entity<Militar>(entity =>
            {
                entity.HasKey(e => e.IdMilitar);

                entity.Property(e => e.Categoria)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
