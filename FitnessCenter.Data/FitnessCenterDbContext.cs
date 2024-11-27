using FitnessCenter.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FitnessCenter.Data
{
    public class FitnessCenterDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public FitnessCenterDbContext()
        {
            
        }

        public FitnessCenterDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Gym> Gyms { get; set; } = null!;

        public virtual DbSet<Class> Classes { get; set; } = null!;

        public virtual DbSet<GymClass> GymsClasses { get; set; } = null!;

        public virtual DbSet<ApplicationUserClass> UsersClasses { get; set; } = null!;

        public virtual DbSet<Subscribtion> Subscriptions { get; set; } = null!;

        public virtual DbSet<Manager> Managers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
