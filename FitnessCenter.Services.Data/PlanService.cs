namespace FitnessCenter.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using FitnessCenter.Data.Models;
    using FitnessCenter.Data.Repository.Interfaces;
    using Interfaces;
    using Mapping;
    using Web.ViewModels.Plans;

    using static Common.EntityValidationConstants.Class;
    public class PlanService : BaseService, IPlanService
    {
        private readonly IRepository<ApplicationUserClass, object> userClassRepository;
        private readonly IRepository<Class, Guid> classRepository;

        public PlanService(IRepository<ApplicationUserClass, object> userClassRepository,
            IRepository<Class, Guid> classRepository)
        {
            this.userClassRepository = userClassRepository;
            this.classRepository = classRepository;
        }

        public async Task<IEnumerable<ApplicationUserPlansViewModel>> GetUserPlansByUserIdAsync(string userId)
        {
            IEnumerable<ApplicationUserPlansViewModel> plans = await this.userClassRepository
                .GetAllAttached()
                .Include(uc => uc.Class)
                .Where(uc => uc.ApplicationUserId.ToString().ToLower() == userId.ToLower())
                .To<ApplicationUserPlansViewModel>()
                .ToListAsync();

            return plans;
        }

        public async Task<bool> AddClassToUserPlansAsync(string? classId, string userId)
        {
            Guid classGuid = Guid.Empty;
            if (!this.IsGuidValid(classId, ref classGuid))
            {
                return false;
            }

            Class? classM = await this.classRepository
                .GetByIdAsync(classGuid);

            if (classM == null)
            {
                return false;
            }

            Guid userGuid = Guid.Parse(userId);

            ApplicationUserClass? addedToPlansAlready = await this.userClassRepository
                .FirstOrDefaultAsync(uc => uc.ClassId == classGuid &&
                                           uc.ApplicationUserId == userGuid);
            if (addedToPlansAlready == null)
            {
                ApplicationUserClass newUserClass = new ApplicationUserClass()
                {
                    ApplicationUserId = userGuid,
                    ClassId = classGuid
                };

                await this.userClassRepository.AddAsync(newUserClass);
            }

            return true;
        }

        public async Task<bool> RemoveClassFromUserPlansAsync(string? classId, string userId)
        {
            Guid classGuid = Guid.Empty;
            if (!this.IsGuidValid(classId, ref classGuid))
            {
                return false;
            }

            Class? classM = await this.classRepository
                .GetByIdAsync(classGuid);
            if (classM == null)
            {
                return false;
            }

            Guid userGuid = Guid.Parse(userId);

            // TODO: Implement Soft-Delete
            ApplicationUserClass? applicationUserClass = await this.userClassRepository
                .FirstOrDefaultAsync(uc => uc.ClassId == classGuid &&
                                           uc.ApplicationUserId == userGuid);
            if (applicationUserClass != null)
            {
                await this.userClassRepository.DeleteAsync(applicationUserClass);
            }

            return true;
        }
    }
}
