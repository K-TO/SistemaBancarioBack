using FluentValidation;
using FluentValidation.Results;

namespace SatrackBank.UseCases.Common.Validator
{
    public static class Validator<Model>
    {
        public static Task<List<ValidationFailure>> Validate(Model model,
            IEnumerable<IValidator<Model>> validators,
            bool causesException = true)
        {
            var failures = validators
               .Select(v => v.Validate(model))
               .SelectMany(e => e.Errors)
               .Where(f => f != null)
               .ToList();

            if (failures.Any() && causesException)
            {
                throw new ValidationException(failures);
            }
            return Task.FromResult(failures);
        }
    }
}
