using Domain.Models;
using Domain.Workflows;
using Domain.Operations;
using Domain.Infrastructure.Database;
using Domain.Infrastructure.Repositories;
using Domain.Interfaces;
using Domain.Exceptions;
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

            // Adaugam DbContext cu conexiunea configurata din appsettings.json
            builder.Services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("AzureConnection")));
            
            builder.Services.AddScoped<IProdusRepository, ProdusRepository>();
            builder.Services.AddScoped<WorkflowPlasareComanda>();
            builder.Services.AddScoped<WorkflowFacturare>();
            builder.Services.AddScoped<FacturaOperation>();
            builder.Services.AddScoped<ComandaOperation>();
            builder.Services.AddScoped<TransportOperation>();
            builder.Services.AddScoped<WorkflowCerereTransport>();

            var app = builder.Build();

            // Verificam conexiunea la baza de date
            var dbContext = app.Services.GetRequiredService<AppDBContext>();
            await TesteazaConexiuneaLaBazaDeDate(dbContext);
            
            var workflowPlasareComanda = app.Services.GetRequiredService<WorkflowPlasareComanda>();
            var workflowFacturare = app.Services.GetRequiredService<WorkflowFacturare>();
            var workflowCerereTransport = app.Services.GetRequiredService<WorkflowCerereTransport>();
            
            //adaugam doua produse in baza de date
            var produs1 = new Produs(Guid.NewGuid(), "Iphone", 5000, 1);
            var produs2 = new Produs(Guid.NewGuid(), "Huse", 100, 3);

            dbContext.Produse.Add(produs1);
            dbContext.Produse.Add(produs2);
            await dbContext.SaveChangesAsync();
            
            Console.WriteLine("Testare WorkflowPlasareComanda:");
            var produseComanda = new List<Produs> { produs1, produs2 };

            try
            {
                var comanda = await workflowPlasareComanda.ProceseazaComanda(produseComanda);

                Console.WriteLine($"Status Comanda: {comanda.Status}");
                Console.WriteLine($"Pret Total Comanda: {comanda.PretTotal}");
                
                if (comanda.Status == "Acceptata")
                {
                    dbContext.Comenzi.Add(comanda);
                    workflowFacturare.ProceseazaFacturare(dbContext, comanda);
                }
            }
            catch (ComandaAcceptataException ex)
            {
                Console.WriteLine($"Exceptie: {ex.Message}");
            }
            catch (ComandaAnulataException ex)
            {
                Console.WriteLine($"Exceptie: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare necunoscuta: {ex.Message}");
            }

            Console.WriteLine("Testul a fost finalizat.");
        }

        //funcite pentru a verifica conexiunea la baza de date
        private static async Task TesteazaConexiuneaLaBazaDeDate(AppDBContext dbContext)
        {
            try
            {
                //incearca sa execute o interogare simpla pentru a verifica conexiunea
                await dbContext.Database.CanConnectAsync();
                Console.WriteLine("Conexiunea la baza de date a fost stabilită cu succes.");
            }
            catch (Exception ex)
            {
                //Daca apare vreo eroare la conectare, o capturam și o afisam
                Console.WriteLine($"Eroare la conectarea la baza de date: {ex.Message}");
            }
        }
    }
}
