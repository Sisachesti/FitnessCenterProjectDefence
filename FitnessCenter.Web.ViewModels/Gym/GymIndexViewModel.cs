using FitnessCenter.Services.Mapping;

namespace FitnessCenter.Web.ViewModels.Gym
{
    using Data.Models;
    public class GymIndexViewModel : IMapFrom<Gym>
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;
    }
}
