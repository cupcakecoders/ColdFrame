﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ColdFrame.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<PlantUser> PlantUsers { get; set; }
    }
    
}
