using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColdFrame.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Plants = new HashSet<Plant>();
        }
        public virtual ICollection<Plant> Plants { get; set; }
    }
    
}
