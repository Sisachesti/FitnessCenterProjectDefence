using FitnessCenter.Web.ViewModels.Class;
using FitnessCenter.Web.ViewModels.GymClass;

namespace FitnessCenter.Services.Data.Interfaces
{
    public interface IClassService
    {
        Task<IEnumerable<AllClassesIndexViewModel>> GetAllClassesAsync();

        Task<bool> AddClassAsync(AddClassInputModel inputModel);

        Task<ClassDetailsViewModel?> GetClassDetailsByIdAsync(Guid id);

        Task<AddClassToGymInputModel?> GetAddClassToGymInputModelByIdAsync(Guid id);

        Task<bool> AddClassToGymsAsync(Guid classId, AddClassToGymInputModel model);

        Task<EditClassFormModel?> GetEditClassFormModelByIdAsync(Guid id);

        Task<bool> EditClassAsync(EditClassFormModel formModel);

        Task<AvailableSubscribtionsViewModel?> GetAvailableSubscribtionsByIdAsync(Guid cinemaId, Guid movieId);
    }
}
