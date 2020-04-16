using System;
using ColdFrame.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;

namespace ColdFrame.Data
{
    public class PlantDbContext : ApplicationDbContext
    {
        public PlantDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        
        public DbSet<Plant> Plants { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlantUser>()
                .HasKey(t => new { t.PlantId, t.Id });

            modelBuilder.Entity<PlantUser>()
                .HasOne(pt => pt.Plant)
                .WithMany(p => p.PlantUsers)
                .HasForeignKey(pt => pt.PlantId);

            modelBuilder.Entity<PlantUser>()
                .HasOne(pt => pt.ApplicationUser)
                .WithMany(t => t.PlantUsers)
                .HasForeignKey(pt => pt.Id);

            modelBuilder.Entity<Plant>().HasData(
                new Plant
                {
                    PlantId = 1, PlantName = "Tomato", Description = "The tomato is the fruit of the tomato plant, a member of the Nightshade family (Solanaceae). The fruit grows on a sprawling vine that is often trellised or caged to keep it upright.", Fruit = false, Vegetable = true, 
                    HarvestFrom = DateTime.Now.AddMonths(1), HarvestTo = DateTime.Now.AddMonths(2), ImageUrl = "", SowFrom = DateTime.Now , SowTo = DateTime.Now.AddMonths(1), PlantUsers = 
                },
                new Plant 
                    { 
                        PlantId = 1, PlantName = "Brocolli", Description = "", Fruit = false, Vegetable = true, 
                        HarvestFrom = DateTime.Now.AddMonths(2), HarvestTo = DateTime.Now.AddMonths(4), ImageUrl = "", SowFrom = DateTime.Now, SowTo = DateTime.Now.AddMonths(2), PlantUsers = 
                    },
                new Plant 
                    { 
                        PlantId = 1, PlantName = "Carrots", Description = "", Fruit = false, Vegetable = true, 
                        HarvestFrom = DateTime.Now.AddMonths(1), HarvestTo = DateTime.Now.AddMonths(3), ImageUrl = "", SowFrom = DateTime.Now , SowTo = DateTime.Now.AddMonths(3) , PlantUsers = 
                    }
            );
            
        }
    }
}