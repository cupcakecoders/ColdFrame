using System.Linq;
using System.Threading.Tasks;
using ColdFrame.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

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
            });
        }
    }
}