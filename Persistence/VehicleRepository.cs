using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNetAngularApp.Core;
using DotNetAngularApp.Core.Models;

namespace DotNetAngularApp.Persistence
{
    public class VehicleRepository: IVehicleRepository
    {
        public readonly CarSMARTDBContext context;
        public VehicleRepository(CarSMARTDBContext context)
        {
            this.context = context;
        }

        public async Task<Vehicle> GetVehicle(int id, bool includeRelated=true) 
        {
            if (!includeRelated)
                return await context.Vehicles.FindAsync(id);

            return await context.Vehicles
            .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
            .Include(v => v.Model)
                .ThenInclude(m => m.Make)
            .SingleOrDefaultAsync(vehicle => vehicle.Id == id);
            
        }

        public void Remove(Vehicle vehicle)
        {
            context.Vehicles.Remove(vehicle);
        }

        public void Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
        }
    }
}