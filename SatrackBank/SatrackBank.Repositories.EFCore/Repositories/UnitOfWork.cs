using SatrackBank.Entities.Interfaces;
using SatrackBank.Repositories.EFCore.DataContext;

namespace SatrackBank.Repositories.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SatrackBankContext _context;

        public UnitOfWork(SatrackBankContext context) => _context = context;

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
