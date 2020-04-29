using System.Collections.Generic;

namespace ColdFrame.Models
{
    public class AddPlantsToUserResponse
    {
        private readonly PlantUser _plantUser;

        public AddPlantsToUserResponse(PlantUser plantUser)
        {
            _plantUser = plantUser;
        }

        private string UserName => _plantUser.ApplicationUser.UserName;

        private ICollection<PlantUser> Plants => _plantUser.ApplicationUser.PlantUsers;
    }
}