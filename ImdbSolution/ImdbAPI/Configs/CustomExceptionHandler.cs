using System.Net;
using System.Threading.Tasks;
using Imdb.Domain.Shared.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Imdb.Api.Configs
{
    public class CustomExceptionHandler
    {
        public async Task Invoke(HttpContext context)
        {
            const HttpStatusCode httpStatus = HttpStatusCode.InternalServerError;

            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (exception != null)
            {
                if (exception.GetType() == typeof(CoreException))
                {
                    var coreException = (CoreException) exception;

                    context.Response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();
                    context.Response.ContentType = "application/json";

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                    {
                        ErroMessage = $"{coreException.Message}",
                        Status = HttpStatusCode.BadRequest.GetHashCode()
                    }));
                }
                else
                {
                    context.Response.StatusCode = httpStatus.GetHashCode();
                    context.Response.ContentType = "application/json";

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                    {
                        ErroMessage = $"{exception.Message} - {exception.InnerException} - {exception.StackTrace}",
                        Status = httpStatus
                    }));
                }
            }
        }
    }
}
