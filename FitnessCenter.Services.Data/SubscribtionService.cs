using FitnessCenter.Data.Models;
using FitnessCenter.Data.Repository.Interfaces;
using FitnessCenter.Services.Data.Interfaces;
using FitnessCenter.Services.Mapping;
using FitnessCenter.Web.ViewModels.GymClass;

namespace FitnessCenter.Services.Data
{
    public class SubscribtionService : BaseService, ISubscribtionService
    {
        private readonly IRepository<GymClass, object> gymClassRepository;

        public SubscribtionService(IRepository<GymClass, object> gymClassRepository)
        {
            this.gymClassRepository = gymClassRepository;
        }

        public async Task<bool> SetAvailableSubscribtionsAsync(SetAvailableSubscribtionsViewModel model)
        {
            GymClass gymClass = AutoMapperConfig.MapperInstance
                .Map<GymClass>(model);

            return await this.gymClassRepository.UpdateAsync(gymClass);
        }
    }
}
