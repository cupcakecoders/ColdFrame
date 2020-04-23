using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ColdFrame;
using ColdFrame.Controllers;
using ColdFrame.Data;
using ColdFrame.Models;
using ColdFrame.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NUnit.Framework;


namespace ColdFrameTests
{
    public class PlantsControllerTest
    {
        private HttpClient _client;
        private CustomWebApplicationFactory<ColdFrame.Startup> _factory;

        [OneTimeSetUp]
        public void GivenARequestToTheController()
        {
            _factory = new CustomWebApplicationFactory<ColdFrame.Startup>();
            _client = _factory.CreateClient();
            
        }
        
        [Test]
        public async Task GetAll()
        {
            //db.Plants.Add(new Plant() {PlantName = "plantscontroller apple"});
            var httpResponse = await _client.GetAsync("/plants");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var plants = JsonConvert.DeserializeObject<List<Plant>>(stringResponse);
          //  Assert.Contains(firstPlant, p => p.PlaneName =="TEST tomato");
        }
    }
}