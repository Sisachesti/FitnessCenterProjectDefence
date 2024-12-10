using FitnessCenter.Services.Mapping;

namespace FitnessCenter.Web.ViewModels.Gym
{
    using Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class GymIndexViewModel : IMapFrom<Gym>
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public string? ImageUrl { get; set; }
    }
}
