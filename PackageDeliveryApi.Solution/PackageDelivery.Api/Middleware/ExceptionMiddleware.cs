using Newtonsoft.Json;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Domain.Extensions;
using System.Net;

namespace PackageDelivery.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger _logger;

        private readonly IUnitOfWork _unitOfWork;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _next = next;
            _unitOfWork = unitOfWork;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong: {ex}");

                await _unitOfWork.ExceptionLogRepository.AddAsync(new Domain.Entities.ExceptionLog
                {
                    CreatedDateUtc = DateTime.UtcNow,
                    CreatedBy = nameof(ExceptionMiddleware),
                    Exception = ex.ToJson()
                });

                await _unitOfWork.SaveChangesAsync();

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string result = JsonConvert.SerializeObject(new ErrorDeatils
            {
                ErrorMessage = exception.Message,
                ErrorType = "Failure"
            });

            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }
    }

    public class ErrorDeatils
    {
        public string? ErrorType { get; set; }
        public string? ErrorMessage { get; set; }
    }
}