using System;
using System.Collections.Generic;
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
    public class PlantUsersControllerTest
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
        public async Task GetUserPlants()
        {
            // Arrange
            _applicationDbContext.Plants.RemoveRange(_applicationDbContext.Plants);
            _applicationDbContext.ApplicationUsers.RemoveRange(_applicationDbContext.ApplicationUsers);
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

            testUser.PlantUsers = new List<PlantUser>()
            {
                new PlantUser()
                {
                    ApplicationUser = testUser,
                    Plant = testPlant,
                }
            };
            
            _applicationDbContext.ApplicationUsers.Add(testUser);
            _applicationDbContext.SaveChanges();
            
            // Act
            var httpResponse = await _client.GetAsync("/users/100");

            // Assert
            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<ApplicationUser>(stringResponse);
            Assert.AreEqual(user.PlantUsers.First().Plant.PlantName, "Potato");
              
        }
    }
}