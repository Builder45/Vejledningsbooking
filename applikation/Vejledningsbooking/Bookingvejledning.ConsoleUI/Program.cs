using Microsoft.Extensions.Hosting;
using System;

namespace Bookingvejledning.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
            => CreateHostBuilder(args).Build().Run();

        // EF Core uses this method at design time to access the DbContext
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(
                    webBuilder => webBuilder.UseStartup<Startup>());
    }
}
