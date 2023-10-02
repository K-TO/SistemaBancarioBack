using FluentValidation;
using SatrackBank.UseCasesDTOs.Simulator;

namespace SatrackBank.UseCases.Common.Validator.Simulator
{
    public class SimulatorValidator : AbstractValidator<SimulatorParams>
    {
        public SimulatorValidator()
        {
            RuleFor(x => x.BeginDate)
                .NotNull().WithMessage("La fecha inicial es requerida.")
                .NotEmpty().WithMessage("La fecha inicial es requerida.");

            RuleFor(x => x.EndDate)
                .NotNull().WithMessage("La fecha final es requerida.")
                .NotEmpty().WithMessage("La fecha final es requerida.");

            RuleFor(x => x.Interest)
               .NotNull().WithMessage("El interes es requerido.")
               .NotEmpty().WithMessage("El interes es requerido.")
               .LessThanOrEqualTo(100).WithMessage("El % de interes no puede ser mayor al 100%");

            RuleFor(x => x.Money)
               .NotNull().WithMessage("El valor monetario es requerido.")
               .NotEmpty().WithMessage("El valor monetario es requerido.");
        }
    }
}
