using ColdFrame.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ColdFrame.Data;

namespace ColdFrame.Repositories
{
    public interface IPlantsRepo
    {
        Plant GetById(int id);
        Plant Create(CreatePlantRequest newPlant);
        Plant Update(int id, UpdatePlantRequest update);
        void Delete(int id);
        Plant Where(string PlantnameQuery);
    }

    
    public class PlantsRepo : IPlantsRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        
        public Plant GetById(int id)
        {
            return _applicationDbContext.Plants
                .Single(plant => plant.Id == id);
        }

        public Plant Create(CreatePlantRequest newPlant)
        {

            var insertResponse = Plants.Add(new Plant
            {
                PlantName = newPlant.
                Description = newPlant.Description,
                Vegetable = newPlant.Email,
                Fruit = newPlant.Plantname,
                Sow = newPlant.
                ImageUrl = newPlant.ProfileImageUrl,
            });
            SaveChanges();

            return insertResponse.Entity;
        }

        public void Delete(int id)
        {
            var Plant = GetById(id);
            Plants.Remove(Plant);
            SaveChanges();
        }

        public Plant Where(string plantNameQuery)
        {
            return _applicationDbContext.Plants
                .SingleOrDefault(plant => plant.PlantName == plantNameQuery);
        }
    }
    
}