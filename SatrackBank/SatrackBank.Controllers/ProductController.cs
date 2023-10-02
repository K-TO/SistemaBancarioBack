using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SatrackBank.Entities.POCOEntities;
using SatrackBank.Presenters.Products;
using SatrackBank.UseCasesDTOs.Product;
using SatrackBank.UseCasesPorts.Product;

namespace SatrackBank.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class ProductController
    {
        private readonly ICreateProductInputPort _createProductInputPort;
        private readonly ICreateProductOutputPort _createProductOutputPort;
        private readonly ICancelProductInputPort _cancelProductInputPort;
        private readonly ICancelProductOutputPort _cancelProductOutputPort;

        public ProductController(ICreateProductInputPort createProductInputPort,
            ICreateProductOutputPort createProductOutputPort,
            ICancelProductInputPort cancelProductInputPort,
            ICancelProductOutputPort cancelProductOutputPort)
        {
            _createProductInputPort = createProductInputPort;
            _createProductOutputPort = createProductOutputPort;
            _cancelProductInputPort = cancelProductInputPort;
            _cancelProductOutputPort = cancelProductOutputPort;
        }

        [HttpPost("create-product")]
        public async Task<BasicResponse> CreateProduct(CreateProductParams productParams)
        {
            await _createProductInputPort.Handle(productParams);
            var presenter = _createProductOutputPort as CreateProductPresenter;
            return presenter.Content;
        }

        [HttpPut("cancel-product")]
        public async Task<BasicResponse> CancelProduct(CancelProductParams cancelProduct)
        {
            await _cancelProductInputPort.Handle(cancelProduct);
            var presenter = _cancelProductOutputPort as CancelProductPresenter;
            return presenter.Content;
        }
    }
}
