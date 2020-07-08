using AccountWebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog;
using System;
using System.IO;

namespace AccountWebApi
{

    /// <summary>
    /// Defines the Startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Defines the _title.
        /// </summary>
        private readonly string _title;

        /// <summary>
        /// Defines the _version.
        /// </summary>
        private readonly string _version;

        /// <summary>
        /// Defines the _swagger.
        /// </summary>
        private readonly string _swagger;

        /// <summary>
        /// Defines the _swaggerUrl.
        /// </summary>
        private readonly string _swaggerUrl;

        /// <summary>
        /// Defines the _nlogFile.
        /// </summary>
        private readonly string _nlogFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/>.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _title = configuration.GetValue<string>("Application:Title");
            _version = configuration.GetValue<string>("Application:Version");
            _swagger = string.Format("{0} {1}", _title, _version);
            _swaggerUrl = configuration.GetValue<string>("Application:SwaggerUrl");
            _nlogFile = configuration.GetValue<string>("Application:NLogFile");
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(),
                _nlogFile));
        }

        /// <summary>
        /// Gets the Configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// The ConfigureServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureLoggerService();
            services.AddControllers();
            services.ConfigureDbContext();
            services.ConfigureScopedServices();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(_version, new OpenApiInfo { Title = _title, Version = _version });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// The Configure.
        /// </summary>
        /// <param name="app">The app<see cref="IApplicationBuilder"/>.</param>
        /// <param name="env">The env<see cref="IWebHostEnvironment"/>.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureCustomExceptionMiddleware();
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
