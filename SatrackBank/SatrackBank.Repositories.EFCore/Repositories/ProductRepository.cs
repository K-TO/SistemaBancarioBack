using SatrackBank.Entities.Enums;
using SatrackBank.Entities.Interfaces;
using SatrackBank.Entities.POCOEntities;
using SatrackBank.Repositories.EFCore.DataContext;

namespace SatrackBank.Repositories.EFCore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SatrackBankContext _context;

        public ProductRepository(SatrackBankContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Add(product);
        }

        public void Update(Product product)
        {
            _context.Update(product);
        }

        public bool ValidateProductForCustomer(string customerId, ProductType productType)
        {
            IQueryable<Product> productsFilter = from prod in _context.Product
                      join custprod in _context.CustomerProducts
                      on prod.Id equals custprod.ProductId
                      where custprod.CustomerId == customerId
                      where prod.ProductType == productType
                      where prod.ProductStatus == ProductStatus.Active
                      select prod;

            return (productsFilter != null && productsFilter.Any());
        }

        public void CancelProduct(Product product)
        {
            _context.Product.Update(product);
        }

        public Product GetProductForCustomer(string customerId, string productId)
        {
            IQueryable<Product> productsFilter = from prod in _context.Product
                                                 join custprod in _context.CustomerProducts
                                                 on prod.Id equals custprod.ProductId
                                                 where custprod.CustomerId == customerId
                                                 where custprod.ProductId == productId
                                                 where prod.ProductStatus == ProductStatus.Active
                                                 select prod;

            return productsFilter.FirstOrDefault();
        }

        public Product GetProductForCustomer(string customerId, ProductType productType)
        {
            IQueryable<Product> productsFilter = from prod in _context.Product
                                                 join custprod in _context.CustomerProducts
                                                 on prod.Id equals custprod.ProductId
                                                 where custprod.CustomerId == customerId
                                                 where prod.ProductType == productType
                                                 where prod.ProductStatus == ProductStatus.Active
                                                 select prod;

            return productsFilter.FirstOrDefault();
        }

        public List<Product> GetProductsForCustomer(string customerId)
        {
            IQueryable<Product> productsFilter = from prod in _context.Product
                                                 join custprod in _context.CustomerProducts
                                                 on prod.Id equals custprod.ProductId
                                                 where custprod.CustomerId == customerId
                                                 where prod.ProductStatus == ProductStatus.Active
                                                 select prod;

            return productsFilter.ToList();
        }
    }
}
