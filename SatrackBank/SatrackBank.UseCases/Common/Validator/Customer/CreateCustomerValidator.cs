using FluentValidation;
using SatrackBank.Entities.Enums;
using SatrackBank.UseCasesDTOs.Customer;

namespace SatrackBank.UseCases.Common.Validator.Customer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerParams>
    {
        public CreateCustomerValidator()
        {
            RuleFor(c => c.CellPhone)
                .NotEmpty().WithMessage("El celular es requerido")
                .Length(10, 10).WithMessage("El celular debe tener 10 caracteres")
                .Matches("\\(?([3]{1})\\)?([0-9]{9})$").WithMessage("El número celular no coincide con el formato.");

            RuleFor(c => c.Name)
                .Length(5, 50).WithMessage("El {PropertyName} debe tener al menos {MinLength} caracteres y máximo {MaxLength}.")
                .NotEmpty().WithMessage("El nombre es requerido");

            RuleFor(c => c.CustomerType)
                .IsInEnum().WithMessage("El tipo de cliente no es valido")
                .NotNull().WithMessage("El tipo de cliente es requerido");

            RuleFor(c => c.DocumentType)
               .IsInEnum().WithMessage("El tipo de documento no es valido")
               .NotNull().WithMessage("El tipo de documento es requerido");

            RuleFor(c => c.LegalRepresentPhone)
                .Length(5, 50).When(c => c.CustomerType.Equals(CustomerType.Business)).WithMessage("El {PropertyName} es requerido");

            RuleFor(c => c.LegalRepresentPhone)
                .Length(5, 50).When(c => c.CustomerType.Equals(CustomerType.Business)).WithMessage("El {PropertyName} es requerido")
                .Length(10, 10).WithMessage("El celular debe tener 10 caracteres")
                .Matches("\\(?([3]{1})\\)?([0-9]{9})$").When(c => c.CustomerType.Equals(CustomerType.Business)).WithMessage("El número celular no coincide con el formato.");

            RuleFor(c => c.Password)
             .Length(5, 20).WithMessage("La contraseña es requerida");

            RuleFor(c => c.Identification)
              .Length(5, 20).WithMessage("La identificación debe tener al menos {MinLength} caracteres y máximo {MaxLength}.")
              .NotEmpty().WithMessage("La identificación es requerida");
        }
    }
}