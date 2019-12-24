using Microsoft.EntityFrameworkCore;
using DotNetAngularApp.Models;

namespace DotNetAngularApp.Persistence
{
    public class CarSMARTDBContext : DbContext
    {
        public CarSMARTDBContext(DbContextOptions<CarSMARTDBContext> options)
        :base(options)
        {
        }   

        
        public DbSet<Make> Makes { get; set; }
        public DbSet<Features> Features {get;set;}
    }
}