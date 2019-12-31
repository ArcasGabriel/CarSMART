using System.Threading.Tasks;
using DotNetAngularApp.Core.Models;
namespace DotNetAngularApp.Core
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);

        void Add(Vehicle vechile);

        void Remove(Vehicle vehicle);

    }
}