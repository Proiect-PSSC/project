using Domain.Models;
using Domain.Workflows;
using Domain.Operations;
using Domain.Infrastructure.Database;
using Domain.Infrastructure.Repositories;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_PSSC
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adăugăm DbContext cu conexiunea configurată din appsettings.json
            builder.Services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("AzureConnection")));

            // Înregistrăm serviciile necesare
            builder.Services.AddScoped<IProdusRepository, ProdusRepository>();
            builder.Services.AddScoped<WorkflowPlasareComanda>();
            builder.Services.AddScoped<WorkflowFacturare>();
            builder.Services.AddScoped<FacturaOperation>();
            builder.Services.AddScoped<ComandaOperation>();

            var app = builder.Build();

            // Verificăm conexiunea la baza de date
            var dbContext = app.Services.GetRequiredService<AppDBContext>();
            await TesteazaConexiuneaLaBazaDeDate(dbContext);

            // Continuăm cu restul aplicației
            var workflowPlasareComanda = app.Services.GetRequiredService<WorkflowPlasareComanda>();
            var workflowFacturare = app.Services.GetRequiredService<WorkflowFacturare>();
            var produsRepository = app.Services.GetRequiredService<IProdusRepository>();

            var produs1 = new Produs(Guid.NewGuid(), "Produs 1", 100, 10);
            var produs2 = new Produs(Guid.NewGuid(), "Produs 2", 200, 5);

            dbContext.Produse.Add(produs1);
            dbContext.Produse.Add(produs2);
            await dbContext.SaveChangesAsync();

            Console.WriteLine("Testare WorkflowPlasareComanda:");
            var produseComanda = new List<Produs> { produs1, produs2 };
            var comanda = await workflowPlasareComanda.ProceseazaComanda(produseComanda);

            Console.WriteLine($"Status Comanda: {comanda.Status}");
            Console.WriteLine($"Pret Total Comanda: {comanda.PretTotal}");
            
            Console.WriteLine("\nTestare WorkflowFacturare:");
            if (comanda.Status == "Acceptata")
            {
                workflowFacturare.ProceseazaFacturare(dbContext, comanda);
            }

            Console.WriteLine("Testul a fost finalizat.");
        }

        // Funcție pentru a verifica conexiunea la baza de date
        private static async Task TesteazaConexiuneaLaBazaDeDate(AppDBContext dbContext)
        {
            try
            {
                // Încearcă să execute o interogare simplă pentru a verifica conexiunea
                await dbContext.Database.CanConnectAsync();
                Console.WriteLine("Conexiunea la baza de date a fost stabilită cu succes.");
            }
            catch (Exception ex)
            {
                // Dacă apare vreo eroare la conectare, o capturăm și o afișăm
                Console.WriteLine($"Eroare la conectarea la baza de date: {ex.Message}");
            }
        }
    }
}
