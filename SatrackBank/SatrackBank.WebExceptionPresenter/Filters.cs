using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SatrackBank.Entities.Exceptions;
using SatrackBank.WebExceptionPresenter.Exceptions;
using SatrackBank.WebExceptionPresenter.Middleware;

namespace SatrackBank.WebExceptionPresenter
{
    public static class Filters
    {
        public static void Register(MvcOptions options)
        {
            options.Filters.Add(new ApiExceptionFilterAttribute(new Dictionary<Type, IExceptionHandler>
            {
                {
                    typeof(GeneralException),
                    new GeneralExceptionHandler()
                },
                {
                    typeof(ValidationException),
                    new ValidationExceptionHandler()
                }
            }));
        }
    }
}
