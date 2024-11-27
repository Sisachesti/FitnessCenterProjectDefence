namespace FitnessCenter.Web.ViewModels.Gym
{
    using Data.Models;
    using Services.Mapping;

    public class DeleteGymViewModel : IMapFrom<Gym>
    {
        public string Id { get; set; } = null!;

        public string? Name { get; set; }

        public string? Location { get; set; }
    }
}
