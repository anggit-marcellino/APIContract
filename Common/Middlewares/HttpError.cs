using Common.Exceptions;
using Common.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Middlewares
{
    public class HttpError
    {
        private readonly RequestDelegate _next;

        public HttpError(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = error switch
                {
                    NotFoundException => (int)HttpStatusCode.NotFound,
                    ConflictException => (int)HttpStatusCode.Conflict,
                    UnprocessableEntityException => (int)HttpStatusCode.UnprocessableEntity,
                    _ => (int)HttpStatusCode.InternalServerError,
                };

                var status = response.StatusCode;
                var messages = error?.Message;

                var errResponse = ResponseFactory<string>.ErrorResponse(status, messages);

                var result = JsonSerializer.Serialize(errResponse);

                await response.WriteAsync(result);
            }
        }
    }
}
