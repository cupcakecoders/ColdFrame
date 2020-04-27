using System;
using System.Collections.Generic;
using System.Linq;
using ColdFrame.Data;
using ColdFrame.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
    
namespace ColdFrame.Repositories
{
    
    public interface IPlantUsersRepo
    {
        ICollection<ApplicationUser> GetAllUsersWithPlants();
        ApplicationUser GetUserByIdWithPlants(string id);
        List<PlantUser> AddPlantToUser(string id, int plantId);
        //ApplicationUser DeletePlantFromUser();
    }
    
    public class PlantUsersRepo : IPlantUsersRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public PlantUsersRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public ICollection<ApplicationUser> GetAllUsersWithPlants()
        {
            return _applicationDbContext.ApplicationUsers
                .Include(u => u.PlantUsers)
                .ThenInclude(p => p.Plant)
                .ToList();
        }
        
        public ApplicationUser GetUserByIdWithPlants(string id)
        {
            return _applicationDbContext.ApplicationUsers
                .Include(u => u.PlantUsers)
                .ThenInclude(p => p.Plant)
                .Single(u => u.Id == id);
        }

        public List<PlantUser> AddPlantToUser(string id, int plantId)
        {
            var user = _applicationDbContext.ApplicationUsers.Single(u => u.Id == id);
            var plant = _applicationDbContext.Plants.Single(p => p.PlantId == plantId);
            
            return new List<PlantUser>()
            {
                 new PlantUser()
                {
                    ApplicationUser = user,
                    Plant = plant,
                }
            };
        }

        /*ApplicationUser DeletePlantFromUser(int plantId)
        {
            
        }*/
    }
}