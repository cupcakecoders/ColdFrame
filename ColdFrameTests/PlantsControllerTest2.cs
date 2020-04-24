using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ColdFrame.Data;
using ColdFrame.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;


namespace ColdFrameTests
{
    public class PlantsControllerTest2
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
            ICollection<PlantUser> plantUsersData = new List<PlantUser>();
            plantUsersData.Add(new PlantUser()
            {
                    Id = "10",
                    PlantId = 1,
                    ApplicationUser = 
            });
            
            List<Plant> testPlants = new List<Plant>();
            //need to specify all field values
            testPlants.Add(new Plant()
            {
                PlantId = 10, PlantName = "Potato", Description = "Great potato", Fruit = false, Vegetable = true,
                SowFrom = DateTime.Now, SowTo = DateTime.Now, HarvestFrom = DateTime.Now, HarvestTo = DateTime.Now, ImageUrl = "ImageLink",
                PlantUsers = 
            });

            _applicationDbContext.Plants.RemoveRange(_applicationDbContext.Plants);
            _applicationDbContext.Plants.AddRange(testPlants);
            _applicationDbContext.SaveChanges();
            
            // Act
            var httpResponse = await _client.GetAsync("/plants");

            // Assert
            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var plants = JsonConvert.DeserializeObject<List<Plant>>(stringResponse);
            //Assert.AreEqual(plants.Count, 2);
            Assert.AreEqual(testPlants.Count, plants.Count);
            for (var i = 0; i < plants.Count; i++)
            {
                Assert.AreEqual(testPlants[i], plants[i]);
            }        
        }
    }
}