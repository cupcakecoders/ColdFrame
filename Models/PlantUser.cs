namespace ColdFrame.Models
{
    public class PlantUser
    {
        public int PlantId { get; set; }
        public Plant Plant { get; set; }
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}