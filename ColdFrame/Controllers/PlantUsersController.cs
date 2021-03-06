﻿using System.Collections.Generic;
using System.Linq;
using ColdFrame.Models;
using ColdFrame.Repositories;
using IdentityModel;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColdFrame.Controllers
{
    [Authorize]
    [ApiController]
    [Route ("/users")]
    public class PlantUsersController : ControllerBase
    {
        private readonly IPlantUsersRepo _plantUsersRepo;

        public PlantUsersController(IPlantUsersRepo plantUsersRepo)
        {
            _plantUsersRepo = plantUsersRepo;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<PlantUserResponse>> GetAllUsersWithPlants()
        {
            var users = _plantUsersRepo.GetAllUsersWithPlants();
            var plantUserResponses = users.Select(u => new PlantUserResponse(u));
            return plantUserResponses.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<PlantUserResponse> GetUserWithPlantsById([FromRoute]string id)
        {
             var user = _plantUsersRepo.GetUserByIdWithPlants(id);
             return new PlantUserResponse(user);
        }
        
        [HttpPatch] 
        [Route("{id}/add-plant/{plantId}")]

        public ActionResult<List<AddPlantsToUserResponse>> AddPlantToUser([FromRoute]string id, [FromRoute]int plantId)
        {
           _plantUsersRepo.AddPlantToUser(id, plantId);
           return Ok();
        }
    }
}