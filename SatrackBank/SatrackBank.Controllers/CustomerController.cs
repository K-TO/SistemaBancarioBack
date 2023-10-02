using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SatrackBank.Entities.POCOEntities;
using SatrackBank.Presenters.Customer;
using SatrackBank.UseCasesDTOs.Customer;
using SatrackBank.UseCasesPorts.Customer;

namespace SatrackBank.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController
    {
        private readonly ICreateCustomerInputPort _createCustomerInputPort;
        private readonly ICreateCustomerOutputPort _createCustomerOutputPort;
        private readonly IGetCustomerProductsInputPort _getCustomerProductsInputPort;
        private readonly IGetCustomerProductsOutputPort _getCustomerProductsOutputPort;

        public CustomerController(ICreateCustomerInputPort createCustomerInputPort,
            ICreateCustomerOutputPort createCustomerOutputPort,
            IGetCustomerProductsInputPort getCustomerProductsInputPort,
            IGetCustomerProductsOutputPort getCustomerProductsOutputPort)
        {
            _createCustomerInputPort = createCustomerInputPort;
            _createCustomerOutputPort = createCustomerOutputPort;
            _getCustomerProductsInputPort = getCustomerProductsInputPort;
            _getCustomerProductsOutputPort = getCustomerProductsOutputPort;
        }

        [HttpPost("create-customer")]
        [AllowAnonymous]
        public async Task<BasicResponse> CreateCustomer(CreateCustomerParams customerParams)
        {
            await _createCustomerInputPort.Handle(customerParams);
            var presenter = _createCustomerOutputPort as CreateCustomerPresenter;
            return presenter.Content;
        }

        [HttpGet("customer-products")]
        public async Task<List<Product>> GetCustomerProducts(string customerId)
        {
            await _getCustomerProductsInputPort.Handle(customerId);
            var presenter = _getCustomerProductsOutputPort as GetCustomerProductsPresenter;
            return presenter.Content;
        }
    }
}
