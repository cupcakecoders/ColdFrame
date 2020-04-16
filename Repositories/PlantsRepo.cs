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
        private readonly PlantDbContext _plantDbContext;

        public PlantsRepo(PlantDbContext plantDbContext)
        {
            _plantDbContext = plantDbContext;
        }

        public IEnumerable<Plant> GetAll()
        {
            return _plantDbContext.Plants;
            
        }
        public Plant GetById(int id)
        {
            return _plantDbContext.Plants
                .Single(plant => plant.PlantId == id);
        }
        
        public Plant Create(CreatePlantRequest newPlant)
        {
            var insertResponse = _plantDbContext.Plants.Add(new Plant
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
            _plantDbContext.SaveChanges();

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

            _plantDbContext.Plants.Update(plant);
            _plantDbContext.SaveChanges();

            return plant;
            
        }

        public void Delete(int id)
        {
            var plant = GetById(id);
            _plantDbContext.Plants.Remove(plant);
            _plantDbContext.SaveChanges();
        }
        

        public Plant Where(string plantNameQuery)
        {
            return _plantDbContext.Plants
                .SingleOrDefault(plant => plant.PlantName == plantNameQuery);
        }
    }
    
}