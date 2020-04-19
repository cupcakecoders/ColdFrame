using ColdFrame.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColdFrame.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                
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
        }
    }
}
