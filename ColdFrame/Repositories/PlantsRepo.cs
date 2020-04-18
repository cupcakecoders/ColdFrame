using System.Collections.Generic;
using ColdFrame.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ColdFrame.Data;

namespace ColdFrame.Repositories
{
    public interface IPlantsRepo
    {
        IEnumerable<Plant> GetAll();
        Plant GetById(int id);
        Plant Create(CreatePlantRequest newPlant);
        Plant Update(int id, UpdatePlantRequest update);
        void Delete(int id);
        Plant Where(string plantNameQuery);
    }

    public class PlantsRepo : IPlantsRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PlantsRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Plant> GetAll()
        {
            return _applicationDbContext.Plants;
            
        }
        public Plant GetById(int id)
        {
            return _applicationDbContext.Plants
                .Single(plant => plant.PlantId == id);
        }
        
        public Plant Create(CreatePlantRequest newPlant)
        {
            var insertResponse = _applicationDbContext.Plants.Add(new Plant
            {
                PlantName = newPlant.PlantName,
                Description = newPlant.Description,
                Vegetable = newPlant.Vegetable,
                Fruit = newPlant.Fruit,
                SowFrom = newPlant.SowFrom,
                SowTo = newPlant.SowTo,
                HarvestFrom = newPlant.HarvestFrom,
                HarvestTo = newPlant.HarvestTo,
                ImageUrl = newPlant.ImageUrl
            });
            _applicationDbContext.SaveChanges();

            return insertResponse.Entity;
        }

        public Plant Update(int id, UpdatePlantRequest update)
        {
            var plant = GetById(id);

            plant.PlantName = update.PlantName;
            plant.Description = update.Description;
            plant.Vegetable = update.Vegetable;
            plant.Fruit = update.Fruit;
            plant.SowFrom = update.SowFrom;
            plant.SowTo = update.SowTo;
            plant.HarvestFrom = update.HarvestFrom;
            plant.HarvestTo = update.HarvestTo;
            plant.ImageUrl = update.ImageUrl;

            _applicationDbContext.Plants.Update(plant);
            _applicationDbContext.SaveChanges();

            return plant;
        }

        public void Delete(int id)
        {
            var plant = GetById(id);
            _applicationDbContext.Plants.Remove(plant);
            _applicationDbContext.SaveChanges();
        }
        

        public Plant Where(string plantNameQuery)
        {
            return _applicationDbContext.Plants
                .SingleOrDefault(plant => plant.PlantName == plantNameQuery);
        }
    }
    
}