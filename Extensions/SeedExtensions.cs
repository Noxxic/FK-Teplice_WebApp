using System;
using FKTeplice.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace FKTeplice.Extensions
{
    public static class SeedExtensions {
        public static IWebHost SeedDatabase(this IWebHost webHost, bool seed)
        {
            if(seed) {
                using (var scope = webHost.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var dbContext = services.GetRequiredService<ApplicationDbContext>();

                    ApplicationDbSeeder.Seed(dbContext);
                }
            }
            return webHost;
        }

    }
}