using SatrackBank.Entities.Interfaces;
using SatrackBank.Entities.POCOEntities;
using SatrackBank.Repositories.EFCore.DataContext;
using Bcr = BCrypt.Net;

namespace SatrackBank.Repositories.EFCore.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SatrackBankContext _context;

        public CustomerRepository(SatrackBankContext context)
        {
            _context = context;
        }

        public void Create(Customer customer)
        {
            _context.Add(customer);
        }

        public Task<Customer> Authenticate(string userName, string password)
        {
            Customer customer = _context.Customer.Where(x => x.Identification.Equals(userName)).FirstOrDefault();
            if (customer != null && Bcr.BCrypt.Verify(password, customer.Password))
            {
                return Task.FromResult(customer);
            }
            return Task.FromResult<Customer>(null);
        }

        public bool IdentificationExists(string identification)
        {
            Customer customer = _context.Customer.Where(c => c.Identification.Equals(identification)).FirstOrDefault();
            return customer != null;
        }
    }
}
