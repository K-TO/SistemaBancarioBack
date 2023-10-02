using Microsoft.AspNetCore.Mvc.Filters;

namespace SatrackBank.WebExceptionPresenter.Exceptions
{
    public interface IExceptionHandler
    {
        Task Handle(ExceptionContext context);
    }
}

