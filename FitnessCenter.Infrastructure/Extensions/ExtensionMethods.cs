using FitnessCenter.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace FitnessCenter.Web.Infrastructure.Extensions
{
    public static class ExtensionMethods
    {
        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope serviceScope = app.ApplicationServices.CreateScope();

            FitnessCenterDbContext dbContext = serviceScope.ServiceProvider
                .GetRequiredService<FitnessCenterDbContext>()!;
            dbContext.Database.Migrate();

            return app;
        }
    }
}
