using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sexy.Data;
using Sexy.Data.Repositories;
using Sexy.Data.Repositories.Interfaces;

namespace Sexy
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Database
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Configuration
            Sexy.Data.Constants.AppSettingsConstant.FilenameLength = Configuration.GetSection("AppSettings").GetSection("FilenameLength").Value;
            Sexy.Data.Constants.AppSettingsConstant.InstanceName = Configuration.GetSection("AppSettings").GetSection("InstanceName").Value;
            Sexy.Data.Constants.AppSettingsConstant.InstanceProtocol = Configuration.GetSection("AppSettings").GetSection("InstanceProtocol").Value;
            Sexy.Data.Constants.AppSettingsConstant.MaxFilesize = Configuration.GetSection("AppSettings").GetSection("MaxFilesize").Value;
            Sexy.Data.Constants.AppSettingsConstant.UploadStorageEndpoint = Configuration.GetSection("AppSettings").GetSection("UploadStorageEndpoint").Value;
            Sexy.Data.Constants.AppSettingsConstant.UploadStoragePath = Configuration.GetSection("AppSettings").GetSection("UploadStoragePath").Value;
        
            // Services
            services.AddMvc();
            services.AddOptions();

            // DI
            services.AddTransient<IFileRepository, FileRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
