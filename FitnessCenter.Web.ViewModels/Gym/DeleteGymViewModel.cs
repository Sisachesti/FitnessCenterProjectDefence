namespace FitnessCenter.Web.ViewModels.Gym
{
    using Data.Models;
    using Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class DeleteGymViewModel : IMapFrom<Gym>
    {
        public string Id { get; set; } = null!;

        public string? Name { get; set; }

        public string? Location { get; set; }

        public string? ImageUrl { get; set; }
    }
}
