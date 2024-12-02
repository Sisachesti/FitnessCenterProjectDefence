using FitnessCenter.Data;
using FitnessCenter.Data.Models;
using FitnessCenter.Services.Data;
using FitnessCenter.Services.Data.Interfaces;
using FitnessCenter.Web.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("SQLServer")!;
            string? fitnessCenterWebAppOrigin = builder.Configuration.GetValue<string>("Client Origins:FitnessCenterWebApp");

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

            builder.Services.RegisterRepositories(typeof(ApplicationUser).Assembly);

            builder.Services.AddScoped<IGymService, GymService>();
            builder.Services.AddScoped<IManagerService, ManagerService>();
            builder.Services.AddScoped<IClassService, ClassService>();
            builder.Services.AddScoped<IPlanService, PlanService>();
            builder.Services.AddScoped<ISubscribtionService, SubscribtionService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
