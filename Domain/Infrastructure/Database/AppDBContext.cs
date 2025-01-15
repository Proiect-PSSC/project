using Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Domain.Infrastructure.Database;
    public class AppDBContext : DbContext
    {
        public DbSet<Produs> Produse { get; set; }
        public DbSet<Factura> Facturi { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produs>()
                .ToTable("Produse")
                .HasKey(p => p.Id);
            
            modelBuilder.Entity<Factura>()
                .ToTable("Facturi")
                .HasKey(f => f.Id);

            modelBuilder.Entity<Factura>()
                .HasMany(f => f.Produse)
                .WithMany();
            
            modelBuilder.Entity<Produs>()
                .Property(p => p.Pret)
                .HasColumnType("decimal(18,2)");
            
            modelBuilder.Entity<Factura>()
                .Property(f => f.PretTotal)
                .HasColumnType("decimal(18,2)");
            
            base.OnModelCreating(modelBuilder);
        }

}