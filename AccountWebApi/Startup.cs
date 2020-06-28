using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AccountWebApi.Model;
using Microsoft.OpenApi.Models;
using AccountWebApi.Contract;
using AccountWebApi.Services;

namespace AccountWebApi
{
    public class Startup
    {
        private readonly string _title;
        private readonly string _version;
        private readonly string _swagger;
        private readonly string _swaggerUrl;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _title = configuration.GetValue<string>("Application:Title");
            _version = configuration.GetValue<string>("Application:Version");
            _swagger = String.Format("{0} {1}", _title, _version);
            _swaggerUrl = configuration.GetValue<string>("Application:SwaggerUrl");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AccountDbContext>();
            services.AddScoped<IAccountService, AccountServices>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(_version, new OpenApiInfo { Title = _title, Version = _version});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(_swaggerUrl, _swagger);
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
