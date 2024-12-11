using FitnessCenter.Data;
using FitnessCenter.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static FitnessCenter.Common.ApplicationConstants;


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

        public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string email, string username, string password)
        {
            using IServiceScope serviceScope = app.ApplicationServices.CreateAsyncScope();
            IServiceProvider serviceProvider = serviceScope.ServiceProvider;

            RoleManager<IdentityRole<Guid>>? roleManager = serviceProvider
                .GetService<RoleManager<IdentityRole<Guid>>>();

            IUserStore<ApplicationUser>? userStore = serviceProvider
                .GetService<IUserStore<ApplicationUser>>();

            UserManager<ApplicationUser>? userManager = serviceProvider
                .GetService<UserManager<ApplicationUser>>();

            //If statements to check if the three services are being found, else throw ArgumentExceptions before app.Run() to find the errors
            if (roleManager == null)
            {
                throw new ArgumentNullException(nameof(roleManager),
                    $"Service for {typeof(RoleManager<IdentityRole<Guid>>)} cannot be obtained!");
            }

            if (userStore == null)
            {
                throw new ArgumentNullException(nameof(userStore),
                    $"Service for {typeof(IUserStore<ApplicationUser>)} cannot be obtained!");
            }

            if (userManager == null)
            {
                throw new ArgumentNullException(nameof(userManager),
                    $"Service for {typeof(UserManager<ApplicationUser>)} cannot be obtained!");
            }

            //Creating Async Task.Run(anonym func) wherever we need async in the tasks in the block
            Task.Run(async () =>
            {
                bool roleExists = await roleManager.RoleExistsAsync(AdminRoleName);

                //If the role doesnt exists, CreateAsync it
                IdentityRole<Guid>? adminRole = null;
                if (!roleExists)
                {
                    adminRole = new IdentityRole<Guid>(AdminRoleName);

                    IdentityResult result = await roleManager.CreateAsync(adminRole);
                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException($"Error occurred while creating the {AdminRoleName} role!");
                    }
                }
                else
                {
                    adminRole = await roleManager.FindByNameAsync(AdminRoleName);
                }

                //Create the Admin user with Email and Password with another method called CreateAdminUserAsync
                ApplicationUser? adminUser = await userManager.FindByEmailAsync(email);
                if (adminUser == null)
                {
                    adminUser = await
                        CreateAdminUserAsync(email, username, password, userStore, userManager);
                }

                //If the Admin user exists already, return the app and exit the seeding
                if (await userManager.IsInRoleAsync(adminUser, AdminRoleName))
                {
                    return app;
                }

                IdentityResult userResult = await userManager.AddToRoleAsync(adminUser, AdminRoleName);
                if (!userResult.Succeeded)
                {
                    throw new InvalidOperationException($"Error occurred while adding the user {username} to the {AdminRoleName} role!");
                }

                return app;
            })
                .GetAwaiter()
                .GetResult();

            return app;
        }

        public static IApplicationBuilder SeedManager(this IApplicationBuilder app, string email, string username, string password)
        {
            using IServiceScope serviceScope = app.ApplicationServices.CreateAsyncScope();
            IServiceProvider serviceProvider = serviceScope.ServiceProvider;

            RoleManager<IdentityRole<Guid>>? roleManager = serviceProvider
                .GetService<RoleManager<IdentityRole<Guid>>>();

            IUserStore<ApplicationUser>? userStore = serviceProvider
                .GetService<IUserStore<ApplicationUser>>();

            UserManager<ApplicationUser>? userManager = serviceProvider
                .GetService<UserManager<ApplicationUser>>();

            //If statements to check if the three services are being found, else throw ArgumentExceptions before app.Run() to find the errors
            if (roleManager == null)
            {
                throw new ArgumentNullException(nameof(roleManager),
                    $"Service for {typeof(RoleManager<IdentityRole<Guid>>)} cannot be obtained!");
            }

            if (userStore == null)
            {
                throw new ArgumentNullException(nameof(userStore),
                    $"Service for {typeof(IUserStore<ApplicationUser>)} cannot be obtained!");
            }

            if (userManager == null)
            {
                throw new ArgumentNullException(nameof(userManager),
                    $"Service for {typeof(UserManager<ApplicationUser>)} cannot be obtained!");
            }

            //Creating Async Task.Run(anonym func) wherever we need async in the tasks in the block
            Task.Run(async () =>
            {
                bool roleExists = await roleManager.RoleExistsAsync(ManagerRoleName);

                //If the role doesnt exists, CreateAsync it
                IdentityRole<Guid>? managerRole = null;
                if (!roleExists)
                {
                    managerRole = new IdentityRole<Guid>(ManagerRoleName);

                    IdentityResult result = await roleManager.CreateAsync(managerRole);
                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException($"Error occurred while creating the {ManagerRoleName} role!");
                    }
                }
                else
                {
                    managerRole = await roleManager.FindByNameAsync(ManagerRoleName);
                }

                //Create the Manager user with Email and Password with another method called CreateManagerUserAsync
                ApplicationUser? managerUser = await userManager.FindByEmailAsync(email);
                if (managerUser == null)
                {
                    managerUser = await
                        CreateManagerUserAsync(email, username, password, userStore, userManager);
                }

                //If the Manager user exists already, return the app and exit the seeding
                if (await userManager.IsInRoleAsync(managerUser, ManagerRoleName))
                {
                    return app;
                }

                IdentityResult userResult = await userManager.AddToRoleAsync(managerUser, ManagerRoleName);
                if (!userResult.Succeeded)
                {
                    throw new InvalidOperationException($"Error occurred while adding the user {username} to the {ManagerRoleName} role!");
                }

                return app;
            })
                .GetAwaiter()
                .GetResult();

            return app;
        }

        private static async Task<ApplicationUser> CreateAdminUserAsync(string email, string username, string password,
            IUserStore<ApplicationUser> userStore, UserManager<ApplicationUser> userManager)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                Email = email
            };

            await userStore.SetUserNameAsync(applicationUser, username, CancellationToken.None);

            IdentityResult result = await userManager.CreateAsync(applicationUser, password);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Error occurred while registering {AdminRoleName} user!");
            }

            return applicationUser;
        }

        private static async Task<ApplicationUser> CreateManagerUserAsync(string email, string username, string password,
            IUserStore<ApplicationUser> userStore, UserManager<ApplicationUser> userManager)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                Email = email
            };

            await userStore.SetUserNameAsync(applicationUser, username, CancellationToken.None);

            IdentityResult result = await userManager.CreateAsync(applicationUser, password);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Error occurred while registering {ManagerRoleName} user!");
            }

            return applicationUser;
        }
    }
}
