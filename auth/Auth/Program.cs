using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Auth
{
     public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 1 && args[0] == "schema")
            {
                var serviceCollection = new ServiceCollection();
                var startup = new Startup(null);
                startup.ConfigureServices(serviceCollection);
                File.WriteAllText(
                    "schema.graphql",
                    serviceCollection.BuildServiceProvider()
                        .GetRequiredService<ISchema>()
                        .ToString());
            }
            else
            {
                CreateHostBuilder(args).Build().Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) => 
                    config.AddEnvironmentVariables())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}