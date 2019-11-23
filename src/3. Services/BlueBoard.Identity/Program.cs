using BlueBoard.Service;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BlueBoard.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog()
                .SetupService();
    }
}
