using SatrackBank.Entities.POCOEntities;

namespace SatrackBank.Entities.Interfaces
{
    public interface ICustomerProductRepository
    {
        void Create(CustomerProducts customerProduct);

        IEnumerable<CustomerProducts> GetProductsByCustomer(string customerId);
    }
}
