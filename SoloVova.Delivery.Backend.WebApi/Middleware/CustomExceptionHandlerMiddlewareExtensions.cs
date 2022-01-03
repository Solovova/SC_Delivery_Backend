using Microsoft.AspNetCore.Builder;

namespace SoloVova.Delivery.Backend.WebApi.Middleware{
    public static class CustomExceptionHandlerMiddlewareExtensions{
        public static IApplicationBuilder UseCustomExceptionHandler(this
            IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}