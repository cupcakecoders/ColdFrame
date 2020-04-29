using System.Collections.Generic;

namespace ColdFrame.Models
{
    public class UpdatePlantUserRequest
    {
        public string UserName { get; private set; }
        public List<PlantUser> PlantUsers { get; set; }
    }
}