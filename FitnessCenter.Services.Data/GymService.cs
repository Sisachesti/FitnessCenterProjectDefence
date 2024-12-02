using FitnessCenter.Data.Models;
using FitnessCenter.Data.Repository.Interfaces;
using FitnessCenter.Services.Data.Interfaces;
using FitnessCenter.Services.Mapping;
using FitnessCenter.Web.ViewModels.Class;
using FitnessCenter.Web.ViewModels.Gym;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Services.Data
{
    public class GymService : BaseService, IGymService
    {
        private readonly IRepository<Gym, Guid> gymRepository;

        public GymService(IRepository<Gym, Guid> gymRepository)
        {
            this.gymRepository = gymRepository;
        }

        public async Task<IEnumerable<GymIndexViewModel>> IndexGetAllOrderedByLocationAsync()
        {
            IEnumerable<GymIndexViewModel> gyms = await this.gymRepository
                .GetAllAttached()
                .OrderBy(g => g.Location)
                .To<GymIndexViewModel>()
                .ToArrayAsync();

            return gyms;
        }

        public async Task AddGymAsync(AddGymFormModel model)
        {
            Gym gym = new Gym();
            AutoMapperConfig.MapperInstance.Map(model, gym);

            await this.gymRepository.AddAsync(gym);
        }

        public async Task<GymDetailsViewModel?> GetGymDetailsByIdAsync(Guid id)
        {
            Gym? gym = await this.gymRepository
                .GetAllAttached()
                .Include(g => g.GymClasses)
                .ThenInclude(gc => gc.Class)
                .FirstOrDefaultAsync(g => g.Id == id);

            GymDetailsViewModel? viewModel = null;
            if (gym != null)
            {
                viewModel = new GymDetailsViewModel()
                {
                    Name = gym.Name,
                    Location = gym.Location,
                    Classes = gym.GymClasses
                        .Where(gc => gc.IsDeleted == false)
                        .Select(gc => new GymClassViewModel()
                        {
                            Title = gc.Class.Title,
                            Duration = gc.Class.Duration,
                            Description = gc.Class.Description,
                            ImageUrl = gc.Class.ImageUrl
                        })
                        .ToArray()
                };
            }

            return viewModel;
        }

        public async Task<EditGymFormModel?> GetGymForEditByIdAsync(Guid id)
        {
            EditGymFormModel? gymModel = await this.gymRepository
                .GetAllAttached()
                .Where(g => g.IsDeleted == false)
                .To<EditGymFormModel>()
                .FirstOrDefaultAsync(g => g.Id.ToLower() == id.ToString().ToLower());

            return gymModel;
        }

        public async Task<bool> EditGymAsync(EditGymFormModel model)
        {
            Gym cinemaEntity = AutoMapperConfig.MapperInstance
                .Map<EditGymFormModel, Gym>(model);

            bool result = await this.gymRepository.UpdateAsync(cinemaEntity);
            return result;
        }

        public async Task<DeleteGymViewModel?> GetGymForDeleteByIdAsync(Guid id)
        {
            DeleteGymViewModel? gymToDelete = await this.gymRepository
                .GetAllAttached()
                .Where(g => g.IsDeleted == false)
                .To<DeleteGymViewModel>()
                .FirstOrDefaultAsync(g => g.Id.ToLower() == id.ToString().ToLower());

            return gymToDelete;
        }

        public async Task<bool> SoftDeleteGymAsync(Guid id)
        {
            Gym? gymToDelete = await this.gymRepository
                .FirstOrDefaultAsync(c => c.Id.ToString().ToLower() == id.ToString().ToLower());

            if (gymRepository == null)
            {
                return false;
            }

            gymToDelete.IsDeleted = true;
            return await this.gymRepository.UpdateAsync(gymToDelete);
        }
    }
}
