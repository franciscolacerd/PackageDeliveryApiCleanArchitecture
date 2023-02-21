using PackageDelivery.Persistence.Contracts.Persistence;
using PackageDelivery.Persistence.Entities;
using System.Text;

namespace PackageDelivery.Api.Middleware
{
    public static class RequestResponseLoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseEnableRequestRewind(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }

    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly IUnitOfWork _unitOfWork;

        public RequestResponseLoggingMiddleware(RequestDelegate next, IUnitOfWork unitOfWork)
        {
            _next = next;
            _unitOfWork = unitOfWork;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = await FormatRequest(context.Request);

            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                var response = await FormatResponse(context.Response);

                await _unitOfWork.ApiLogRepository.AddAsync(new ApiLog
                {
                    Scheme = context?.Request?.Scheme,
                    Host = context?.Request?.Host.Value,
                    Path = context?.Request?.Path,
                    QueryString = $"{context?.Request?.Scheme}://{context?.Request?.Host.Value}{context?.Request?.Path}",
                    RequestBody = request,
                    ResponseBody = response,
                    CreatedDateUtc = DateTime.UtcNow,
                    CreatedBy = nameof(RequestResponseLoggingMiddleware)
                });

                await _unitOfWork.SaveChangesAsync();

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();
            var body = request.Body;
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            body.Seek(0, SeekOrigin.Begin);
            request.Body = body;
            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            string text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return $"{response.StatusCode}: {text}";
        }
    }
}