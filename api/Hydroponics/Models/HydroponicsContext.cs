using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hydroponics.Models
{
    public partial class HydroponicsContext : DbContext
    {
        public HydroponicsContext()
        {
        }

        public HydroponicsContext(DbContextOptions<HydroponicsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bancada> Bancada { get; set; }
        public virtual DbSet<BancadaSensores> BancadaSensores { get; set; }
        public virtual DbSet<Estufa> Estufa { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {   
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Hydroponics;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bancada>(entity =>
            {
                entity.HasKey(e => e.IdBancada)
                    .HasName("PK__Bancada__028BFB5B24F7E4BA");

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Semeio).IsUnicode(false);

                entity.Property(e => e.StatusBancada).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdEstufaNavigation)
                    .WithMany(p => p.Bancada)
                    .HasForeignKey(d => d.IdEstufa)
                    .HasConstraintName("FK__Bancada__id_estu__4E88ABD4");
            });

            modelBuilder.Entity<BancadaSensores>(entity =>
            {
                entity.HasKey(e => e.IdBancadaSensores)
                    .HasName("PK__BancadaS__609AC5D62BF10B9B");

                entity.HasOne(d => d.IdBancadaNavigation)
                    .WithMany(p => p.BancadaSensores)
                    .HasForeignKey(d => d.IdBancada)
                    .HasConstraintName("FK__BancadaSe__id_ba__5165187F");
            });

            modelBuilder.Entity<Estufa>(entity =>
            {
                entity.HasKey(e => e.IdEstufa)
                    .HasName("PK__Estufa__58AD6956C3FA0699");

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__4E3E04AD219E3737");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
