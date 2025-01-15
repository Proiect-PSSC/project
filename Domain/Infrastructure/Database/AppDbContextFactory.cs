using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Domain.Infrastructure.Database;
using Microsoft.Extensions.Configuration;

namespace Domain.Infrastructure
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            var connectionString = "Server=tcp:proiectpssc00.database.windows.net,1433;Initial Catalog=Proiect_PSSc;Persist Security Info=False;User ID=adminproiect;Password=9KBKiM!sbRxmXKQ;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; 

            optionsBuilder.UseSqlServer(connectionString);

            return new AppDBContext(optionsBuilder.Options); // Crează DbContext cu opțiunile configurate
        }
    }
}