using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WorldLeague.Domain.Exceptions;

namespace WorldLeague.Api.ExceptionHandling
{
    public class ExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is ValidationException validationException)
            {

                var problemDetails = new ProblemDetails
                {
                    Title = "Validation error",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = validationException.Message,
                    Extensions = new Dictionary<string, object?>
                    {
                        { "errors", validationException.Errors }
                    }
                };

                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                await httpContext.Response.WriteAsJsonAsync(problemDetails);

                return true;

            }

            if (exception is BusinessException businessException)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Business error",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = businessException.Message
                };

                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                await httpContext.Response.WriteAsJsonAsync(problemDetails);

                return true;
            }


            var problemDetails500 = new ProblemDetails
            {
                Title = "Internal server error",
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception.Message
            };

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(problemDetails500);

            return true;
        }
    }
}
