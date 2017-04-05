﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sexy.Data;

namespace Sexy
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
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
            Sexy.Data.Constants.AppSettings.FilenameLength = Configuration.GetSection("AppSettings").GetSection("FilenameLength").Value;
            Sexy.Data.Constants.AppSettings.InstanceName = Configuration.GetSection("AppSettings").GetSection("InstanceName").Value;
            Sexy.Data.Constants.AppSettings.InstanceProtocol = Configuration.GetSection("AppSettings").GetSection("InstanceProtocol").Value;
            Sexy.Data.Constants.AppSettings.MaxFilesize = Configuration.GetSection("AppSettings").GetSection("MaxFilesize").Value;
            Sexy.Data.Constants.AppSettings.UploadStorageEndpoint = Configuration.GetSection("AppSettings").GetSection("UploadStorageEndpoint").Value;
            Sexy.Data.Constants.AppSettings.UploadStoragePath = Configuration.GetSection("AppSettings").GetSection("UploadStoragePath").Value;
        
            // Services
            services.AddMvc();

            // DI
            // ...
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
