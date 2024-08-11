using AutoMapper;
using System.Net;
using System.Text.Json;

using TerraCloud.Application.DTOs.Error;
using TerraCloud.Application.Exceptions;

namespace TerraCloud.Server.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMapper _mapper;

        public ExceptionHandlerMiddleware(RequestDelegate next, IMapper mapper)
        {
            _next = next;
            _mapper = mapper;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = ex is MyApplicationException appEx
                    ? _mapper.Map<ErrorResponse>(appEx)
                    : new ErrorResponse
                    {
                        Describe = "There was an error",
                        ErrorCode = ErrorCode.ApplicationError,
                        HttpStatusCode = HttpStatusCode.InternalServerError
                    };

                context.Response.StatusCode = (int)response.HttpStatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
