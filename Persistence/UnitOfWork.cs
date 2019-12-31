using System.Threading.Tasks;
using DotNetAngularApp.Core;
namespace DotNetAngularApp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarSMARTDBContext context;
        public UnitOfWork(CarSMARTDBContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}