using System;
using Microsoft.VisualBasic;

namespace ColdFrame.Models
{
    public class PlantResponse
    {
        private readonly Plant _plant;

        public PlantResponse(Plant plant)
        {
            _plant = plant;
        }

        public int Id => _plant.PlantId;
        public string PlantName => _plant.PlantName;
        public string Description => _plant.Description;
        public bool Vegetable => _plant.Vegetable;
        public bool Fruit => _plant.Fruit;
        public DateTime SowFrom => _plant.SowFrom;
        public DateTime SowTo => _plant.SowTo;
        public DateTime HarvestFrom => _plant.HarvestFrom;
        public DateTime HarvestTo => _plant.HarvestTo;
        public string ImageUrl => _plant.ImageUrl;

    }
}