using System.Collections.Generic;
using System.Linq;
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
        [Route("")]
        public ActionResult<IEnumerable<PlantResponse>> GetAll()
        {
            var plants = _plants.GetAll();
            var plantResponses = plants
                .Select(plants => new PlantResponse(plants));
            return plantResponses.ToList();
        }
        
        [HttpGet]
        [Route("{id}")]
        public ActionResult<PlantResponse> GetById([FromRoute] int id)
        {
            var plant = _plants.GetById(id);
            return new PlantResponse(plant); 
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] CreatePlantRequest newPlant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plant = _plants.Create(newPlant);

            var url = Url.Action("GetById", new {id = plant.PlantId});
            var responseViewModel = new PlantResponse(plant);
            return Created(url, responseViewModel);
        }

        [HttpPatch]
        [Route("{id}/update")]
        public ActionResult<PlantResponse> Update([FromRoute] int id, [FromBody] UpdatePlantRequest update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plant = _plants.Update(id, update);
            return new PlantResponse(plant);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _plants.Delete(id);
            return Ok();
        }
    }
}