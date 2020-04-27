using Newtonsoft.Json;

namespace ColdFrame.Models
{
    public class PlantUser
    {
        public int PlantId { get; set; }
        public Plant Plant { get; set; } 
        
        public string Id { get; set; }
        
        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }
    }
}