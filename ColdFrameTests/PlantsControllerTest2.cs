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
        public async Task Create()
        {
            // Arrange
            var testUser = new ApplicationUser()
            {
                Id = "100",
                UserName = "Test Name",
                NormalizedEmail = "testname@email.com",
                Email = "testname@email.com",
                EmailConfirmed = true,
                PasswordHash = "hashedpwd",
                SecurityStamp = "security_stamp",
                ConcurrencyStamp = "12345",
                PhoneNumber = "07838 485 456",
                TwoFactorEnabled = false,
                LockoutEnd = DateTimeOffset.Now,
                LockoutEnabled = false,
                AccessFailedCount = 0,
            };

            var testPlant = new Plant()
            {
                PlantId = 10, PlantName = "Potato", Description = "Great potato", Fruit = false, Vegetable = true,
                SowFrom = DateTime.Now, SowTo = DateTime.Now, HarvestFrom = DateTime.Now, HarvestTo = DateTime.Now,
                ImageUrl = "ImageLink"
            };

            testPlant.PlantUsers = new List<PlantUser>()
            {
                new PlantUser()
                {
                    ApplicationUser = testUser,
                    Plant = testPlant,
                }
            };
            //Look at clearing the db using dispose method.
            _applicationDbContext.Plants.RemoveRange(_applicationDbContext.Plants);
            _applicationDbContext.ApplicationUsers.RemoveRange(_applicationDbContext.ApplicationUsers);

            _applicationDbContext.Plants.Add(testPlant);
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
              
        }
    }
}