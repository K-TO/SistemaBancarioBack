using SatrackBank.Entities.Exceptions;
using SatrackBank.Entities.Interfaces;
using SatrackBank.Entities.POCOEntities;
using SatrackBank.UseCasesPorts.Customer;

namespace SatrackBank.UseCases.Customers
{
    public class GetCustomerProductsInteractor : IGetCustomerProductsInputPort
    {
        private readonly IGetCustomerProductsOutputPort _outputPort;
        private readonly IProductRepository _productRepository;

        public GetCustomerProductsInteractor(IGetCustomerProductsOutputPort outputPort,
            IProductRepository productRepository)
        {
            _outputPort = outputPort;
            _productRepository = productRepository;
        }

        public async Task Handle(string customerId)
        {
            List<Product> products;
            try
            {
                products = _productRepository.GetProductsForCustomer(customerId);
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al obtener los productos del cliente.", ex.Message);
            }
            await _outputPort.Handle(products);
        }
    }
}
