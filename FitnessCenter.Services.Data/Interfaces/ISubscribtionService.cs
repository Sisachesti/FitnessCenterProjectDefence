namespace FitnessCenter.Services.Data.Interfaces
{
    using FitnessCenter.Web.ViewModels.GymClass;
    public interface ISubscribtionService
    {
        public Task<bool> SetAvailableTicketsAsync(SetAvailableSubscribtionsViewModel model);
    }
}
