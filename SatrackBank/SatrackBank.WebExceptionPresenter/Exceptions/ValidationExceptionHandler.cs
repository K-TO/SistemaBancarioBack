using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace SatrackBank.WebExceptionPresenter.Exceptions
{
    public class ValidationExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            var exception = context.Exception as ValidationException;

            StringBuilder builder = new StringBuilder();

            foreach (var Failure in exception.Errors)
            {
                builder.AppendLine(string.Format("Propiedad: {0}. Error {1}.", Failure.PropertyName, Failure.ErrorMessage));
            }

            return SetResult(context, StatusCodes.Status400BadRequest, "Error en los datos de entrada", builder.ToString());
        }
    }
}
