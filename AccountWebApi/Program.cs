using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using AccountWebApi.Helpers;

namespace AccountWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The below function call is to initialise the SQLite database each time when the application is started
            Setup.Initialize();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
