using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColdFrame.Data;
using ColdFrame.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ColdFrame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateDatabaseIfNotExists(host);
            host.Run();
        }

        private static void CreateDatabaseIfNotExists(IHost host)
        {
           using var scope = host.Services.CreateScope();
           var services = scope.ServiceProvider;

           var context = services.GetRequiredService<ApplicationDbContext>();
           context.Database.EnsureCreated();

           if (!context.Plants.Any())
           {
               var plants = SamplePlants.GetPlants();
               context.Plants.AddRange(plants);
               context.SaveChanges();
           }
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
}
