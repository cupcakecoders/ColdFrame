using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ColdFrame.Models
{
    public class Plant
    {
        [Key]
        public int PlantId { get; set; }
        
        public string PlantName { get; set; }
        public string Description { get; set; }
        public bool Vegetable { get; set; }
        public bool Fruit { get; set; }
        public DateTime SowFrom { get; set; }
        public DateTime SowTo { get; set; }
        public DateTime HarvestFrom { get; set; }
        public DateTime HarvestTo { get; set; }
        public string ImageUrl { get; set; }

        public Plant()
        {
            this.ApplicationUsers = new HashSet<ApplicationUser>();
        }
        
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}