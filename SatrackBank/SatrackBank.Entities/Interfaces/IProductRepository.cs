using SatrackBank.Entities.Enums;
using SatrackBank.Entities.POCOEntities;

namespace SatrackBank.Entities.Interfaces
{
    public interface IProductRepository
    {
        void Create(Product product);

        void Update(Product product);

        bool ValidateProductForCustomer(string customerId, ProductType productType);

        void CancelProduct(Product product);

        Product GetProductForCustomer(string customerId, string productId);

        Product GetProductForCustomer(string customerId, ProductType productType);

        List<Product> GetProductsForCustomer(string customerId);
    }
}
