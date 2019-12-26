using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using DotNetAngularApp.Models;

namespace DotNetAngularApp.Persistence
{
    public class CarSMARTDBContext : DbContext
    {
        
        public DbSet<Make> Makes { get; set; }
        public DbSet<Features> Features {get;set;}

        public DbSet<Vehicle> Vehicles {get;set;}

        public CarSMARTDBContext(DbContextOptions<CarSMARTDBContext> options)
        :base(options)
        {
        }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>().HasKey(fv => new {fv.VehicleId, fv.FeatureId});
        }

        
    }
}