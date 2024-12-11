

namespace FitnessCenter.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using FitnessCenter.Data.Models;
    using FitnessCenter.Data.Repository.Interfaces;
    using Interfaces;

    public class ManagerService : BaseService, IManagerService
    {
        private readonly IRepository<Manager, Guid> managersRepository;

        public ManagerService(IRepository<Manager, Guid> managersRepository)
        {
            this.managersRepository = managersRepository;
        }

        public async Task<bool> IsUserManagerAsync(string? userId)
        {
            // Not a valid use-case, but we write defensive programming
            if (String.IsNullOrWhiteSpace(userId))
            {
                return false;
            }

            bool result = await this.managersRepository
                .GetAllAttached()
                .AnyAsync(m => m.UserId.ToString().ToLower() == userId);

            return result;
        }



        public async Task<bool> RemoveManagerAsync(string? userId)
        {
            // Not a valid use-case, but we write defensive programming
            if (String.IsNullOrWhiteSpace(userId))
            {
                return false;
            }

            Manager managerToDelete = await this.managersRepository
                .FirstOrDefaultAsync(m => m.UserId.ToString() == userId);

            bool result = await this.managersRepository
                .DeleteAsync(managerToDelete);

            return result;
        }

        public async Task<bool> AddManagerAsync(string? userId)
        {
            // Not a valid use-case, but we write defensive programming
            if (String.IsNullOrWhiteSpace(userId))
            {
                return false;
            }

            Manager foundManager = await this.managersRepository
                .FirstOrDefaultAsync(m => m.UserId.ToString() == userId);

            if (foundManager == null)
            {
                Manager managerToAdd = new Manager()
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.Parse(userId),
                    WorkPhoneNumber = "0888 123 1234"
                };

                await this.managersRepository
                    .AddAsync(managerToAdd);
            }

            return true;
        }
    }
}
