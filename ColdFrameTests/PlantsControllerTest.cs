using System;
using System.Linq;
using System.Threading.Tasks;
using ColdFrame.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.CompilerServices;
using NUnit.Framework;
using ILogger = NUnit.Framework.Internal.ILogger;

namespace ColdFrameTests
{
    public class PlantsControllerTest : WebApplicationFactory<ColdFrame.Startup>
    {
        private readonly WebApplicationFactory<ColdFrame.Startup> _factory;

        public PlantsControllerTest(WebApplicationFactory<ColdFrame.Startup> factory)
        {
            _factory = factory;
        }

        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            //Arrange
            var client = _factory.CreateClient();
            
            //Act
            var response = await client.GetAsync(url);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual("text/html; charset=utf-8", 
                response.Content.Headers.ContentType.ToString());
        }
    }

    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            builder.ConfigureServices(services =>
            {
                var descriptor =
                    services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                    });

                var servicesProvider = services.BuildServiceProvider();

                using (var scope = servicesProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<ApplicationDbContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    db.Database.EnsureCreated();

                    try
                    {
                        Utilities.InitializeDbForTests(db);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " +
                                            "database with test messages. Error: {Message}", ex.Message);
                    }

                }
            });
        }
    }
}