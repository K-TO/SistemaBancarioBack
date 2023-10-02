using FluentValidation;
using SatrackBank.UseCasesDTOs.Auth;

namespace SatrackBank.UseCases.Common.Validator.Auth
{
    public class LoginValidator : AbstractValidator<LoginParams>
    {
        public LoginValidator()
        {
            RuleFor(x => x.User)
                .NotEmpty()
                .NotNull()
                .WithMessage("El usuario es requerido.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("La contraseña es requerida.");
        }
    }
}
