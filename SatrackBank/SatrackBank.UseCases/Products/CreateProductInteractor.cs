using FluentValidation;
using SatrackBank.Entities.Enums;
using SatrackBank.Entities.Exceptions;
using SatrackBank.Entities.Interfaces;
using SatrackBank.Entities.POCOEntities;
using SatrackBank.UseCases.Common.Validator;
using SatrackBank.UseCasesDTOs.Product;
using SatrackBank.UseCasesPorts.Product;

namespace SatrackBank.UseCases.Products
{
    public class CreateProductInteractor : ICreateProductInputPort
    {
        private readonly IProductRepository _productRepository;
        private readonly ICustomerProductRepository _customerProductRepository;
        private readonly IMovementRepository _movementRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEnumerable<IValidator<CreateProductParams>> _validators;
        private readonly ICreateProductOutputPort _createProductOutputPort;

        public CreateProductInteractor(IProductRepository productRepository,
            ICustomerProductRepository customerProductRepository,
            IMovementRepository movementRepository,
            IUnitOfWork unitOfWork,
            IEnumerable<IValidator<CreateProductParams>> validators,
            ICreateProductOutputPort createProductOutputPort)
        {
            _productRepository = productRepository;
            _customerProductRepository = customerProductRepository;
            _movementRepository = movementRepository;
            _unitOfWork = unitOfWork;
            _validators = validators;
            _createProductOutputPort = createProductOutputPort;
        }

        public async Task Handle(CreateProductParams createProductParams)
        {
            await Validator<CreateProductParams>.Validate(createProductParams, _validators);

            bool customerHasProduct = _productRepository.ValidateProductForCustomer(createProductParams.CustomerId, createProductParams.ProductType);
            BasicResponse response = new();

            if (!customerHasProduct)
            {
                if (createProductParams.ProductType == ProductType.CDT)
                {
                    bool customerHasSavingsAccount = _productRepository.ValidateProductForCustomer(createProductParams.CustomerId, ProductType.Ahorros);
                    if (!customerHasSavingsAccount)
                    {
                        response.Message = "Para adquirir un CDT necesitas una cuenta de ahorros.";
                        response.HasError = true;
                        await _createProductOutputPort.Handle(response);
                        return;
                    }
                }

                string productId = Guid.NewGuid().ToString();
                Product product = new Product
                {
                    CreationDate = DateTime.Now,
                    CurrentBalance = createProductParams.CurrentBalance,
                    Id = productId,
                    Interest = createProductParams.Interest,
                    ProductStatus = ProductStatus.Active,
                    ProductType = createProductParams.ProductType
                };

                _productRepository.Create(product);

                CustomerProducts customerProducts = new CustomerProducts
                {
                    CustomerId = createProductParams.CustomerId,
                    ProductId = productId
                };

                _customerProductRepository.Create(customerProducts);

                Movement movement = new Movement
                {
                    Date = DateTime.Now,
                    Description = "Apertura de cuenta",
                    Id = Guid.NewGuid().ToString(),
                    MovementType = MovementType.Creation,
                    PreviousBalance = 0,
                    ProductId = productId,
                    Value = createProductParams.CurrentBalance
                };

                _movementRepository.Create(movement);

                try
                {
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new GeneralException("Error al crear el producto.", ex.Message);
                }
                response.Message = $"Producto creado satisfactoriamente.";
                await _createProductOutputPort.Handle(response);
            }
            else
            {
                response.Message = "El cliente ya cuenta con este producto, no puede crear uno nuevo del mismo tipo.";
                response.HasError = true;
                await _createProductOutputPort.Handle(response);
            }
        }
    }
}
