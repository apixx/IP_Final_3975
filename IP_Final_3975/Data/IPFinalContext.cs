using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IP_Final_3975.Models
{
    public partial class IPFinalContext : DbContext
    {
        public IPFinalContext(DbContextOptions<IPFinalContext> options) : base(options) { }

        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Sport> Sport { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=IP-Final;Persist Security Info=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasKey(e => e.PlayerId)
                    .HasName("PK__Players__4A4E74C87C460005");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FkSportId).HasColumnName("FKSportId");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkSport)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.FkSportId)
                    .HasConstraintName("FK__Players__FK_Spor__25869641");
            });

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SportName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
