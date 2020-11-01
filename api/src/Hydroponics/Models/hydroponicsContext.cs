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

        public virtual DbSet<Bancada> Bancada { get; set; }
        public virtual DbSet<Dispositivo> Dispositivo { get; set; }
        public virtual DbSet<Estufa> Estufa { get; set; }
        public virtual DbSet<Medicao> Medicao { get; set; }
        public virtual DbSet<Plantacao> Plantacao { get; set; }
        public virtual DbSet<Produtor> Produtor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=den1.mssql7.gear.host;Database=hydroponics;uid=hydroponics;Password=C6}Ew5S!IONna3;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bancada>(entity =>
            {
                entity.HasKey(e => e.IdBancada)
                    .HasName("PK__Bancada__8F08FF23F7B26424");

                entity.Property(e => e.DataInicio).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Localizacao).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.HasOne(d => d.IdDispositivoNavigation)
                    .WithMany(p => p.Bancada)
                    .HasForeignKey(d => d.IdDispositivo)
                    .HasConstraintName("FK__Bancada__idDispo__3F115E1A");

                entity.HasOne(d => d.IdEstufaNavigation)
                    .WithMany(p => p.Bancada)
                    .HasForeignKey(d => d.IdEstufa)
                    .HasConstraintName("FK__Bancada__idEstuf__3E1D39E1");
            });

            modelBuilder.Entity<Dispositivo>(entity =>
            {
                entity.HasKey(e => e.IdDispositivo)
                    .HasName("PK__Disposit__49D7618158185C8E");

                entity.Property(e => e.EndMac).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<Estufa>(entity =>
            {
                entity.HasKey(e => e.IdEstufa)
                    .HasName("PK__Estufa__99E11D6BBE246315");

                entity.Property(e => e.DataInicio).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Localizacao).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.HasOne(d => d.IdProdutorNavigation)
                    .WithMany(p => p.Estufa)
                    .HasForeignKey(d => d.IdProdutor)
                    .HasConstraintName("FK__Estufa__idProdut__3493CFA7");
            });

            modelBuilder.Entity<Medicao>(entity =>
            {
                entity.HasKey(e => e.IdMedicao)
                    .HasName("PK__Medicao__BCF0E70E22D00422");

                entity.Property(e => e.DataMedicao).HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.IdDispositivoNavigation)
                    .WithMany(p => p.Medicao)
                    .HasForeignKey(d => d.IdDispositivo)
                    .HasConstraintName("FK__Medicao__idDispo__3A4CA8FD");
            });

            modelBuilder.Entity<Plantacao>(entity =>
            {
                entity.HasKey(e => e.IdPlantacao)
                    .HasName("PK__Plantaca__D051241027991B0E");

                entity.Property(e => e.DataInicio).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Semeio).IsUnicode(false);

                entity.HasOne(d => d.IdBancadaNavigation)
                    .WithMany(p => p.Plantacao)
                    .HasForeignKey(d => d.IdBancada)
                    .HasConstraintName("FK__Plantacao__idBan__42E1EEFE");
            });

            modelBuilder.Entity<Produtor>(entity =>
            {
                entity.HasKey(e => e.IdProdutor)
                    .HasName("PK__Produtor__3BD5716122127022");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
