using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;



namespace GuessingGameApi
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
                    await context.Response.WriteAsync("Välkommen till Gissningsspel API!");
                });

                endpoints.MapPost("/start", async context =>
                {
                    // Skapa ett slumpmässigt tal mellan 1 och 100
                    Random random = new Random();
                    int secretNumber = random.Next(1, 101);

                    // Spara det slumpmässiga talet i sessionen
                    context.Session.SetInt32("SecretNumber", secretNumber);

                    await context.Response.WriteAsync("Gissningsspelet har startat. Gissa ett tal mellan 1 och 100.");
                });

                endpoints.MapPost("/guess", async context =>
                {
                    // Hämta det slumpmässiga talet från sessionen
                    int? secretNumber = context.Session.GetInt32("SecretNumber");

                    if (secretNumber.HasValue)
                    {
                        string requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
                        if (int.TryParse(requestBody, out int userGuess))
                        {
                            if (userGuess == secretNumber.Value)
                            {
                                await context.Response.WriteAsync("Grattis! Du har gissat rätt.");
                            }
                            else if (userGuess < secretNumber.Value)
                            {
                                await context.Response.WriteAsync("För lågt. Försök igen!");
                            }
                            else
                            {
                                await context.Response.WriteAsync("För högt. Försök igen!");
                            }
                        }
                        else
                        {
                            await context.Response.WriteAsync("Var snäll och ange en giltig siffra.");
                        }
                    }
                    else
                    {
                        await context.Response.WriteAsync("Spelet har inte startat. Anropa /start för att börja.");
                    }
                });
            });
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
