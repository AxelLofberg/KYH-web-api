using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MyApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Konfigurera tjänster här
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Tryck på Enter för att utföra åtgärden.");
                    // Simulera att användaren trycker på Enter
                    Console.ReadLine();
                    await Knapp(context);
                });
            });
        }

        private async Task Knapp(HttpContext context)
        {
            await context.Response.WriteAsync("Åtgärden utförs...\n");

            await context.Response.WriteAsync("Ange ditt namn:");
            string userName = Console.ReadLine();

            await context.Response.WriteAsync($"Hej {userName}! Logiken är nu utförd.");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
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
