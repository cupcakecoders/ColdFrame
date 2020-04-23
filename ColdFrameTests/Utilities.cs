using System.Collections.Generic;
using ColdFrame.Data;
using ColdFrame.Models;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace ColdFrameTests
{
    public class Utilities
    {
        
        public static void InitializeDbForTests(ApplicationDbContext db)
        {
            db.Plants.AddRange(GetSeedingplants());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(ApplicationDbContext db)
        {
            db.Plants.RemoveRange(db.Plants);
            InitializeDbForTests(db);
        }

        public static List<Plant> GetSeedingplants()
        {
            return new List<Plant>()
            {
                new Plant(){ PlantName = "TEST apple" },
                new Plant(){ PlantName = "TEST pear" },
                new Plant(){ PlantName = "TEST tomato" }
            };
        }
    }
}