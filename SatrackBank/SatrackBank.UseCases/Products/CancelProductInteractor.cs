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
    public class CancelProductInteractor : ICancelProductInputPort
    {
        private readonly IProductRepository _productRepository;
        private readonly IMovementRepository _movementRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEnumerable<IValidator<CancelProductParams>> _validators;
        private readonly ICancelProductOutputPort _cancelProductOutputPort;

        public CancelProductInteractor(IProductRepository productRepository,
            IMovementRepository movementRepository,
            IUnitOfWork unitOfWork,
            IEnumerable<IValidator<CancelProductParams>> validators,
            ICancelProductOutputPort cancelProductOutputPort)
        {
            _productRepository = productRepository;
            _movementRepository = movementRepository;
            _unitOfWork = unitOfWork;
            _validators = validators;
            _cancelProductOutputPort = cancelProductOutputPort;
        }

        public async Task Handle(CancelProductParams cancelProductParams)
        {
            await Validator<CancelProductParams>.Validate(cancelProductParams, _validators);
            BasicResponse response = new();
            Movement movement = new Movement
            {
                Id = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
                MovementType = MovementType.Cancellation,
                Description = $"Cancelación de la cuenta {cancelProductParams.ProductId}",
                ProductId = cancelProductParams.ProductId,
                Value = 0
            };
            Product cancellateProduct = _productRepository.GetProductForCustomer(cancelProductParams.CustomerId, cancelProductParams.ProductId);

            if (cancellateProduct != null)
            {
                //Si tiene cuentas con saldos a favor, no se pueden cancelar.
                if (cancellateProduct.CurrentBalance > 0 && cancellateProduct.ProductType != ProductType.CDT)
                {
                    response.Message = "No se puede cancelar una cuenta con saldos a favor.";
                    response.HasError = true;
                    await _cancelProductOutputPort.Handle(response);
                    return;
                }
                else if (cancellateProduct.ProductType == ProductType.CDT)
                {
                    //Validar si tiene cuenta de ahorros antes de cancelar.
                    Product customerSavingsAccount = _productRepository.GetProductForCustomer(cancelProductParams.CustomerId, ProductType.Ahorros);
                    if (customerSavingsAccount == null)
                    {
                        response.Message = "Para cancelar un CDT necesitas una cuenta de ahorros.";
                        response.HasError = true;
                        await _cancelProductOutputPort.Handle(response);
                        return;
                    }
                    customerSavingsAccount.CurrentBalance += cancellateProduct.CurrentBalance;
                    _productRepository.Update(customerSavingsAccount);
                }
                movement.PreviousBalance = cancellateProduct.CurrentBalance;
                cancellateProduct.CurrentBalance = 0;
                cancellateProduct.ProductStatus = ProductStatus.Cancelled;
                _productRepository.Update(cancellateProduct);
                _movementRepository.Create(movement);
                try
                {
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new GeneralException("Error al cancelar el producto.", ex.Message);
                }
                response.Message = $"Producto cancelado satisfactoriamente.";
                await _cancelProductOutputPort.Handle(response);
            }
            else
            {
                response.Message = "El cliente no cuenta con este producto o ya esta cancelado.";
                await _cancelProductOutputPort.Handle(response);
            }
        }


    }
}
