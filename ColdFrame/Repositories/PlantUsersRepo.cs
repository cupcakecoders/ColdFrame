using System.Collections.Generic;
using System.Linq;
using ColdFrame.Data;
using ColdFrame.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace ColdFrame.Repositories
{
    public interface IPlantUsersRepo
    {
        IEnumerable<ApplicationUser> GetAllUsersWithPlants();
        //PlantUser GetUserByIdWithPlants(int id);
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

        public IEnumerable<ApplicationUser> GetAllUsersWithPlants()
        {
            
            return _applicationDbContext.ApplicationUsers;
            
        }
        
        /*public PlantUser GetUserByIdWithPlants(int userId)
        {
            
        }

        public ApplicationUser AddPlantToUser(int plantId)
        {
            
        }

        ApplicationUser DeletePlantFromUser(int plantId)
        {
            
        }*/
    }
}