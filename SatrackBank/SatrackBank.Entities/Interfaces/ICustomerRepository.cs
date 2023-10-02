using SatrackBank.Entities.POCOEntities;

namespace SatrackBank.Entities.Interfaces
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        Task<Customer> Authenticate(string username, string password);
        bool IdentificationExists(string identification);
    }
}
