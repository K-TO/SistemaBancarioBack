using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using SatrackBank.Entities.Exceptions;

namespace SatrackBank.WebExceptionPresenter.Exceptions
{
    public class GeneralExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            var exception = context.Exception as GeneralException;
            return SetResult(context, StatusCodes.Status500InternalServerError, exception.Message, exception.Details);
        }
    }
}
