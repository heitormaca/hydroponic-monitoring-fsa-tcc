using Microsoft.EntityFrameworkCore;

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
                    .HasName("PK__Bancada__028BFB5B9CDA8DBC");

                entity.Property(e => e.DataInicio).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Semeio).IsUnicode(false);

                entity.Property(e => e.StatusBancada).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdEstufaNavigation)
                    .WithMany(p => p.Bancada)
                    .HasForeignKey(d => d.IdEstufa)
                    .HasConstraintName("FK__Bancada__id_estu__5070F446");
            });

            modelBuilder.Entity<BancadaSensores>(entity =>
            {
                entity.HasKey(e => e.IdBancadaSensores)
                    .HasName("PK__BancadaS__609AC5D6682B5785");

                entity.Property(e => e.DataAtual).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdBancadaNavigation)
                    .WithMany(p => p.BancadaSensores)
                    .HasForeignKey(d => d.IdBancada)
                    .HasConstraintName("FK__BancadaSe__id_ba__5441852A");
            });

            modelBuilder.Entity<Estufa>(entity =>
            {
                entity.HasKey(e => e.IdEstufa)
                    .HasName("PK__Estufa__58AD6956DDA5CB1C");

                entity.Property(e => e.DataInicio).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__4E3E04AD3CF9B712");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
