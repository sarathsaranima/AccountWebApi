using AccountWebApi.Contract.Contracts;
using AccountWebApi.Entities.Context;
using AccountWebApi.Exceptions.Middleware;
using AccountWebApi.Logger.Contract;
using AccountWebApi.Logger.Service;
using AccountWebApi.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AccountWebApi.Extensions
{
    /// <summary>
    /// This class defines config methods to services.
    /// </summary>
    public static class ServiceExtension
    {
        /// <summary>
        /// Configure logger services.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        /// <summary>
        /// Configure DBContext.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureDbContext(this IServiceCollection services)
        {
            services.AddDbContext<AccountDbContext>();
        }

        /// <summary>
        /// Configure Scoped services.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountServices>();
            services.AddScoped<ITransactionService, TransactionService>();
        }

        /// <summary>
        /// Configure Exception middleware.
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
