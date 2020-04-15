using ColdFrame.Models;
using ColdFrame.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ColdFrame.Controllers
{
    [ApiController]
    [Route("/plants")]
    public class PlantsController : ControllerBase
    {
        private readonly IPlantsRepo _plants;

        public PlantsController(IPlantsRepo plants)
        {
            _plants = plants;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<PlantResponse> GetById([FromRoute] int id)
        {
            var plant = _plants.GetById(id);
            return new PlantResponse(plant);
        }
    }
}