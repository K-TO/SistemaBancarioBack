using FluentValidation;
using SatrackBank.Entities.Enums;
using SatrackBank.UseCasesDTOs.Product;

namespace SatrackBank.UseCases.Common.Validator.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProductParams>
    {
        public CreateProductValidator()
        {
            RuleFor(c => c.ProductType)
                .NotNull().WithMessage("El tipo de producto es requerido")
                .IsInEnum().WithMessage("El tipo de producto no es valido");

            RuleFor(c => c.CustomerId)
                .NotNull().WithMessage("El cliente es requerido")
                .NotEmpty().WithMessage("El cliente es requerido");

            RuleFor(c => c.Interest)
               .NotNull().WithMessage("El % de interes es requerido")
               .LessThanOrEqualTo(100).WithMessage("El % de interes no puede ser mayor al 100%");

            //RuleFor(m => m.Interest).Must(
            //    (model, field) => 
            //    ProductType.Ahorros == model.ProductType || ProductType.Corriente .LengthMax
            //    );
        }
    }
}