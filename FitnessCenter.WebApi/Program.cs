using FitnessCenter.Data;
using FitnessCenter.Data.Models;
using FitnessCenter.Models;
using FitnessCenter.Services.Data;
using FitnessCenter.Services.Data.Interfaces;
using FitnessCenter.Services.Mapping;
using FitnessCenter.Web.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string? fitnessCenterWebAppOrigin = builder.Configuration.GetValue<string>("Client Origins:FitnessCenterWebApp");
            string connectionString = builder.Configuration.GetConnectionString("SQLServer")!;

            // Add services to the container.
            builder.Services
                .AddDbContext<FitnessCenterDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(cfg =>
            {
                cfg.AddPolicy("AllowAll", policyBld =>
                {
                    policyBld
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });

                if (!String.IsNullOrWhiteSpace(fitnessCenterWebAppOrigin))
                {
                    cfg.AddPolicy("AllowMyServer", policyBld =>
                    {
                        policyBld
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .WithOrigins(fitnessCenterWebAppOrigin);
                    });
                }
            });

            builder.Services.RegisterRepositories(typeof(ApplicationUser).Assembly);

            builder.Services.AddScoped<IGymService, GymService>();
            builder.Services.AddScoped<IManagerService, ManagerService>();
            builder.Services.AddScoped<IClassService, ClassService>();
            builder.Services.AddScoped<IPlanService, PlanService>();
            builder.Services.AddScoped<ISubscribtionService, SubscribtionService>();

            var app = builder.Build();

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            if (!String.IsNullOrWhiteSpace(fitnessCenterWebAppOrigin))
            {
                app.UseCors("AllowMyServer");
            }

            app.MapControllers();

            app.Run();
        }
    }
}
