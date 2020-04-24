using System;
using System.Collections.Generic;
using System.ComponentModel;
using ColdFrame.Data;
using ColdFrame.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace ColdFrameTests
{
    public class Utilities
    {
        
        public static void InitializeDbForTests(ApplicationDbContext db)
        {
            db.Plants.AddRange(GetSeedingplants());
            db.ApplicationUsers.AddRange(GetSeedingUsers());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(ApplicationDbContext db)
        {
            db.Plants.RemoveRange(db.Plants);
            db.ApplicationUsers.RemoveRange(db.ApplicationUsers);
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

        public static List<ApplicationUser> GetSeedingUsers()
        {
            return new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                 Id   = "100",
                 UserName = "Test Name",
                 NormalizedEmail = "testname@email.com",
                 Email = "testname@email.com",
                 EmailConfirmed = true,
                 PasswordHash = "hashedpwd",
                 SecurityStamp = "security_stamp",
                 ConcurrencyStamp = "12345",
                 PhoneNumber = "07838 485 456",
                 TwoFactorEnabled = false,
                 LockoutEnd = DateTimeOffset.Now,
                 LockoutEnabled = false,
                 AccessFailedCount = 0
                }
            };
        }
    }
}