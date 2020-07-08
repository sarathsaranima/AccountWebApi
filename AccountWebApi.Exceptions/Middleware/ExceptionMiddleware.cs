using AccountWebApi.Logger.Contract;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AccountWebApi.Exceptions.Middleware
{
    /// <summary>
    /// This is the exception middleware class to handle exceptions globally.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        /// <summary>
        /// Constructor for ExceptionMiddleware.
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _logger = logger;
            _next = next;
        }

        /// <summary>
        /// Method to handle the exceptions.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// Exception handler method to process and Generate the Json response.
        /// </summary>
        /// <param name="context">HttpContext object</param>
        /// <param name="exception">Exception object</param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string strMessage = "Internal Server Error from the custom middleware.";
            if (exception is CustomAccountException)
            {
                context.Response.StatusCode = ((CustomAccountException)exception).Status;
                strMessage = ((CustomAccountException)exception).ExceptionMessage;
            }

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = strMessage
            }.ToString());
        }
    }
}
