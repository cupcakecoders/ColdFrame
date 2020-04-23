using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net.Http;
using System.Threading.Tasks;
using ColdFrame.Data;
using ColdFrame.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;


namespace ColdFrameTests
{
    public class PlantsControllerTest
    {
        private HttpClient _client;
        private CustomWebApplicationFactory<ColdFrame.Startup> _factory;
        private ApplicationDbContext _applicationDbContext;
        
        [OneTimeSetUp]
        public void Setup()
        {
            _factory = new CustomWebApplicationFactory<ColdFrame.Startup>();
            _client = _factory.WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var serviceProvider = services.BuildServiceProvider();
                        var scope = serviceProvider.CreateScope();
                        var scopedServices = scope.ServiceProvider;
                        _applicationDbContext = scopedServices.GetRequiredService<ApplicationDbContext>();

                    });
                }).CreateClient();
        }
        
        [Test]
        public async Task GetAll()
        {
            // Arrange
            _applicationDbContext.Plants.RemoveRange(_applicationDbContext.Plants);
            _applicationDbContext.Plants.Add(new Plant() {PlantName = "first plant"});
            _applicationDbContext.SaveChanges();
            
            // Act
            var httpResponse = await _client.GetAsync("/plants");

            // Assert
            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var plants = JsonConvert.DeserializeObject<List<Plant>>(stringResponse);
            Assert.AreEqual(plants.Count, 1);
            var firstPlant = plants[0];
            Assert.AreEqual(firstPlant.PlantName, "first plant");
            
        }
    }
}