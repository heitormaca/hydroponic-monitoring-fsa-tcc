using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hydroponics.Models
{
    public partial class hydroponicsContext : DbContext
    {
        public hydroponicsContext()
        {
        }

        public hydroponicsContext(DbContextOptions<hydroponicsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BancadaFisica> BancadaFisica { get; set; }
        public virtual DbSet<BancadaVirtual> BancadaVirtual { get; set; }
        public virtual DbSet<Estufa> Estufa { get; set; }
        public virtual DbSet<Medicao> Medicao { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=den1.mssql7.gear.host;Database=hydroponics;uid=hydroponics;Password=C6}Ew5S!IONna3;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BancadaFisica>(entity =>
            {
                entity.HasKey(e => e.IdBancadaFisica)
                    .HasName("PK__BancadaF__302F22F96ABE9196");

                entity.Property(e => e.DataInicio).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Localizacao).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.HasOne(d => d.IdEstufaNavigation)
                    .WithMany(p => p.BancadaFisica)
                    .HasForeignKey(d => d.IdEstufa)
                    .HasConstraintName("FK__BancadaFi__idEst__7A672E12");
            });

            modelBuilder.Entity<BancadaVirtual>(entity =>
            {
                entity.HasKey(e => e.IdBancadaVirtual)
                    .HasName("PK__BancadaV__53E8FBF5C8808B45");

                entity.Property(e => e.DataInicio).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dispositivo).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Semeio).IsUnicode(false);

                entity.Property(e => e.StatusBancada).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdBancadaFisicaNavigation)
                    .WithMany(p => p.BancadaVirtual)
                    .HasForeignKey(d => d.IdBancadaFisica)
                    .HasConstraintName("FK__BancadaVi__idBan__7F2BE32F");
            });

            modelBuilder.Entity<Estufa>(entity =>
            {
                entity.HasKey(e => e.IdEstufa)
                    .HasName("PK__Estufa__99E11D6B25D85581");

                entity.Property(e => e.DataInicio).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Estufa)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Estufa__idUsuari__76969D2E");
            });

            modelBuilder.Entity<Medicao>(entity =>
            {
                entity.Property(e => e.DataMedicao).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dispositivo).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A618AD12DD");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
