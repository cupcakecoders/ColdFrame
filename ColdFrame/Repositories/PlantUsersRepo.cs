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
        //these should probably go in a Application User controller/repo
        //ApplicationUser AddPlantToUser();
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
            return _applicationDbContext.ApplicationUsers.Single(A => A.Id == id);

        }

        /*public ApplicationUser AddPlantToUser(int plantId)
        {
            
        }

        ApplicationUser DeletePlantFromUser(int plantId)
        {
            
        }*/
    }
}