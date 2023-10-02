using SatrackBank.Entities.Interfaces;
using SatrackBank.Entities.POCOEntities;
using SatrackBank.Repositories.EFCore.DataContext;

namespace SatrackBank.Repositories.EFCore.Repositories
{
    public class CustomerProductRepository : ICustomerProductRepository
    {
        private readonly SatrackBankContext _context;

        public CustomerProductRepository(SatrackBankContext context)
        {
            _context = context;
        }

        public void Create(CustomerProducts customerProduct)
        {
            _context.Add(customerProduct);
        }

        public IEnumerable<CustomerProducts> GetProductsByCustomer(string customerId)
        {
            return _context.CustomerProducts.Where(cp => cp.CustomerId.Equals(customerId)).ToList();
        }
    }
}
