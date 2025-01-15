using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Infrastructure.Database;
    public class AppDBContext : DbContext
    {
        public DbSet<Produs> Produse { get; set; }
        public DbSet<Factura> Facturi { get; set; }
        
        public DbSet<Comanda> Comenzi { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produs>()
                .ToTable("Produse")
                .HasKey(p => p.Id);

            modelBuilder.Entity<Produs>()
                .Property(p => p.Pret)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Produs>()
                .Property(p => p.Denumire)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Produs>()
                .Property(p => p.Cantitate)
                .IsRequired();
            
            modelBuilder.Entity<Comanda>()
                .ToTable("Comenzi")
                .HasKey(c => c.Id);

            modelBuilder.Entity<Comanda>()
                .Property(c => c.PretTotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Comanda>()
                .Property(c => c.Status)
                .IsRequired()
                .HasMaxLength(255);
            
            modelBuilder.Entity<Factura>()
                .ToTable("Facturi")
                .HasKey(f => f.Id);

            modelBuilder.Entity<Factura>()
                .Property(f => f.PretTotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Factura>()
                .Property(f => f.DataFacturarii)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");
            
            modelBuilder.Entity<Factura>()
                .Property(f => f.IdComanda)
                .IsRequired()
                .HasMaxLength(255);
            
            
            // modelBuilder.Entity<CerereTransport>()
            //     .ToTable("CereriTransport")
            //     .HasKey(ct => ct.Id);
            //
            // modelBuilder.Entity<CerereTransport>()
            //     .HasOne(ct => ct.Comanda)
            //     .WithMany()
            //     .HasForeignKey(ct => ct.ComandaId);
            //
            // modelBuilder.Entity<CerereTransport>()
            //     .Property(ct => ct.Status)
            //     .HasMaxLength(50);
            
            base.OnModelCreating(modelBuilder);
        }

}