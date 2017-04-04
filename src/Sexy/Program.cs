using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Sexy.Utilities;

namespace Sexy
{
    public class Program
    {
        private static int _port { get; set; }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            StartupUtilities.WriteStartupMessage(StartupUtilities.GetRelease(), ConsoleColor.Magenta);

            if (!File.Exists("appsettings.json")) {
                StartupUtilities.WriteWarning("configuration is missing");
            }

            StartupUtilities.WriteInfo("setting port");
            if(args == null || args.Length == 0)
            {
                _port = 5100;
                StartupUtilities.WriteSuccess("port set to default; " + _port);
            }
            else
            {
                _port = args[0] == null ? 5100 : Int32.Parse(args[0]);
                StartupUtilities.WriteSuccess("port set to user-defined; " + _port);
            }
            
            StartupUtilities.WriteInfo("building configuration");
            var config = new ConfigurationBuilder()
                    .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                    .Build();

            StartupUtilities.WriteInfo("building host environment");
            var host = new WebHostBuilder()
                .UseUrls("http://0.0.0.0:" + _port.ToString() + "/")
                .UseConfiguration(config)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            StartupUtilities.WriteInfo("starting host environment");
            host.Run();

            Console.ResetColor();
        }
    }
}
