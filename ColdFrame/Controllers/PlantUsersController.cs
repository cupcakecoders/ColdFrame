using System.Collections.Generic;
using System.Linq;
using ColdFrame.Models;
using ColdFrame.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ColdFrame.Controllers
{
    [ApiController]
    [Route ("/user_plants")]
    public class PlantUsersController : ControllerBase
    {
        private readonly IPlantUsersRepo _plantUsersRepo;

        public PlantUsersController(IPlantUsersRepo plantUsersRepo)
        {
            _plantUsersRepo = plantUsersRepo;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<PlantUserResponse>> GetAllUsersWithPlants()
        {
            var users = _plantUsersRepo.GetAllUsersWithPlants();
            var plantUserResponses = users.Select(users => new PlantUserResponse(users));
            return plantUserResponses.ToList();
        }
    }
}