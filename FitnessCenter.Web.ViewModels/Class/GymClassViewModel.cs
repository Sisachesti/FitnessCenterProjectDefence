using FitnessCenter.Services.Mapping;

namespace FitnessCenter.Web.ViewModels.Class
{
    using Data.Models;

    public class GymClassViewModel : IMapFrom<Class>
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public int Duration { get; set; }

        public string Description { get; set; } = null!;

        public int AvailableSubscriptions { get; set; }
    }
}
