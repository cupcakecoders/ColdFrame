﻿namespace ColdFrame.Models
{
    public class PlantUserResponse
    {
        private readonly ApplicationUser _applicationUser;

        public PlantUserResponse(ApplicationUser applicationUser)
        {
            _applicationUser = applicationUser;
        }

        public string UserName => _applicationUser.UserName;
    }
}