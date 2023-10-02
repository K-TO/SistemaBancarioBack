using SatrackBank.Entities.Interfaces;
using SatrackBank.Entities.POCOEntities;
using SatrackBank.Repositories.EFCore.DataContext;

namespace SatrackBank.Repositories.EFCore.Repositories
{
    public class MovementRepository : IMovementRepository
    {
        private readonly SatrackBankContext _context;

        public MovementRepository(SatrackBankContext context)
        {
            _context = context;
        }

        public void Create(Movement movement)
        {
            _context.Add(movement);
        }

        public List<Movement> GetMovementsByCustomer(string customerId) {
            IQueryable<Movement> movements = from mov in _context.Movement
                                             join custprod in _context.CustomerProducts
                                             on mov.ProductId equals custprod.ProductId
                                             where custprod.ProductId == customerId
                                             select mov;
            return movements.ToList();
        }
    }
}
