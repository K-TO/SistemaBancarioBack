using FluentValidation;
using SatrackBank.UseCasesDTOs.Product;

namespace SatrackBank.UseCases.Common.Validator.Product
{
    public class CancelProductValidator : AbstractValidator<CancelProductParams>
    {
        public CancelProductValidator()
        {
            RuleFor(c => c.CustomerId)
                .NotNull().WithMessage("El cliente es requerido")
                .NotEmpty().WithMessage("El cliente es requerido");

            RuleFor(c => c.ProductId)
               .NotNull().WithMessage("El producto a cancelar es requerido")
               .NotEmpty().WithMessage("El producto a cancelar es requerido");
        }
    }
}