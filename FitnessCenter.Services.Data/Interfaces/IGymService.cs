using FitnessCenter.Web.ViewModels.Gym;

namespace FitnessCenter.Services.Data.Interfaces
{
    public interface IGymService
    {
        Task<IEnumerable<GymIndexViewModel>> IndexGetAllOrderedByLocationAsync();

        Task AddGymAsync(AddGymFormModel model);

        Task<GymDetailsViewModel?> GetGymDetailsByIdAsync(Guid id);

        Task<EditGymFormModel?> GetGymForEditByIdAsync(Guid id);

        Task<bool> EditGymAsync(EditGymFormModel model);

        Task<DeleteGymViewModel?> GetGymForDeleteByIdAsync(Guid id);

        Task<bool> SoftDeleteGymAsync(Guid id);
    }
}
