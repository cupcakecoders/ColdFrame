using System;

namespace ColdFrame.Models
{
    public class UpdatePlantRequest
    {
        public string PlantName { get; set; }
        public string Description { get; set; }
        public bool Vegetable { get; set; }
        public bool Fruit { get; set; }
        public DateTime SowFrom { get; set; }
        public DateTime SowTo { get; set; }
        public DateTime HarvestFrom { get; set; }
        public DateTime HarvestTo { get; set; }
        public string ImageUrl { get; set; }
    }
}