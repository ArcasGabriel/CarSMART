using System.Threading.Tasks;
using DotNetAngularApp.Core.Models;
using System.Collections.Generic;
namespace DotNetAngularApp.Core
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);

        Task<IList<Vehicle>> GetVehicles();

        void Add(Vehicle vechile);

        void Remove(Vehicle vehicle);

    }
}